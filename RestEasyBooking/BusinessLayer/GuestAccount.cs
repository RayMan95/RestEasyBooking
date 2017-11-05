using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestEasyBooking.BusinessLayer
{
    public class GuestAccount : Entity
    {
        private string _guestAccountNumber;
        private double _totalBalance;
        

        #region Properties
        public string AccountNumber
        {
            get { return _guestAccountNumber; }
        }

        public double Balance
        {
            get { return _totalBalance; }
        }
        #endregion

        public GuestAccount(string guestAccountNumber, double amount)
        {
            _guestAccountNumber = guestAccountNumber;
            _totalBalance = amount;
        }

        public double Payment(double amount)
        {
            _totalBalance -= amount;
            return _totalBalance;
        }
    }
}
