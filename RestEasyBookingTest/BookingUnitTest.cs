using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestEasyBooking.BusinessLayer;
using System;

namespace RestEasyBookingTest
{
    [TestClass]
    public class BookingUnitTest
    {
        [TestMethod]
        public void TestCreationAndProperties()
        {
            // Details
            int bookingID = 3;
            DateTime startDate = new DateTime(2017, 11, 30);
            DateTime endDate = new DateTime(2017, 12, 1);
            int roomID = 3;
            double balance = 1000;
            bool paidDeposit = true;

            Booking booking = new Booking(bookingID, startDate, endDate, roomID, balance, paidDeposit);

            Assert.AreEqual(booking.ID, bookingID);
            Assert.AreEqual(booking.StartDate, startDate);
            Assert.AreEqual(booking.EndDate, endDate);
            Assert.AreEqual(booking.RoomID, roomID);
            Assert.AreEqual(booking.Balance, balance);
            Assert.AreEqual(booking.PaidDeposit, paidDeposit);
        }
    }
}
