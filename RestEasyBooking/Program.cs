using RestEasyBooking.BusinessLayer;
using RestEasyBooking.DatabaseLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

// typedefs for convenience
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

            Console.WriteLine("YES");
        }
    }
}
