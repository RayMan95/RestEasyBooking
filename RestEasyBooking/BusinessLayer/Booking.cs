using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestEasyBooking.BusinessLayer
{
    #region
    public struct GuestDetails
    {
        public int ID;
        public string AccountNumber;
    }

    public struct ReferenceNumberDetails
    {
        public int ID;
        public string ReferenceNumber;
    }
    #endregion

    public class Booking
    {
        private int _id;
        private DateTime startDate;
        private DateTime endDate;
        private GuestDetails guestDetails;
        private ReferenceNumberDetails _referenceNumberDetails;
        private int roomID;

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

        public int RoomID
        {
            get { return roomID; }
        }

        public double Balance
        {
            get { return balance; }
        }

        public bool PaidDeposit
        {
            get { return paidDeposit; }
        }

        public ReferenceNumberDetails referenceNumberDetails
        {
            get { return referenceNumberDetails; }
            set { referenceNumberDetails = value; }
        }

        public GuestDetails GuestDetails
        {
            get { return guestDetails; }
            set { guestDetails = value; }
        }
        #endregion

        public Booking(int id, DateTime start, DateTime end, int room_id,
            double curr_balance, bool paidDep)
        {
            _id = id;
            startDate = start;
            endDate = end;
            roomID = room_id;

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
