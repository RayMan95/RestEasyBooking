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
        private int bookID;
        private DateTime startDate;
        private DateTime endDate;
        private string referenceNumber;
        private int roomID;
        private string guestAccountNumber;

        private double balance;
        private bool paidDeposit;

        #region Properties
        public int ID
        {
            get { return _id; }
        }

        public int BookID
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
            set { referenceNumber = value; }
        }

        public string GuestAccountNumber
        {
            get { return guestAccountNumber; }
            set { guestAccountNumber = value; }
        }
        #endregion

        public Booking(int id, DateTime start, DateTime end, int room_id, string guest_acc_num, 
            double curr_balance, bool paidDep)
        {
            _id = id;
            startDate = start;
            endDate = end;
            roomID = room_id;
            guestAccountNumber = guest_acc_num;

            balance = curr_balance;
            paidDeposit = paidDep;
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
