using RestEasyBooking.BusinessLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
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
                    
                    string name = "", phone = "", email= "", address = "", guestAccountNumber = "";
                    
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
                                    guestAcc.AddReferenceNumber(new ReferenceNumberDetails() { ID = refId, ReferenceNumber = refNum });
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
    }
}
