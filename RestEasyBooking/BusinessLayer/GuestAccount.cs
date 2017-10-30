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
        private double _totalBalance;
        private Collection<string> referenceNumbers;

        public GuestAccount()
        {
            _totalBalance = 0;
            referenceNumbers = new Collection<string>();
        }

        public double Payment(double amount, string refNum)
        {
            referenceNumbers.Add(refNum);
            _totalBalance -= amount;
            return _totalBalance;
        }
    }
}
