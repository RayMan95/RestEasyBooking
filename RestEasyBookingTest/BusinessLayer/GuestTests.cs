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
    public class GuestTests
    {
        [TestMethod()]
        public void GuestTest()
        {
            int id = 666;
            GuestAccount guestAccount = new GuestAccount("g666", 666);
            string name = "666";
            string phoneNum = "666";
            string email = "666@gmail.com";
            string address = "666 Devils Lane, Hell, -1";

            Guest guest = new Guest(id, guestAccount, name, phoneNum, email, address);
        }

        [TestMethod()]
        public void AddBookingTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void RemoveBookingAtTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void PaymentTest()
        {
            Assert.Fail();
        }
    }
}