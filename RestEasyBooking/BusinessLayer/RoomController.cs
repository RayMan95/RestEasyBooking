using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestEasyBooking.DatabaseLayer;

namespace RestEasyBooking.BusinessLayer
{
    public class RoomController
    {
        Collection<Room> allRooms;

        public RoomController()
        {
            allRooms = new Collection<Room>();
            DateTime startingDate = new DateTime(2017, 12, 1);
            DateTime endingDate = new DateTime(2017, 12, 31);

            for (int i = 0; i < 5; ++i)
            {
                allRooms.Add(new Room(i));
            }
        }

        public Collection<Room> RoomsAvailableThroughout(DateTime startDate, DateTime endDate)
        {
            Collection<Room> roomsAvailable = new Collection<Room>();
            
            foreach (Room room in allRooms)
            {
                if (!room.Occupied(startDate, endDate)) roomsAvailable.Add(room);
            }

            return roomsAvailable;
        }

        public bool BookRoom(int Id, DateTime startDate, DateTime endDate)
        {
            // TODO validation
            if (allRooms[Id].Occupied(startDate, endDate)) return false;
            allRooms[Id].Book(startDate, endDate);
            return true;
        }

        public void SeedRooms(Collection<Room> seededRooms, Collection<Collection<Tuple<DateTime, DateTime>>> roomBookings)
        {
            for (int i = 0; i < seededRooms.Count; ++i)
            {
                foreach(Tuple<DateTime, DateTime> datesBooked in roomBookings[i])
                {
                    allRooms[seededRooms[i].ID].Book(datesBooked.Item1, datesBooked.Item2);
                }
            }
        }

        public int GetCost(DateTime startDate, DateTime endDate)
        {
            int cost = 0;
            for(; startDate.Day < endDate.Day; startDate.AddDays(1))
            {
                cost += GetPrice(startDate);
            }

            return cost;
        }

        public int GetPrice(DateTime date)
        {
            if (date.Day > 6 && date.Day <= 14) return 750;
            else if (date.Day > 14) return 995;
            else return 550;
        }

        public Room GetById(int roomId)
        {
            return allRooms[roomId];
        }
    }
}
