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

            

            

            Console.WriteLine("YES");
        }
    }
}
