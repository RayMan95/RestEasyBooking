using RestEasyBooking.DatabaseLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RestEasyBooking.BusinessLayer
{
    public class BookingController
    {
        Collection<Booking> allBookings;
        BookingDB bookingDB;

        public BookingController()
        {
            allBookings = new Collection<Booking>();
            bookingDB = new BookingDB();
            allBookings = bookingDB.AllBookings;
        }

        #region Database Communication
        public bool DataMaintenance(Booking booking, DB.DBOperation operation)
        {
            //perform a given database operation to the dataset in meory; 
            bookingDB.DataSetChange(booking, operation);
            //perform operations on the collection
            try
            {
                switch (operation)
                {
                    case DB.DBOperation.Add:
                        allBookings.Add(booking);
                        break;
                    case DB.DBOperation.Edit:
                        allBookings[FindIndex(booking)] = booking;
                        break;
                    case DB.DBOperation.Delete:
                        allBookings.RemoveAt(FindIndex(booking));
                        break;
                }

                return bookingDB.UpdateDataSource(operation); // commit changes
            }
            catch (Exception exception)
            {
                // TODO formatting
                String errorstring = exception.Message + " " + exception.StackTrace;
                MessageBox.Show(errorstring);
                return false;
            }
        }
        #endregion

        #region Utility Methods
        public Collection<Booking> FindByDate(DateTime startDate, DateTime endDate)
        {
            Collection<Booking> bookings = new Collection<Booking>();

            foreach (Booking booking in allBookings)
            {
                if (booking.StartDate == startDate && booking.EndDate == endDate)
                    bookings.Add(booking);
            }

            return bookings;
        }

        public Booking FindByID(int Id)
        {
            for (int i = 0; i < allBookings.Count; ++i)
            {
                if (allBookings[i].ID == Id) return allBookings[i];
            }

            return null;
        }

        public int FindIndex(Booking booking)
        {
            int counter = 0;
            bool found = false;
            found = (booking.ID == allBookings[counter].ID);   //using a Boolean Expression to initialise found
            while (!(found) & counter < allBookings.Count - 1)
            {
                counter += 1;
                found = (booking.ID == allBookings[counter].ID);
            }
            if (found) return counter;
            else return -1;
        }
        #endregion
    }

}
