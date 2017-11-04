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
    class BookingDB : DB
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

        protected override void PopulateCollections()
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
                    string guestAccountNumber = Convert.ToString(dsMain.Tables[tableGuest].Select(filterExpression: "Id=" + id)[0].ItemArray[1]).TrimEnd();

                    // Query ReferenceNumber table for ReferenceNumber
                    // assumes ref number was already added 
                    string refNumber = Convert.ToString(dsMain.Tables[tableRefNum].Select(filterExpression: "Id=" + refNumId)[0].ItemArray[2]).TrimEnd();

                    // Structs
                    GuestDetails guestDetails = new GuestDetails()
                    {
                        ID = guestid,
                        AccountNumber = guestAccountNumber
                    };

                    ReferenceNumberDetails referenceNumberDetails = new ReferenceNumberDetails()
                    {
                        ID = refNumId,
                        ReferenceNumber = refNumber
                    };

                    // Create booking instance
                    booking = new Booking(id, new DateTime(), new DateTime(), roomId, balance, paidDeposit)
                    {
                        referenceNumberDetails = referenceNumberDetails,
                        GuestDetails = guestDetails
                    };

                    allBookings.Add(booking);
                }
            }
        }

        #region Database Operations CRUD --- Add the object's values to the database
        public void DataSetChange(Booking booking, DB.DBOperation operation)
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
            }
        }
        #endregion

        #region Build Parameters, Create Commands & Update database
        private void Build_INSERT_Parameters()
        {
            //Create Parameters to communicate with SQL INSERT
            SqlParameter param = default(SqlParameter);
            param = new SqlParameter("@ID", SqlDbType.Int, 4, columnAttributes.ID);
            daMain.InsertCommand.Parameters.Add(param);

            param = new SqlParameter("@GUESTID", SqlDbType.Int, 4, columnAttributes.GuestID);
            daMain.InsertCommand.Parameters.Add(param);

            param = new SqlParameter("@STARTDATE", SqlDbType.DateTime, 8, columnAttributes.StartDate);
            daMain.InsertCommand.Parameters.Add(param);

            param = new SqlParameter("@ENDDATE", SqlDbType.DateTime, 8, columnAttributes.EndDate);
            daMain.InsertCommand.Parameters.Add(param);

            param = new SqlParameter("@REFERENCENUMBERID", SqlDbType.Int, 4, columnAttributes.ReferenceNumberId);
            daMain.InsertCommand.Parameters.Add(param);

            param = new SqlParameter("@ROOMID", SqlDbType.Int, 4, columnAttributes.RoomID);
            daMain.InsertCommand.Parameters.Add(param);

            param = new SqlParameter("@BALANCE", SqlDbType.Float, 8, columnAttributes.Balance);
            daMain.InsertCommand.Parameters.Add(param);

            param = new SqlParameter("@PAIDDEPOSIT", SqlDbType.Bit, 1, columnAttributes.PaidDeposit);
            daMain.InsertCommand.Parameters.Add(param);
        }

        private void FillRow(DataRow aRow, Booking booking, DB.DBOperation operation)
        {
            if (operation == DB.DBOperation.Add)
            {
                //NOTE square brackets to indicate index of collections of fields in row.
                aRow[columnAttributes.ID] = booking.ID;
                aRow[columnAttributes.GuestID] = booking.GuestDetails.ID;
                aRow[columnAttributes.StartDate] = booking.StartDate;
                aRow[columnAttributes.EndDate] = booking.EndDate;
                aRow[columnAttributes.ReferenceNumberId] = booking.referenceNumberDetails.ID;
                aRow[columnAttributes.RoomID] = booking.RoomID;
                aRow[columnAttributes.Balance] = booking.Balance;
                aRow[columnAttributes.PaidDeposit] = booking.PaidDeposit;
            }
        }

        private void Create_INSERT_Command()
        {
            daMain.InsertCommand = new SqlCommand("INSERT into " + tableBooking +
                "(" + columnAttributes.ID + ", " +
                columnAttributes.GuestID + ", " +
                columnAttributes.StartDate + ", " +
                columnAttributes.EndDate + ", " +
                columnAttributes.ReferenceNumberId + ", " +
                columnAttributes.RoomID + ", " +
                columnAttributes.Balance + ", " +
                columnAttributes.PaidDeposit + ")" +
                " VALUES (@ID, @GUESTID, @STARTDATE, @ENDDATE, @REFERENCENUMBERID, @ROOMID, @BALANCE, @PAIDDEPOSIT)", cnMain);

            Build_INSERT_Parameters();
        }

        public bool UpdateDataSource()
        {
            bool success = true;
            Create_INSERT_Command();
            return UpdateDataSource(sqlLocalBooking, tableBooking);
        }
            #endregion
        }
}
