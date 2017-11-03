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
            
        }
    }
}
