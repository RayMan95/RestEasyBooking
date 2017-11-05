using RestEasyBooking.BusinessLayer;
using RestEasyBooking.DatabaseLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

// typedefs for convenience
using DatesTuple = System.Tuple<System.DateTime, System.DateTime>;
using RoomDatesTuple = System.Tuple<int, System.Collections.ObjectModel.Collection<System.Tuple<System.DateTime, System.DateTime>>>;

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
            Collection<RoomDatesTuple> roomBookingSeed = bookingDB.RoomBookingSeed;

            int bookingID = 111;
            DateTime startDate = new DateTime(2017, 11, 30);
            DateTime endDate = new DateTime(2017, 12, 16);
            int roomID = 1;
            double balance = 1;
            bool paidDeposit = true;
            Entity.GuestDetails guestDetails = new Entity.GuestDetails()
            {
                ID = 90,
                AccountNumber = "g73"
            };

            Entity.ReferenceNumberDetails referenceNumberDetails = new Entity.ReferenceNumberDetails()
            {
                ID = 111,
                ReferenceNumber = "r111"
            };

            Booking booking = new Booking(bookingID, startDate, endDate, roomID, balance, paidDeposit)
            {
                MyGuestDetails = guestDetails,
                MyReferenceNumberDetails = referenceNumberDetails
            };

            //int id = 666;
            //GuestAccount guestAccount = new GuestAccount("g666", 6661);
            //string name = "666";
            //string phoneNum = "666";
            //string email = "666@goglogo.co.uk";
            //string address = "666 Devils Lane, Hell, -1";

            //Guest guest = new Guest(id, guestAccount, name, phoneNum, email, address)
            //{
            //    MyReferenceNumberDetails = new Entity.ReferenceNumberDetails()
            //    {
            //        ID = 666,
            //        ReferenceNumber = "r6661"
            //    }
            //};


            DB.DBOperation operation = DB.DBOperation.Add;
            //guestDB.DataSetChange(guest, operation);
            //guestDB.UpdateDataSource(operation);
            bookingDB.DataSetChange(booking, operation);
            bookingDB.UpdateDataSource(operation);

            Console.WriteLine("YES");
        }
    }
}
