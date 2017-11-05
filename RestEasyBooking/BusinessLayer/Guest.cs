using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestEasyBooking.BusinessLayer
{

    public class Guest : Entity
    {
        private int guestID;
        private GuestAccount _guestAccount;
        private ReferenceNumberDetails referenceNumberDetails;
        private string _name;
        private string _phoneNumber;
        private string _email;
        private string _address;

        private Collection<Booking> bookings;

        #region Properties
        public string Name
        {
            get { return _name; }
        }

        public string PhoneNumber
        {
            get { return _phoneNumber; }
        }

        public string Email
        {
            get { return _email; }
        }

        public string Address
        {
            get { return _address; }
        }

        public ReferenceNumberDetails MyReferenceNumberDetails
        {
            get { return referenceNumberDetails; }
            set { referenceNumberDetails = value; }
        }

        public string GuestAccountNumber
        {
            get { return _guestAccount.AccountNumber; }
        }

        public double Balance
        {
            get { return _guestAccount.Balance; }
        }

        public int ID
        {
            get { return guestID; }
        }
        #endregion

        public Guest(int guestid, GuestAccount guestAcc, string name, string phoneNum, string email, string address)
        {
            guestID = guestid;
            _guestAccount = guestAcc;
            _name = name;
            _phoneNumber = phoneNum;
            _email = email;
            _address = address;
            bookings = new Collection<Booking>();
        }

        public void AddBooking(Booking newBooking)
        {
            bookings.Add(newBooking);
        }

        /**
         * 
         * 
         */
        public bool RemoveBookingAt(int bookingID)
        {

            if (bookings.Count == 0) return false;

            int index = 0;
            foreach (Booking b in bookings) {
                if (b.ID == bookingID)
                {
                    
                    break;
                }
                else ++index;
            }

            if (bookings.Count == index) return false;
            else
            {
                bookings.RemoveAt(index);
                return true;
            }
        }

        public double Payment(double amount, ReferenceNumberDetails ref_num)
        {
            referenceNumberDetails = ref_num;
            return _guestAccount.Payment(amount);
        }
    }
}
