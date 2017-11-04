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
        private string _guestAccountNumber;
        private double _totalBalance;
        private Collection<ReferenceNumberDetails> referenceNumbers;

        public GuestAccount(string guestAccountNumber, double amount)
        {
            _guestAccountNumber = guestAccountNumber;
            _totalBalance = amount;
            referenceNumbers = new Collection<ReferenceNumberDetails>();
        }

        public void AddReferenceNumber(ReferenceNumberDetails refNum)
        {
            referenceNumbers.Add(refNum);
        }

        public double Payment(double amount, string refNum)
        {
            referenceNumbers.Add(new ReferenceNumberDetails());
            _totalBalance -= amount;
            return _totalBalance;
        }
    }
}
