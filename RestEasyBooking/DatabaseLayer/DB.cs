using RestEasyBooking.Properties;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RestEasyBooking.DatabaseLayer
{
    public class DB
    {
        private string strConn = Settings.Default.RestEasyBookingConnectionString;
        protected SqlConnection cnMain;
        protected DataSet dsMain;
        protected SqlDataAdapter daMain;

        //Data members
        protected const string tableGuest = "Guest";
        protected const string sqlLocalGuest = "SELECT * FROM Guest";
        protected const string tableGuestAccount = "GuestAccount";
        protected const string sqlLocalGuestAccount = "SELECT * FROM GuestAccount";
        protected const string tableRefNum = "ReferenceNumber";
        protected const string sqlLocalRefNum = "SELECT * FROM ReferenceNumber";
        protected const string tableBooking = "Booking";
        protected const string sqlLocalBooking = "SELECT * FROM Booking";

        #region Properties

        public string TableGuest
        {
            get { return tableGuest; }
        }

        public string TableGuestAccount
        {
            get { return tableGuestAccount; }
        }

        public string TableBooking
        {
            get { return tableBooking; }
        }

        public string TableReferenceNumber
        {
            get { return tableRefNum; }
        }

        public DataSet DataSet
        {
            get { return dsMain; }
        }
        #endregion

        protected ColumnAttributes columnAttributes;

        protected string aSQLstring;  // to be initialised later
        public enum DBOperation
        {
            Add = 0,
            Edit = 1,
            Delete = 2
        }

        protected struct ColumnAttributes
        {
            public string ID, GuestID, BookID, StartDate, EndDate, ReferenceNumberId, RoomID, 
                Balance, PaidDeposit, GuestAccountNumber, Name, Email, Phone,
                Address, ReferenceNumber;

            public void SetAttributes()
            {
                ID = "Id";
                GuestID = "GuestId";
                BookID = "BookId";
                StartDate = "StartDate";
                EndDate = "EndDate";
                ReferenceNumberId = "ReferenceNumberId";
                RoomID = "RoomID";
                PaidDeposit = "PaidDeposit";
                GuestAccountNumber = "GuestAccountNumber";
                Name = "Name";
                Email = "Email";
                Phone = "Phone";
                Address = "Address";
                Balance = "Balance";
                ReferenceNumber = "ReferenceNumber";
            }
        }

        public DB()
        {
            columnAttributes.SetAttributes();

            try
            {
                //Open a connection & create a new dataset object
                cnMain = new SqlConnection(strConn);
                dsMain = new DataSet();
            }
            catch (SystemException e)
            {
                MessageBox.Show(e.Message, "Error");
                return;
            }
        }

        public virtual void PopulateCollections() { }

        public void FillDataSet(string aSQLstring, string aTable)
        {
            //fills dataset fresh from the db for a specific table and with a specific Query
            try
            {
                daMain = new SqlDataAdapter(aSQLstring, cnMain);
                cnMain.Open();
                //dsMain.Clear();   // need to have all the tables in the dataset
                daMain.Fill(dsMain, aTable);
                cnMain.Close();
            }
            catch (Exception errObj)
            {
                MessageBox.Show(errObj.Message + "  " + errObj.StackTrace);
            }
        }

        protected bool UpdateDataSource(string sqlLocal, string table)
        {
            bool success;
            try
            {
                //open the connection
                cnMain.Open();
                //***update the database table via the data adapter
                daMain.Update(dsMain, table);
                //---close the connection
                cnMain.Close();
                //refresh the dataset
                FillDataSet(sqlLocal, table);
                success = true;
            }
            catch (Exception errObj)
            {
                MessageBox.Show(errObj.Message + "  " + errObj.StackTrace);
                success = false;
            }
            finally
            {
            }
            return success;
        }

        protected DataRow FindFromTableByPrimaryKey(string table, int id, string guestAccountNumber)
        {
            // Has to be primary key to return unique DataRow
            DataRow[] dataRows;
            // GuestAccount table uses string as primary key
            if (table == tableGuestAccount)
            {
                dataRows = dsMain.Tables[table].Select(filterExpression: "Id='" + guestAccountNumber+"'"); // TODO check
                if (dataRows.Length > 0)
                    return dataRows[0];
                else return null;
            }
            else
            {
                dataRows = dsMain.Tables[table].Select(filterExpression: "Id=" + id);
                if (dataRows.Length > 0)
                    return dataRows[0];
                else return null;
            }
            
        }
    }
}
