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

        

        protected override void PopulateCollections()
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
                        //double amount = Convert.ToInt32(dsMain.Tables[tableGuestAccount].Select(filterExpression: "Id=" + GuestAccountNumber)[0].ItemArray[1]);
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

                        //READ from ReferenceNumber table
                        foreach (DataRow myRow_loopVariable2 in dsMain.Tables[tableRefNum].Rows)
                        {
                            myRow = myRow_loopVariable2;
                            if (!(myRow.RowState == DataRowState.Deleted))
                            {
                                if (Convert.ToInt32(myRow[columnAttributes.GuestID]) == id)
                                {
                                    int refId = Convert.ToInt32(myRow[columnAttributes.ID]);
                                    string refNum = Convert.ToString(myRow[columnAttributes.ReferenceNumber]).TrimEnd();
                                    // Add all reference numbers
                                    guestAcc.AddReferenceNumber(new ReferenceNumberDetails()
                                        {
                                            ID = refId,
                                            ReferenceNumber = refNum
                                        }
                                    );
                                }
                            }
                        }

                        guest = new Guest(id, guestAccountNumber, name, phone, email, address)
                        {
                            guestAccount = guestAcc
                        };

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
                    aRow = dsMain.Tables[tableGuest].NewRow();
                    FillRow(aRow, guest, operation);
                    //Add to the dataset
                    dsMain.Tables[tableGuest].Rows.Add(aRow);
                    break;

                case DBOperation.Edit:
                    aRow = FindFromTableByPrimaryKey(tableGuest, guest.ID);
                    if (aRow == null) return false;
                    else FillRow(aRow, guest, operation);
                    break;

                case DBOperation.Delete:
                    aRow = FindFromTableByPrimaryKey(tableGuest, guest.ID);
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
                    idParam = new SqlParameter("@GUESTACCOUNTNUMBER", SqlDbType.NVarChar, 10, columnAttributes.GuestAccountNumber);
                    daMain.InsertCommand.Parameters.Add(idParam);
                }

                SqlParameter startDateParam = new SqlParameter("@NAME", SqlDbType.NVarChar, 50, columnAttributes.Name);
                SqlParameter enDateParam = new SqlParameter("@PHONE", SqlDbType.NVarChar, 15, columnAttributes.Phone);
                SqlParameter refnumIdParam = new SqlParameter("@EMAIL", SqlDbType.NVarChar, 50, columnAttributes.Email);
                SqlParameter roomIdParam = new SqlParameter("@ADDRESS", SqlDbType.NVarChar, 100, columnAttributes.Address);

                switch (operation)
                {
                    case DBOperation.Add:
                        daMain.InsertCommand.Parameters.Add(startDateParam);
                        daMain.InsertCommand.Parameters.Add(enDateParam);
                        daMain.InsertCommand.Parameters.Add(refnumIdParam);
                        daMain.InsertCommand.Parameters.Add(roomIdParam);
                        break;

                    case DBOperation.Edit:
                        daMain.UpdateCommand.Parameters.Add(startDateParam);
                        daMain.UpdateCommand.Parameters.Add(enDateParam);
                        daMain.UpdateCommand.Parameters.Add(refnumIdParam);
                        daMain.UpdateCommand.Parameters.Add(roomIdParam);
                        break;
                }
            }
        }

        private string CreateCommand(DBOperation operation)
        {
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
                        columnAttributes.Address + " =@ADDRESS, " +
                        "WHERE " +
                        columnAttributes.ID + "=@ID",
                        cnMain);
                    break;

                case DBOperation.Delete:
                    daMain.DeleteCommand = new SqlCommand("DELETE FROM " + tableGuest +
                        " WHERE " + columnAttributes.ID + "=@ID", cnMain);
                    break;
            }
            string errorstring = "";
            try
            {
                BuildParameters(operation);
            }
            catch (Exception exception)
            {
                errorstring = exception.Message + " " + exception.StackTrace;
            }

            return errorstring;
        }

        private void FillRow(DataRow aRow, Guest guest, DB.DBOperation operation)
        {
            //NOTE square brackets to indicate index of collections of fields in row.
            if (operation == DB.DBOperation.Add)
            {
                aRow[columnAttributes.ID] = guest.ID;
                aRow[columnAttributes.GuestAccountNumber] = guest.GuestAccountNumber;
            }
            aRow[columnAttributes.Name] = guest.Name;
            aRow[columnAttributes.Phone] = guest.PhoneNumber;
            aRow[columnAttributes.Email] = guest.Email;
            aRow[columnAttributes.Address] = guest.Address;
        }

        public bool UpdateDataSource()
        {
            //bool success = true;
            CreateCommand(DBOperation.Add);
            CreateCommand(DBOperation.Edit);
            CreateCommand(DBOperation.Delete);
            return UpdateDataSource(sqlLocalGuest, tableGuest);
        }
        #endregion
    }
}
