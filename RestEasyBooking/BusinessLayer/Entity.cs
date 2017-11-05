using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestEasyBooking.BusinessLayer
{
    public abstract class Entity
    {
        #region Structs
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

        #region Enums
        public enum Season
        {
            Low = 0,
            Mid = 1,
            High = 2
        }
        #endregion
    }
}
