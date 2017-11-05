using RestEasyBooking.BusinessLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestEasyBooking.DatabaseLayer
{
    public class BookingDB : DB
    {
        private Collection<Booking> allBookings;
        private Collection<Guest> allGuests;

        #region Properties
        public Collection<Booking> AllBookings
        {
            get { return allBookings; }
        }

        //public Collection<Guest> AllGuests
        //{
        //    get { return allGuests; }
        //}
        #endregion

        public BookingDB() : base()
        {
            allBookings = new Collection<Booking>();
            allGuests = new Collection<Guest>();

            FillDataSet(sqlLocalBooking, tableBooking);
            FillDataSet(sqlLocalGuest, tableGuest);
            FillDataSet(sqlLocalGuestAccount, tableGuestAccount);
            FillDataSet(sqlLocalRefNum, tableRefNum);

            PopulateCollections();
        }

        public override void PopulateCollections()
        {
            //Declare references to a myRow object and each relevant object
            DataRow myRow = null;
            Booking booking;

            //string referenceNum;

            //READ from Booking table
            foreach (DataRow myRow_loopVariable in dsMain.Tables[tableBooking].Rows)
            {
                myRow = myRow_loopVariable;
                if (!(myRow.RowState == DataRowState.Deleted))
                {
                    // collect attributes
                    int id = Convert.ToInt32(myRow[columnAttributes.ID]);
                    int guestid = Convert.ToInt32(myRow[columnAttributes.GuestID]);
                    //DateTime startDate = Convert.ToDateTime(myRow[columnAttributes.StartDate]);
                    //DateTime endDate = Convert.ToDateTime(myRow[columnAttributes.EndDate]);
                    int refNumId = Convert.ToInt32(myRow[columnAttributes.ReferenceNumberId]);
                    int roomId = Convert.ToInt32(myRow[columnAttributes.RoomID]);
                    double balance = Convert.ToDouble(myRow[columnAttributes.Balance]);
                    bool paidDeposit = Convert.ToBoolean(myRow[columnAttributes.PaidDeposit]);

                    // Query Guest table for GuestAccountNumber
                    // assumes guest already exists
                    string guestAccountNumber = Convert.ToString(FindFromTableByPrimaryKey(tableGuest, guestid, "")[1]).TrimEnd();

                    // Query ReferenceNumber table for ReferenceNumber
                    // assumes ref number was already added 
                    string refNumber = Convert.ToString(FindFromTableByPrimaryKey(tableRefNum, refNumId, "")[2]).TrimEnd();

                    // Structs
                    Entity.GuestDetails guestDetails = new Entity.GuestDetails()
                    {
                        ID = guestid,
                        AccountNumber = guestAccountNumber
                    };

                    Entity.ReferenceNumberDetails referenceNumberDetails = new Entity.ReferenceNumberDetails()
                    {
                        ID = refNumId,
                        ReferenceNumber = refNumber
                    };

                    // Create booking instance
                    booking = new Booking(id, new DateTime(), new DateTime(), roomId, balance, paidDeposit)
                    {
                        MyReferenceNumberDetails = referenceNumberDetails,
                        MyGuestDetails = guestDetails
                    };

                    allBookings.Add(booking);
                }
            }
        }

        #region Database Operations CRUD --- Add the object's values to the database
        public bool DataSetChange(Booking booking, DB.DBOperation operation)
        {
            DataRow aRow = null;
            switch (operation)
            {
                case DB.DBOperation.Add:
                    aRow = dsMain.Tables[tableBooking].NewRow();
                    FillRow(aRow, booking, operation);
                    //Add to the dataset
                    dsMain.Tables[tableBooking].Rows.Add(aRow);
                    break;

                case DBOperation.Edit:
                    aRow = FindFromTableByPrimaryKey(tableBooking, booking.ID, "");
                    if (aRow == null) return false;
                    else FillRow(aRow, booking, operation);
                    break;

                case DBOperation.Delete:
                    aRow = FindFromTableByPrimaryKey(tableBooking, booking.ID, "");
                    if (aRow == null) return false;
                    aRow.Delete();
                    break;
            }

            return true;
        }
        #endregion

        #region Build Parameters, Create Commands & Update database
        private void BuildParameters(DBOperation operation)
        {
            //Create Parameters to communicate with SQL INSERT
            SqlParameter idParam = new SqlParameter("@ID", SqlDbType.Int, 4, columnAttributes.ID);
            switch (operation)
            {
                case DBOperation.Add:
                    daMain.InsertCommand.Parameters.Add(idParam);
                    break;
                case DBOperation.Edit:
                    daMain.UpdateCommand.Parameters.Add(idParam);
                    break;
                case DBOperation.Delete:
                    daMain.DeleteCommand.Parameters.Add(idParam);
                    break;
            }
            

            if (operation != DBOperation.Delete)
            {
                if (operation != DBOperation.Edit)
                {
                    //exclude GuestID(which should/must not change)
                    idParam = new SqlParameter("@GUESTID", SqlDbType.Int, 4, columnAttributes.GuestID);
                    daMain.InsertCommand.Parameters.Add(idParam);
                }

                SqlParameter startDateParam = new SqlParameter("@STARTDATE", SqlDbType.DateTime, 8, columnAttributes.StartDate);
                SqlParameter enDateParam = new SqlParameter("@ENDDATE", SqlDbType.DateTime, 8, columnAttributes.EndDate);
                SqlParameter refnumIdParam = new SqlParameter("@REFERENCENUMBERID", SqlDbType.Int, 4, columnAttributes.ReferenceNumberId);
                SqlParameter roomIdParam = new SqlParameter("@ROOMID", SqlDbType.Int, 4, columnAttributes.RoomID);
                SqlParameter balanceParam = new SqlParameter("@BALANCE", SqlDbType.Float, 8, columnAttributes.Balance);
                SqlParameter paidDepositparam = new SqlParameter("@PAIDDEPOSIT", SqlDbType.Bit, 1, columnAttributes.PaidDeposit);

                switch (operation)
                {
                    case DBOperation.Add:
                        daMain.InsertCommand.Parameters.Add(startDateParam);
                        daMain.InsertCommand.Parameters.Add(enDateParam);
                        daMain.InsertCommand.Parameters.Add(refnumIdParam);
                        daMain.InsertCommand.Parameters.Add(roomIdParam);
                        daMain.InsertCommand.Parameters.Add(balanceParam);
                        daMain.InsertCommand.Parameters.Add(paidDepositparam);
                        break;

                    case DBOperation.Edit:
                        daMain.UpdateCommand.Parameters.Add(startDateParam);
                        daMain.UpdateCommand.Parameters.Add(enDateParam);
                        daMain.UpdateCommand.Parameters.Add(refnumIdParam);
                        daMain.UpdateCommand.Parameters.Add(roomIdParam);
                        daMain.UpdateCommand.Parameters.Add(balanceParam);
                        daMain.UpdateCommand.Parameters.Add(paidDepositparam);
                        break;
                }
            }
        }

        private string CreateCommand(DBOperation operation)
        {
            switch (operation)
            {
                case DBOperation.Add:
                    daMain.InsertCommand = new SqlCommand("INSERT into " + tableBooking +
                        " (" + columnAttributes.ID + ", " +
                        columnAttributes.GuestID + ", " +
                        columnAttributes.StartDate + ", " +
                        columnAttributes.EndDate + ", " +
                        columnAttributes.ReferenceNumberId + ", " +
                        columnAttributes.RoomID + ", " +
                        columnAttributes.Balance + ", " +
                        columnAttributes.PaidDeposit + ")" +
                        " VALUES (@ID, @GUESTID, @STARTDATE, @ENDDATE, @REFERENCENUMBERID, @ROOMID, @BALANCE, @PAIDDEPOSIT)", 
                        cnMain);
                    break;

                case DBOperation.Edit:
                    daMain.UpdateCommand = new SqlCommand("UPDATE " + tableBooking + 
                        " SET " +
                        columnAttributes.StartDate + " =@STARTDATE, " +
                        columnAttributes.EndDate + " =@ENDDATE, " +
                        columnAttributes.ReferenceNumberId + " =@REFERENCENUMBERID, " +
                        columnAttributes.RoomID + " =@ROOMID, " +
                        columnAttributes.Balance + " =@BALANCE, " +
                        columnAttributes.PaidDeposit + " =@PAIDDEPOSIT " +
                        "WHERE " +
                        columnAttributes.ID + "=@ID",
                        cnMain);
                    break;

                case DBOperation.Delete:
                    daMain.DeleteCommand = new SqlCommand("DELETE FROM " + tableBooking +
                        " WHERE " + columnAttributes.ID + "=@ID", cnMain); 
                    break;
            }
            string errorstring = "";
            try
            {
                BuildParameters(operation);
            }
            catch(Exception exception)
            {
                errorstring = exception.Message + " " + exception.StackTrace;
            }

            return errorstring;
        }

        private void FillRow(DataRow aRow, Booking booking, DB.DBOperation operation)
        {
            //NOTE square brackets to indicate index of collections of fields in row.
            if (operation == DB.DBOperation.Add)
            {
                aRow[columnAttributes.ID] = booking.ID;
                aRow[columnAttributes.GuestID] = booking.MyGuestDetails.ID;
            }
            aRow[columnAttributes.StartDate] = booking.StartDate;
            aRow[columnAttributes.EndDate] = booking.EndDate;
            aRow[columnAttributes.ReferenceNumberId] = booking.MyReferenceNumberDetails.ID;
            aRow[columnAttributes.RoomID] = booking.RoomID;
            aRow[columnAttributes.Balance] = booking.Balance;
            aRow[columnAttributes.PaidDeposit] = booking.PaidDeposit;
        } 

        public bool UpdateDataSource()
        {
            //bool success = true;
            CreateCommand(DBOperation.Add);
            CreateCommand(DBOperation.Edit);
            CreateCommand(DBOperation.Delete);
            return UpdateDataSource(sqlLocalBooking, tableBooking);
        }
        #endregion
    }
}
