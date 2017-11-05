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

namespace RestEasyBooking.DatabaseLayer
{
    public class GuestDB : DB
    {
        private Collection<Guest> allGuests;
        //private Collection<GuestAccount> allGuestAccounts;
        //private Collection<ReferenceNumber> allRefNumbers;

        #region Properties
        public Collection<Guest> AllGuests
        {
            get { return allGuests; }
        }
        #endregion
        public GuestDB() : base()
        {
            allGuests = new Collection<Guest>();
            //allGuestAccounts = new Collection<GuestAccount>();
            //allRefNumbers = new Collection<ReferenceNumber>();
            FillDataSet(sqlLocalGuest, tableGuest);
            FillDataSet(sqlLocalGuestAccount, tableGuestAccount);
            FillDataSet(sqlLocalRefNum, tableRefNum);
            //FillDataSet(sqlLocalBooking, tableBooking);

            PopulateCollections();
        }

        

        public override void PopulateCollections()
        {
            //Declare references to a myRow object and each relevant object
            DataRow myRow = null;
            Guest guest = null;
            GuestAccount guestAcc = null;
            
            //string referenceNum;
            
            //READ from Guest table
            foreach (DataRow myRow_loopVariable in dsMain.Tables[tableGuest].Rows)
            {
                myRow = myRow_loopVariable;
                if (!(myRow.RowState == DataRowState.Deleted))
                {
                    // collect attributes
                    int id  = Convert.ToInt32(myRow[columnAttributes.ID]);

                    string guestAccountNumber = "", name = "", email = "", phone = "", address = "";
                    
                    // The code below shows the test for database Null values
                    if (myRow[columnAttributes.GuestAccountNumber] != System.DBNull.Value)
                    {
                        guestAccountNumber = Convert.ToString(myRow[columnAttributes.GuestAccountNumber]).TrimEnd();
                        double amount = 0;
                        //double amount = Convert.ToInt32(FindFromTableByPrimaryKey(tableGuestAccount, 0, guest.GuestAccountNumber).ItemArray[1]);
                        //READ from GuestAccount table
                        foreach (DataRow myRow_loopVariable2 in dsMain.Tables[tableGuestAccount].Rows)
                        {
                            myRow = myRow_loopVariable2;
                            if (!(myRow.RowState == DataRowState.Deleted))
                            {
                                if (Convert.ToString(myRow[columnAttributes.ID]).TrimEnd() == guestAccountNumber)
                                {
                                    amount = Convert.ToDouble(myRow[columnAttributes.Balance]);
                                }
                            }
                        }

                        guestAcc = new GuestAccount(guestAccountNumber, amount); // TODO check

                        myRow = myRow_loopVariable; // back to Guest table

                        name = Convert.ToString(myRow[columnAttributes.Name]).TrimEnd();
                        phone = Convert.ToString(myRow[columnAttributes.Phone]).TrimEnd();
                        email = Convert.ToString(myRow[columnAttributes.Email]).TrimEnd();
                        address = Convert.ToString(myRow[columnAttributes.Address]).TrimEnd();

                        guest = new Guest(id, guestAcc, name, phone, email, address);

                        //READ from ReferenceNumber table
                        foreach (DataRow myRow_loopVariable2 in dsMain.Tables[tableRefNum].Rows)
                        {
                            myRow = myRow_loopVariable2;
                            if (!(myRow.RowState == DataRowState.Deleted))
                            {
                                if (myRow[columnAttributes.GuestID] != DBNull.Value && Convert.ToInt32(myRow[columnAttributes.GuestID]) == id)
                                {
                                    int refId = Convert.ToInt32(myRow[columnAttributes.ID]);
                                    string refNum = Convert.ToString(myRow[columnAttributes.ReferenceNumber]).TrimEnd();
                                    // Add all reference numbers
                                    guest.MyReferenceNumberDetails = new Entity.ReferenceNumberDetails()
                                    {
                                        ID = refId,
                                        ReferenceNumber = refNum
                                    };
                                    break;
                                }
                            }
                        }

                        allGuests.Add(guest);
                    }    
                }
            }
        }

