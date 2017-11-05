using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestEasyBooking.BusinessLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DatesTuple = System.Tuple<System.DateTime, System.DateTime>;
using RoomDatesTuple = System.Tuple<int, System.Collections.ObjectModel.Collection<System.Tuple<System.DateTime, System.DateTime>>>;

namespace RestEasyBooking.BusinessLayer.Tests
{
    

    [TestClass()]
    public class RoomControllerTests
    {
        [TestMethod()]
        public void RoomControllerTest()
        {
            RoomController roomController = new RoomController();

            DateTime startDate = new DateTime(2017, 12, 1);
            DateTime endDate = new DateTime(2017, 12, 3);

            Room room = roomController.GetById(1);
            Assert.IsNotNull(room);
            Assert.AreEqual(room.ID, 1);
            Assert.AreEqual(room.Occupied(startDate), false);
            Assert.AreEqual(room.Occupied(startDate, endDate), false);

        }

        [TestMethod()]
        public void RoomsAvailableThroughoutTest()
        {
            //RoomController roomController = new RoomController();

            //DateTime startDate = new DateTime(2017, 12, 1);
            //DateTime endDate = new DateTime(2017, 12, 3);

            //Room room = roomController.GetById(1);
            //Assert.IsNotNull(room);
            //Assert.AreEqual(room.ID, 1);
            //Assert.AreEqual(room.Occupied(date), false);

            //roomController.BookRoom(0, startDate, endDate);

            //Room room = roomController.GetById(1);
            //Assert.IsNotNull(room);
            //Assert.AreEqual(room.ID, 1);
            //Assert.AreEqual(room.Occupied(date), false);
        }

        [TestMethod()]
        public void BookRoomTest()
        {
            RoomController roomController = new RoomController();

            DateTime startDate = new DateTime(2017, 12, 1);
            DateTime endDate = new DateTime(2017, 12, 3);

            Room room = roomController.GetById(0);

            Assert.AreEqual(room.Occupied(startDate), false);
            Assert.AreEqual(room.Occupied(startDate, endDate), false);

            roomController.BookRoom(0, startDate, endDate);

            room = roomController.GetById(0);

            Assert.AreEqual(room.Occupied(startDate), true);
            Assert.AreEqual(room.Occupied(startDate, endDate), true);

            room = roomController.GetById(1);

            Assert.AreEqual(room.Occupied(startDate), false);
            Assert.AreEqual(room.Occupied(startDate, endDate), false);


        }

        [TestMethod()]
        public void SeedRoomsTest()
        {
            RoomController roomController = new RoomController();
            
            DateTime room0StartDate = new DateTime(2017, 12, 01), room0EndDate = new DateTime(2017, 12, 02);
            DateTime room0StartDate1 = new DateTime(2017, 12, 10), room0EndDate1 = new DateTime(2017, 12, 12);
            DateTime room3StartDate = new DateTime(2017, 12, 01), room3EndDate = new DateTime(2017, 12, 05);
            DateTime room5StartDate = new DateTime(2017, 12, 20), room5EndDate = new DateTime(2017, 12, 28);

            DateTime unusedStartDate = new DateTime(2017, 12, 30), unusedEndDate = new DateTime(2017, 12, 31);

            DatesTuple room0BookedDate = new DatesTuple(room0StartDate, room0EndDate);
            DatesTuple room0BookedDate1 = new DatesTuple(room0StartDate1, room0EndDate1);
            DatesTuple room3BookedDate = new DatesTuple(room3StartDate, room3EndDate);
            DatesTuple room5BookedDate = new DatesTuple(room5StartDate, room5EndDate);

            Collection<DatesTuple> room0Bookings = new Collection<DatesTuple>
            {
                room0BookedDate,
                room0BookedDate1
            };
            Collection<DatesTuple> room3Bookings = new Collection<DatesTuple>();
            room0Bookings.Add(room3BookedDate);
            Collection<DatesTuple> room5Bookings = new Collection<DatesTuple>();
            room0Bookings.Add(room5BookedDate);

            RoomDatesTuple room0AndBookings = new RoomDatesTuple(0, room0Bookings);

            RoomDatesTuple room3AndBookings = new RoomDatesTuple(2, room3Bookings);

            RoomDatesTuple room5AndBookings = new RoomDatesTuple(4, room5Bookings);


            Collection<RoomDatesTuple> roomBookings = new Collection<RoomDatesTuple>
            {
                room0AndBookings,
                room3AndBookings,
                room5AndBookings
            };

            roomController.SeedRooms(roomBookings);

            Room room0 = roomController.GetById(0);
            Room room3 = roomController.GetById(2);
            Room room5 = roomController.GetById(4);
            
            Assert.AreEqual(room0.Occupied(room0StartDate, room0EndDate), true);
            Assert.AreEqual(room0.Occupied(unusedStartDate, unusedEndDate), false);

            Assert.AreEqual(room0.Occupied(room0StartDate1, room0EndDate1), true);

            Assert.AreEqual(room3.Occupied(room3StartDate, room3EndDate), true);
            Assert.AreEqual(room0.Occupied(unusedStartDate, unusedEndDate), false);

            Assert.AreEqual(room5.Occupied(room5StartDate, room5EndDate), true);
            Assert.AreEqual(room0.Occupied(unusedStartDate, unusedEndDate), false);
        }

        [TestMethod()]
        public void GetPriceTest()
        {
            //Assert.Fail();
        }

        [TestMethod()]
        public void GetCostTest()
        {
            //Assert.Fail();
        }

        [TestMethod()]
        public void GetByIdTest()
        {
            //Assert.Fail();
        }
    }
}