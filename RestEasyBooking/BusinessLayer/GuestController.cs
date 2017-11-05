using RestEasyBooking.DatabaseLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RestEasyBooking.BusinessLayer
{
    public class GuestController
    {
        private Collection<Guest> allGuests;
        GuestDB guestDB;

        public GuestController()
        {
            guestDB = new GuestDB();
            allGuests = guestDB.AllGuests;
        }

        #region Database Communication
        public bool DataMaintenance(Guest guest, DB.DBOperation operation)
        {
            //perform a given database operation to the dataset in meory; 
            guestDB.DataSetChange(guest, operation);
            //perform operations on the collection
            try
            {
                switch (operation)
                {
                    case DB.DBOperation.Add:
                        allGuests.Add(guest);
                        break;
                    case DB.DBOperation.Edit:
                        allGuests[FindIndex(guest)] = guest;
                        break;
                    case DB.DBOperation.Delete:
                        allGuests.RemoveAt(FindIndex(guest));
                        break;
                }

                return guestDB.UpdateDataSource(operation); // commit changes
            }
            catch (Exception exception)
            {
                // TODO formatting
                String errorstring = exception.Message + " " + exception.StackTrace;
                MessageBox.Show(errorstring);
                return false;
            }
        }
        #endregion

        #region Utility Methods
        public Guest FindByAccountNumber(string accountNumber)
        {
            for (int i = 0; i < allGuests.Count; ++i)
            {
                if (allGuests[i].GuestAccountNumber == accountNumber) return allGuests[i];
            }

            return null;
        }

        public Guest FindByID(int Id)
        {
            for (int i = 0; i < allGuests.Count; ++i)
            {
                if (allGuests[i].ID == Id) return allGuests[i];
            }

            return null;
        }

        public int FindIndex(Guest guest)
        {
            int counter = 0;
            bool found = false;
            found = (guest.ID == allGuests[counter].ID);
            while (!(found) & counter < allGuests.Count - 1)
            {
                counter += 1;
                found = (guest.ID == allGuests[counter].ID);
            }
            if (found) return counter;
            else return -1;
        }
        #endregion
    }
}
