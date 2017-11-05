using RestEasyBooking.BusinessLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// typedefs for convenience
using DatesTuple = System.Tuple<System.DateTime, System.DateTime>;
using RoomDatesTuple = System.Tuple<int, System.Collections.ObjectModel.Collection<System.Tuple<System.DateTime, System.DateTime>>>;

namespace RestEasyBooking.DatabaseLayer
{
    public class BookingDB : DB
    {
        private Collection<Booking> allBookings;
        private Collection<Guest> allGuests;

        private Collection<RoomDatesTuple> roomBookingSeed;

        #region Properties
        public Collection<Booking> AllBookings
        {
            get { return allBookings; }
        }

        public Collection<RoomDatesTuple> RoomBookingSeed
        {
            get { return roomBookingSeed; }
        }
        #endregion

        public BookingDB() : base()
        {
            allBookings = new Collection<Booking>();
            allGuests = new Collection<Guest>();
            roomBookingSeed = new Collection<RoomDatesTuple>();

            FillDataSet(sqlLocalBooking, tableBooking);
            FillDataSet(sqlLocalGuest, tableGuest);
            //FillDataSet(sqlLocalGuestAccount, tableGuestAccount);
            FillDataSet(sqlLocalRefNum, tableRefNum);

            PopulateCollections();
        }

