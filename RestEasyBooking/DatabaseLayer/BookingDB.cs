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

                    booking = new Booking(id, new DateTime(), new DateTime(), roomId, guestAccountNumber, balance, paidDeposit);
                    booking.ReferenceNumber = refNumber;

                    allBookings.Add(booking);
                }
            }
        }
    }
}
