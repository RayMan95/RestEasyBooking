using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestEasyBooking.BusinessLayer
{
    class GuestAccount
    {
        private int ID;
        private string _guestAccountNumber;
        private double _totalBalance;
        private Collection<ReferenceNumber> referenceNumbers;

        public GuestAccount(int id, string guestAccountNumber)
        {
            ID = id;
            _guestAccountNumber = guestAccountNumber;
            _totalBalance = 0;
            referenceNumbers = new Collection<ReferenceNumber>();
        }

        public double Payment(double amount, string refNum)
        {
            referenceNumbers.Add(new ReferenceNumber());
            _totalBalance -= amount;
            return _totalBalance;
        }
    }
}