        public override void PopulateCollections()
        {
            //Declare references to a myRow object and each relevant object
            DataRow myRow = null;
            Booking booking;
            
            //READ from Booking table
            foreach (DataRow myRow_loopVariable in dsMain.Tables[tableBooking].Rows)
            {
                myRow = myRow_loopVariable;
                if (!(myRow.RowState == DataRowState.Deleted))
                {
                    // collect attributes
                    int id = Convert.ToInt32(myRow[columnAttributes.ID]);
                    int guestid = Convert.ToInt32(myRow[columnAttributes.GuestID]);
                    DateTime startDate = Convert.ToDateTime(myRow[columnAttributes.StartDate]);
                    DateTime endDate = Convert.ToDateTime(myRow[columnAttributes.EndDate]);
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
                    booking = new Booking(id, startDate, endDate, roomId, balance, paidDeposit)
                    {
                        MyReferenceNumberDetails = referenceNumberDetails,
                        MyGuestDetails = guestDetails
                    };

                    allBookings.Add(booking);

                    bool added = false;
                    DatesTuple dates = new DatesTuple(startDate, endDate);
                    foreach (RoomDatesTuple roomToDates in roomBookingSeed)
                    {
                        // room already in seed
                        if (roomToDates.Item1 == roomId)
                        {
                            roomToDates.Item2.Add(dates);
                            added = true;
                        }
                    }
                    if (!added) roomBookingSeed.Add(new RoomDatesTuple(roomId,
                            new Collection<DatesTuple>() { dates }));
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
                    // Add to Booking table
                    aRow = dsMain.Tables[tableBooking].NewRow();
                    FillRow(aRow, booking, operation, tableBooking);
                    dsMain.Tables[tableBooking].Rows.Add(aRow);

                    // Add to ReferenceNumber table
                    aRow = dsMain.Tables[tableRefNum].NewRow();
                    FillRow(aRow, booking, operation, tableRefNum);
                    dsMain.Tables[tableRefNum].Rows.Add(aRow);
                    break;

                case DBOperation.Edit:
                    // Edit for Booking table
                    aRow = FindFromTableByPrimaryKey(tableBooking, booking.ID, "");
                    if (aRow == null) return false;
                    else FillRow(aRow, booking, operation, tableBooking);

                    // Edit for ReferenceNumber table
                    aRow = FindFromTableByPrimaryKey(tableRefNum, booking.MyReferenceNumberDetails.ID, "");
                    if (aRow == null) return false;
                    else FillRow(aRow, booking, operation, tableRefNum);
                    break;

                case DBOperation.Delete:
                    // Delete from ReferenceNumber table
                    aRow = FindFromTableByPrimaryKey(tableRefNum, booking.MyReferenceNumberDetails.ID, ""); // TODO check
                    if (aRow == null) return false;
                    aRow.Delete();

                    // Delete from Booking table
                    aRow = FindFromTableByPrimaryKey(tableBooking, booking.ID, "");
                    if (aRow == null) return false;
                    aRow.Delete();
                    break;
            }

            return true;
        }
        #endregion

        #region Build Parameters, Create Commands & Update database
        private void BuildParameters(DBOperation operation, string table)
        {
            //Create Parameters to communicate with SQL INSERT
            // Primary/foreign keys
            SqlParameter intIdParam = new SqlParameter("@ID", SqlDbType.Int, 4, columnAttributes.ID);
            SqlParameter guestIdParam = new SqlParameter("@GUESTID", SqlDbType.Int, 4, columnAttributes.GuestID);
            SqlParameter primaryRefnumIdParam = new SqlParameter("@REFERENCENUMBERID", SqlDbType.Int, 4, columnAttributes.ID);
            SqlParameter foreignRefnumIdParam = new SqlParameter("@REFERENCENUMBERID", SqlDbType.Int, 4, columnAttributes.ReferenceNumberId);
            SqlParameter bookIdParam = new SqlParameter("@BOOKID", SqlDbType.Int, 4, columnAttributes.BookID);
            // All other columns
            SqlParameter startDateParam = new SqlParameter("@STARTDATE", SqlDbType.DateTime, 8, columnAttributes.StartDate);
            SqlParameter enDateParam = new SqlParameter("@ENDDATE", SqlDbType.DateTime, 8, columnAttributes.EndDate);
            SqlParameter roomIdParam = new SqlParameter("@ROOMID", SqlDbType.Int, 4, columnAttributes.RoomID);
            SqlParameter balanceParam = new SqlParameter("@BALANCE", SqlDbType.Float, 8, columnAttributes.Balance);
            SqlParameter paidDepositparam = new SqlParameter("@PAIDDEPOSIT", SqlDbType.Bit, 1, columnAttributes.PaidDeposit);
            SqlParameter refnumParam = new SqlParameter("@REFERENCENUMBER", SqlDbType.NVarChar, 20, columnAttributes.ReferenceNumber);

            switch (table)
            {
                case tableBooking:
                    switch (operation) // for different operations on table
                    {
                        case DBOperation.Add:
                            daMain.InsertCommand.Parameters.Clear();
                            daMain.InsertCommand.Parameters.Add(intIdParam);
                            daMain.InsertCommand.Parameters.Add(guestIdParam);
                            daMain.InsertCommand.Parameters.Add(startDateParam);
                            daMain.InsertCommand.Parameters.Add(enDateParam);
                            daMain.InsertCommand.Parameters.Add(foreignRefnumIdParam);
                            daMain.InsertCommand.Parameters.Add(roomIdParam);
                            daMain.InsertCommand.Parameters.Add(balanceParam);
                            daMain.InsertCommand.Parameters.Add(paidDepositparam);
                            break;

                        case DBOperation.Edit:
                            daMain.UpdateCommand.Parameters.Clear();
                            intIdParam.SourceVersion = DataRowVersion.Original;
                            daMain.UpdateCommand.Parameters.Add(intIdParam);
                            startDateParam.SourceVersion = DataRowVersion.Current;
                            daMain.UpdateCommand.Parameters.Add(startDateParam);
                            enDateParam.SourceVersion = DataRowVersion.Current;
                            daMain.UpdateCommand.Parameters.Add(enDateParam);
                            foreignRefnumIdParam.SourceVersion = DataRowVersion.Current;
                            daMain.UpdateCommand.Parameters.Add(foreignRefnumIdParam);
                            roomIdParam.SourceVersion = DataRowVersion.Current;
                            daMain.UpdateCommand.Parameters.Add(roomIdParam);
                            balanceParam.SourceVersion = DataRowVersion.Current;
                            daMain.UpdateCommand.Parameters.Add(balanceParam);
                            paidDepositparam.SourceVersion = DataRowVersion.Current;
                            daMain.UpdateCommand.Parameters.Add(paidDepositparam);
                            break;

                        case DBOperation.Delete:
                            daMain.DeleteCommand.Parameters.Clear();
                            daMain.DeleteCommand.Parameters.Add(intIdParam);
                            break;
                    }
                    break;

                case tableRefNum:
                    switch (operation)
                    {
                        case DBOperation.Add:
                            daMain.InsertCommand.Parameters.Add(primaryRefnumIdParam);
                            daMain.InsertCommand.Parameters.Add(refnumParam);
                            daMain.InsertCommand.Parameters.Add(bookIdParam);
                            break;

                        case DBOperation.Edit:
                            primaryRefnumIdParam.SourceVersion = DataRowVersion.Original;
                            daMain.UpdateCommand.Parameters.Add(primaryRefnumIdParam);
                            refnumParam.SourceVersion = DataRowVersion.Current;
                            daMain.UpdateCommand.Parameters.Add(refnumParam);
                            break;

                        case DBOperation.Delete:
                            daMain.DeleteCommand.Parameters.Add(primaryRefnumIdParam);
                            break;
                    }
                    break;
            }
        }

        private string CreateCommand(DBOperation operation, string table)
        {
            switch (table)
            {
                case tableBooking:
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
                                columnAttributes.ID + " = @ID",
                                cnMain);
                            break;

                        case DBOperation.Delete:
                            daMain.DeleteCommand = new SqlCommand("DELETE FROM " + tableBooking +
                                " WHERE " + columnAttributes.ID + " = @ID", cnMain);
                            break;
                    }
                    break;

                case tableRefNum:
                    switch (operation)
                    {
                        case DBOperation.Add:
                            daMain.InsertCommand = new SqlCommand("INSERT into " + tableRefNum +
                                " (" + columnAttributes.ID + ", " +
                                columnAttributes.ReferenceNumber + ", " +
                                columnAttributes.BookID + ")" +
                                " VALUES (@REFERENCENUMBERID, @REFERENCENUMBER, @BOOKID)",
                                cnMain);
                            break;

                        case DBOperation.Edit:
                            daMain.UpdateCommand = new SqlCommand("UPDATE " + tableRefNum +
                                " SET " +
                                columnAttributes.ReferenceNumber + " =@REFERENCENUMBER " +
                                "WHERE " +
                                columnAttributes.ID + " = @REFERENCENUMBERID",
                                cnMain);
                            break;

                        case DBOperation.Delete:
                            daMain.DeleteCommand = new SqlCommand("DELETE FROM " + tableRefNum +
                                " WHERE " + columnAttributes.ID + " = @REFERENCENUMBERID", cnMain);
                            break;
                    }
                    break;
            }
            
