using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestEasyBooking.BusinessLayer
{
    public class Room : Entity
    {
        private bool occupied;
        private Season _season;

        #region Properties
        public Season CurrentSeason
        {
            get { return _season; }
            //set { _season = value; }
        }

        public bool Occupied
        {
            get { return occupied; }
        }
        #endregion

        public Room(Season season)
        {
            occupied = false;
            _season = season;
        }

        public void Occupy()
        {
            occupied = true;
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
