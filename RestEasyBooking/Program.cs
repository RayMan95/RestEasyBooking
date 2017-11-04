using RestEasyBooking.BusinessLayer;
using RestEasyBooking.DatabaseLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RestEasyBooking
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());
            GuestDB guestDB = new GuestDB();
            BookingDB bookingDB = new BookingDB();

            Collection<Booking> allBookings = bookingDB.AllBookings;
            Collection<Guest> allGuests = guestDB.AllGuests;

            int bookingID = 3;
            DateTime startDate = new DateTime(2017, 11, 30);
            DateTime endDate = new DateTime(2017, 12, 2);
            int roomID = 5;
            double balance = 1000;
            bool paidDeposit = true;
            GuestDetails guestDetails = new GuestDetails()
            {
                ID = 1,
                AccountNumber = "g1"
            };

            ReferenceNumberDetails referenceNumberDetails = new ReferenceNumberDetails()
            {
                ID = 1,
                ReferenceNumber = "r1"
            };

            Booking booking = new Booking(bookingID, startDate, endDate, roomID, balance, paidDeposit)
            {
                GuestDetails = guestDetails,
                ReferenceNumberDetails = referenceNumberDetails
            };



            //bookingDB.DataSetChange(booking, DB.DBOperation.Delete);
            //bookingDB.UpdateDataSource();

            Console.WriteLine("YES");
        }
    }
}
