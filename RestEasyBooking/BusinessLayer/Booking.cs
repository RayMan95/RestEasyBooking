using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestEasyBooking.BusinessLayer
{
    class Booking
    {
        private uint _id;
        private DateTime startDate;
        private DateTime endDate;
        private string referenceNumber;
        private uint roomID;
        private long guestAccountNumber;

        #region Properties
        public uint ID
        {
            get { return _id; }
        }

        public DateTime StartDate
        {
            get { return startDate; }
        }

        public DateTime EndDate
        {
            get { return endDate; }
        }

        public uint RoomNumber
        {
            get { return roomID + 1; }
        }

        public string ReferenceNumber
        {
            get { return referenceNumber; }
        }

        public long GuestAccountNumber
        {
            get { return guestAccountNumber; }
            set { guestAccountNumber = value; }
        }
        #endregion

        public Booking(uint id, DateTime start, DateTime end, uint room_id, long guest_acc_num)
        {
            _id = id;
            startDate = start;
            endDate = end;
            roomID = room_id;
            guestAccountNumber = guest_acc_num;
        }
    }
}