        #region Database Operations CRUD --- Add the object's values to the database
        public bool DataSetChange(Guest guest, DB.DBOperation operation)
        {
            DataRow aRow = null;
            switch (operation)
            {
                case DB.DBOperation.Add:
                    // Add to GuestAccount table
                    aRow = dsMain.Tables[tableGuestAccount].NewRow();
                    FillRow(aRow, guest, operation, tableGuestAccount);
                    dsMain.Tables[tableGuestAccount].Rows.Add(aRow);

                    // Add to Guest table
                    aRow = dsMain.Tables[tableGuest].NewRow();
                    FillRow(aRow, guest, operation, tableGuest);
                    dsMain.Tables[tableGuest].Rows.Add(aRow);

                    // Add to ReferenceNumber table
                    aRow = dsMain.Tables[tableRefNum].NewRow();
                    FillRow(aRow, guest, operation, tableRefNum);
                    dsMain.Tables[tableRefNum].Rows.Add(aRow);

                    break;

                case DBOperation.Edit:
                    // Edit for GuestAccount table
                    aRow = FindFromTableByPrimaryKey(tableGuestAccount, 0, guest.GuestAccountNumber);
                    if (aRow == null) return false;
                    else FillRow(aRow, guest, operation, tableGuestAccount);
                    

                    // Edit for Guest table
                    aRow = FindFromTableByPrimaryKey(tableGuest, guest.ID, "");
                    if (aRow == null) return false;
                    else FillRow(aRow, guest, operation, tableGuest);

                    // Edit for ReferenceNumber table
                    aRow = FindFromTableByPrimaryKey(tableRefNum, guest.MyReferenceNumberDetails.ID, "");
                    if (aRow == null) return false;
                    else FillRow(aRow, guest, operation, tableRefNum);
                    break;

                case DBOperation.Delete:
                    // Delete from ReferenceNumber table
                    aRow = FindFromTableByPrimaryKey(tableRefNum, guest.MyReferenceNumberDetails.ID, ""); // TODO check
                    if (aRow == null) return false;
                    aRow.Delete();

                    // Delete from Guest table
                    aRow = FindFromTableByPrimaryKey(tableGuest, guest.ID, "");
                    if (aRow == null) return false;
                    aRow.Delete();

                    // Delete from GuestAccount table
                    aRow = FindFromTableByPrimaryKey(tableGuestAccount, 0, guest.GuestAccountNumber); // TODO check
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
            SqlParameter guestAccountParam = new SqlParameter("@GUESTACCOUNTNUMBER", SqlDbType.NVarChar, 10, columnAttributes.GuestAccountNumber);
            SqlParameter guestIdParam = new SqlParameter("@GUESTID", SqlDbType.NVarChar, 10, columnAttributes.ID);
            SqlParameter bookIdParam = new SqlParameter("@BOOKID", SqlDbType.Int, 4, columnAttributes.BookID);
            SqlParameter refnumIdParam = new SqlParameter("@REFERENCENUMBERID", SqlDbType.Int, 4, columnAttributes.ID);
            //All other columns
            SqlParameter nameParam = new SqlParameter("@NAME", SqlDbType.NVarChar, 50, columnAttributes.Name);
            SqlParameter phoneParam = new SqlParameter("@PHONE", SqlDbType.NVarChar, 15, columnAttributes.Phone);
            SqlParameter emailParam = new SqlParameter("@EMAIL", SqlDbType.NVarChar, 50, columnAttributes.Email);
            SqlParameter refnumParam = new SqlParameter("@REFERENCENUMBER", SqlDbType.NVarChar, 20, columnAttributes.ReferenceNumber);
            SqlParameter addressParam = new SqlParameter("@ADDRESS", SqlDbType.NVarChar, 100, columnAttributes.Address);
            SqlParameter balanceParam = new SqlParameter("@BALANCE", SqlDbType.Float, 8, columnAttributes.Balance);


            switch (table) // for different tables
            {
                case tableGuest:
                    switch (operation) // for different operations on table
                    {
                        case DBOperation.Add:
                            daMain.InsertCommand.Parameters.Add(intIdParam);
                            daMain.InsertCommand.Parameters.Add(guestAccountParam);
                            daMain.InsertCommand.Parameters.Add(nameParam);
                            daMain.InsertCommand.Parameters.Add(phoneParam);
                            daMain.InsertCommand.Parameters.Add(emailParam);
                            daMain.InsertCommand.Parameters.Add(addressParam);
                            break;

                        case DBOperation.Edit:
                            intIdParam.SourceVersion = DataRowVersion.Original;
                            daMain.UpdateCommand.Parameters.Add(intIdParam);
                            nameParam.SourceVersion = DataRowVersion.Current;
                            daMain.UpdateCommand.Parameters.Add(nameParam);
                            phoneParam.SourceVersion = DataRowVersion.Current;
                            daMain.UpdateCommand.Parameters.Add(phoneParam);
                            emailParam.SourceVersion = DataRowVersion.Current;
                            daMain.UpdateCommand.Parameters.Add(emailParam);
                            addressParam.SourceVersion = DataRowVersion.Current;
                            daMain.UpdateCommand.Parameters.Add(addressParam);
                            break;

                        case DBOperation.Delete:
                            daMain.DeleteCommand.Parameters.Add(intIdParam);
                            break;
                    }
                    break;

                case tableGuestAccount:
                    switch (operation)
                    {
                        case DBOperation.Add:
                            daMain.InsertCommand.Parameters.Add(guestIdParam);
                            daMain.InsertCommand.Parameters.Add(balanceParam);
                            break;

                        case DBOperation.Edit:
                            guestIdParam.SourceVersion = DataRowVersion.Original;
                            daMain.UpdateCommand.Parameters.Add(guestIdParam);
                            balanceParam.SourceVersion = DataRowVersion.Current;
                            daMain.UpdateCommand.Parameters.Add(balanceParam);
                            break;

                        case DBOperation.Delete:
                            daMain.DeleteCommand.Parameters.Add(guestIdParam);
                            break;
                    }
                    break;

                case tableRefNum:
                    switch (operation)
                    {
                        case DBOperation.Add:
                            daMain.InsertCommand.Parameters.Add(refnumIdParam);
                            daMain.InsertCommand.Parameters.Add(refnumParam);
                            daMain.InsertCommand.Parameters.Add(guestIdParam);
                            break;

                        case DBOperation.Edit:
                            refnumIdParam.SourceVersion = DataRowVersion.Original;
                            daMain.UpdateCommand.Parameters.Add(refnumIdParam);
                            refnumParam.SourceVersion = DataRowVersion.Current;
                            daMain.UpdateCommand.Parameters.Add(refnumParam);
                            break;

                        case DBOperation.Delete:
                            daMain.DeleteCommand.Parameters.Add(refnumIdParam);
                            break;
                    }
                    break;
            }
            
        }

        private string CreateCommand(DBOperation operation, string table)
        {
            switch (table)
            {
                case tableGuest:
                    switch (operation)
                    {
                        case DBOperation.Add:
                            daMain.InsertCommand = new SqlCommand("INSERT into " + tableGuest +
                                " (" + columnAttributes.ID + ", " +
                                columnAttributes.GuestAccountNumber + ", " +
                                columnAttributes.Name + ", " +
                                columnAttributes.Phone + ", " +
                                columnAttributes.Email + ", " +
                                columnAttributes.Address + ")" +
                                " VALUES (@ID, @GUESTACCOUNTNUMBER, @NAME, @PHONE, @EMAIL, @ADDRESS)",
                                cnMain);
                            break;

                        case DBOperation.Edit:
                            daMain.UpdateCommand = new SqlCommand("UPDATE " + tableGuest +
                                " SET " +
                                columnAttributes.Name + " =@NAME, " +
                                columnAttributes.Phone + " =@PHONE, " +
                                columnAttributes.Email + " =@EMAIL, " +
                                columnAttributes.Address + " =@ADDRESS " +
                                "WHERE " +
                                columnAttributes.ID + " = @ID",
                                cnMain);
                            break;

                        case DBOperation.Delete:
                            daMain.DeleteCommand = new SqlCommand("DELETE FROM " + tableGuest +
                                " WHERE " + columnAttributes.ID + " = @ID", cnMain);
                            break;
                    }
                    break;

                case tableGuestAccount:
                    switch (operation)
                    {
                        case DBOperation.Add:
                            daMain.InsertCommand = new SqlCommand("INSERT into " + tableGuestAccount +
                                " (" + columnAttributes.ID + ", " +
                                columnAttributes.Balance + ")" +
                                " VALUES (@GUESTID, @BALANCE)",
                                cnMain);
                            break;

                        case DBOperation.Edit:
                            daMain.UpdateCommand = new SqlCommand("UPDATE " + tableGuestAccount +
                                " SET " +
                                columnAttributes.Balance + " =@BALANCE " +
                                "WHERE " +
                                columnAttributes.ID + " = @GUESTID",
                                cnMain);
                            break;

                        case DBOperation.Delete:
                            daMain.DeleteCommand = new SqlCommand("DELETE FROM " + tableGuestAccount +
                                " WHERE " + columnAttributes.ID + " = @GUESTID", cnMain);
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
                                columnAttributes.GuestID + ")" +
                                " VALUES (@REFERENCENUMBERID, @REFERENCENUMBER, @GUESTID)",
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
            
            string errorstring = "";
            try
            {
                BuildParameters(operation, table);
            }
            catch (Exception exception)
            {
                errorstring = exception.Message + " " + exception.StackTrace;
            }

            return errorstring;
        }

        private void FillRow(DataRow aRow, Guest guest, DB.DBOperation operation, string table)
        {
            //NOTE square brackets to indicate index of collections of fields in row.
            switch (table)
            {
                case tableGuest:
                    if (operation == DB.DBOperation.Add)
                    {
                        aRow[columnAttributes.ID] = guest.ID;
                        aRow[columnAttributes.GuestAccountNumber] = guest.GuestAccountNumber;
                    }
                    aRow[columnAttributes.Name] = guest.Name;
                    aRow[columnAttributes.Phone] = guest.PhoneNumber;
                    aRow[columnAttributes.Email] = guest.Email;
                    aRow[columnAttributes.Address] = guest.Address;
                    break;

                case tableGuestAccount:
                    // id of GuestAccunt table is GuestAccountNumber
                    if (operation == DB.DBOperation.Add) aRow[columnAttributes.ID] = guest.GuestAccountNumber;
                    aRow[columnAttributes.Balance] = guest.Balance;
                    break;

                case tableRefNum:
                    if (operation == DB.DBOperation.Add) aRow[columnAttributes.ID] = guest.MyReferenceNumberDetails.ID;
                    aRow[columnAttributes.ReferenceNumber] = guest.MyReferenceNumberDetails.ReferenceNumber;
                    aRow[columnAttributes.GuestID] = guest.ID;
                    break;
            }
            
        }

        public bool UpdateDataSource(DBOperation operation)
        {
            // NB: first update GuestAccount table
            bool guestSuccess = false, guestAccountSuccess = false, refNumSuccess = false;
            try
            {
                switch (operation)
                {
                    case DBOperation.Delete:
                        CreateCommand(DBOperation.Add, tableRefNum);
                        CreateCommand(DBOperation.Edit, tableRefNum);
                        CreateCommand(DBOperation.Delete, tableRefNum);
                        refNumSuccess = UpdateDataSource(sqlLocalRefNum, tableRefNum);
                        CreateCommand(DBOperation.Add, tableGuest);
                        CreateCommand(DBOperation.Edit, tableGuest);
                        CreateCommand(DBOperation.Delete, tableGuest);
                        guestSuccess = UpdateDataSource(sqlLocalGuest, tableGuest);
                        CreateCommand(DBOperation.Add, tableGuestAccount);
                        CreateCommand(DBOperation.Edit, tableGuestAccount);
                        CreateCommand(DBOperation.Delete, tableGuestAccount);
                        guestAccountSuccess = UpdateDataSource(sqlLocalGuestAccount, tableGuestAccount);
                        break;

                    default:
                        CreateCommand(DBOperation.Add, tableGuestAccount);
                        CreateCommand(DBOperation.Edit, tableGuestAccount);
                        CreateCommand(DBOperation.Delete, tableGuestAccount);
                        guestAccountSuccess = UpdateDataSource(sqlLocalGuestAccount, tableGuestAccount);
                        CreateCommand(DBOperation.Add, tableGuest);
                        CreateCommand(DBOperation.Edit, tableGuest);
                        CreateCommand(DBOperation.Delete, tableGuest);
                        guestSuccess = UpdateDataSource(sqlLocalGuest, tableGuest);
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
                MessageBox.Show(exc.Message + "  " + exc.StackTrace);
                return false;
            }

            return guestSuccess && guestAccountSuccess;
        }
        #endregion
    }
}