            // TODO formatting
            string errorstring = "";
            try
            {
                BuildParameters(operation, table);
            }
            catch(Exception exception)
            {
                errorstring = exception.Message + " " + exception.StackTrace;
            }

            return errorstring;
        }

        private void FillRow(DataRow aRow, Booking booking, DB.DBOperation operation, string table)
        {
            switch (table)
            {
                case tableBooking:
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
                    break;

                case tableRefNum:
                    if (operation == DB.DBOperation.Add) aRow[columnAttributes.ID] = booking.MyReferenceNumberDetails.ID;
                    aRow[columnAttributes.ReferenceNumber] = booking.MyReferenceNumberDetails.ReferenceNumber;
                    aRow[columnAttributes.BookID] = booking.ID;
                    break;
            }
        } 

        public bool UpdateDataSource(DBOperation operation)
        {
            bool bookSuccess = false, refNumSuccess = false;
            try
            {
                switch (operation)
                {
                    case DBOperation.Delete:
                        CreateCommand(DBOperation.Add, tableRefNum);
                        CreateCommand(DBOperation.Edit, tableRefNum);
                        CreateCommand(DBOperation.Delete, tableRefNum);
                        refNumSuccess = UpdateDataSource(sqlLocalRefNum, tableRefNum);
                        CreateCommand(DBOperation.Add, tableBooking);
                        CreateCommand(DBOperation.Edit, tableBooking);
                        CreateCommand(DBOperation.Delete, tableBooking);
                        bookSuccess = UpdateDataSource(sqlLocalBooking, tableBooking);
                        break;

                    default:
                        CreateCommand(DBOperation.Add, tableBooking);
                        CreateCommand(DBOperation.Edit, tableBooking);
                        CreateCommand(DBOperation.Delete, tableBooking);
                        bookSuccess = UpdateDataSource(sqlLocalBooking, tableBooking);
                        CreateCommand(DBOperation.Add, tableRefNum);
                        CreateCommand(DBOperation.Edit, tableRefNum);
                        CreateCommand(DBOperation.Delete, tableRefNum);
                        refNumSuccess = UpdateDataSource(sqlLocalRefNum, tableRefNum);
                        break;
                }
            }
            catch (Exception exc)
            {
                cnMain.Close();
                // TODO: format
                MessageBox.Show(exc.Message + "  " + exc.StackTrace);
                return false;
            }

            return bookSuccess && refNumSuccess;
        }
        #endregion
    }
}
