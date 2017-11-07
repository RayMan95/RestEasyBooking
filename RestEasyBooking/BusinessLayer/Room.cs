using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestEasyBooking.BusinessLayer
{
    public class Room : Entity
    {
        private int id;
        Collection<DateTime> bookedDays;

        #region Properties
        public int ID
        {
            get { return id; }
        }

        //public bool Occupied
        //{
        //    get { return occupied; }
        //}
        #endregion

        public Room(int Id)
        {
            //occupied = false;
            id = Id;
            bookedDays = new Collection<DateTime>();
        }

        public void Book(DateTime startDate, DateTime endDate)
        {
            while (startDate.Day < endDate.Day)
            {
                bookedDays.Add(startDate);
                startDate =startDate.AddDays(1);
            }
        }

        public bool Occupied(DateTime startDate, DateTime endDate)
        {
            foreach (DateTime bookedDate in bookedDays)
            {
                if (bookedDate.Day >= startDate.Day && bookedDate.Day <= endDate.Day)
                    return true;
            }

            return false;
        }

        public bool Occupied(DateTime date)
        {
            foreach (DateTime bookedDate in bookedDays)
            {
                if (bookedDate == date) return true;
            }

            return false;
        }
    }
}
