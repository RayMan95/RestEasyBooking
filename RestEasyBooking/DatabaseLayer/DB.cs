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
    class DB
    {
        private string strConn = Settings.Default.RestEasyBookingConnectionString;
        protected SqlConnection cnMain;
        protected DataSet dsMain;
        protected SqlDataAdapter daMain;

        //Data members
        protected string tableGuest = "Guest";
        protected string sqlLocalGuest = "SELECT * FROM Guest";
        protected string tableGuestAccount = "GuestAccount";
        protected string sqlLocalGuestAccount = "SELECT * FROM GuestAccount";
        protected string tableRefNum = "ReferenceNumber";
        protected string sqlLocalRefNum = "SELECT * FROM ReferenceNumber";
        protected string tableBooking = "Booking";
        protected string sqlLocalBooking = "SELECT * FROM ReferenceNumber";

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

        protected virtual void PopulateCollections() { }

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
    }
}
