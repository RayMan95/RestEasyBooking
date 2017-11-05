using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestEasyBooking.BusinessLayer
{
    class Guest
    {
        private string guestAccountNumber;
        private GuestAccount guestAccount;
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

        public string GuestAccountNumber
        {
            get { return guestAccountNumber; }
        }
        #endregion

        public Guest(string accountNumber, string name, string phoneNum, string email, string address)
        {
            guestAccountNumber = accountNumber;
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

        public void setValues(string accountNumber, string name, string phoneNum, string email, string address)
        {
            guestAccountNumber = accountNumber;
            _name = name;
            _phoneNumber = phoneNum;
            _email = email;
            _address = address;
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

        public double Payment(double amount, string ref_num)
        {
            return guestAccount.Payment(amount, ref_num);
        }
    }
}
