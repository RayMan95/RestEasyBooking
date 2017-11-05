using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestEasyBooking.BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            //Assert.Fail();
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