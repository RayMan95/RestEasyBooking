using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestEasyBooking.BusinessLayer
{
    class Room
    {
        public enum Season
        {
            Low = 0,
            Mid = 1,
            High = 2
        }

        private bool occupied;
        private Season _season;

        #region Properties
        public Season season
        {
            get { return _season; }
            set { _season = value; }
        }
        #endregion

        public Room()
        {
            occupied = false;
        }

        public int GetPrice()
        {
            if (_season == Season.Low)
            {
                return 550;
            }
            else if (_season == Season.Mid)
            {
                return 750;
            }
            else
            {
                return 995;
            }
        }
    }
}
