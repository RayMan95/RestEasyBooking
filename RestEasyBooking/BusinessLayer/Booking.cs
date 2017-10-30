using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestEasyBooking.BusinessLayer
{
    class Booking
    {
        private int _id;
        private DateTime startDate;
        private DateTime endDate;
        private string referenceNumber;
        private int roomID;
        private long guestAccountNumber;

        private double balance;
        private bool paidDeposit;

        #region Properties
        public int ID
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

        public int RoomNumber
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

        public Booking(int id, DateTime start, DateTime end, int room_id, long guest_acc_num, 
            double cost)
        {
            _id = id;
            startDate = start;
            endDate = end;
            roomID = room_id;
            guestAccountNumber = guest_acc_num;

            balance = cost;
            paidDeposit = false;
        }

        public double Payment(double amount, bool deposit)
        {
            if (deposit)
            {
                paidDeposit = true; // assumes full payment
                balance -= amount;
            }
            else balance -= amount;

            return balance;
        }
    }
}
