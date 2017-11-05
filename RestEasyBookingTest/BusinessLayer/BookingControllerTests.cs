using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestEasyBooking.BusinessLayer;
using RestEasyBooking.DatabaseLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestEasyBooking.BusinessLayer.Tests
{
    [TestClass()]
    public class BookingControllerTests
    {
        [TestMethod()]
        public void BookingControllerTest()
        {
            BookingController bookingController = new BookingController();
            #region Adding
            int bookingID = 222;
            DateTime startDate = new DateTime(2017, 12, 16);
            DateTime endDate = new DateTime(2017, 12, 17);
            int roomID = 2;
            double balance = 2;
            bool paidDeposit = true;
            Entity.GuestDetails guestDetails = new Entity.GuestDetails()
            {
                ID = 90,
                AccountNumber = "g73"
            };
            string referenceNumber = "r222";
            Entity.ReferenceNumberDetails referenceNumberDetails = new Entity.ReferenceNumberDetails()
            {
                ID = 222,
                ReferenceNumber = referenceNumber
            };

            Booking booking = new Booking(bookingID, startDate, endDate, roomID, balance, paidDeposit)
            {
                MyGuestDetails = guestDetails,
                MyReferenceNumberDetails = referenceNumberDetails
            };

            Assert.IsNull(bookingController.FindByID(bookingID)); // does not exist

            bookingController.DataMaintenance(booking, DB.DBOperation.Add);

            Booking sameBooking = bookingController.FindByID(bookingID);

            Assert.IsNotNull(sameBooking);

            Assert.AreEqual(sameBooking.ID, bookingID);
            Assert.AreEqual(sameBooking.StartDate, startDate);
            Assert.AreEqual(sameBooking.EndDate, endDate);
            Assert.AreEqual(sameBooking.RoomID, roomID);
            Assert.AreEqual(sameBooking.Balance, balance);
            Assert.AreEqual(sameBooking.PaidDeposit, paidDeposit);
            Assert.AreEqual(sameBooking.MyReferenceNumberDetails.ReferenceNumber, referenceNumber);
            #endregion

            #region Edit
            
            DateTime newstartDate = new DateTime(2017, 12, 17);
            DateTime newendDate = new DateTime(2017, 12, 18);
            int newroomID = 3;
            double newbalance = 3;
            bool newpaidDeposit = false;
            string newreferenceNumber = "r333";
            Entity.ReferenceNumberDetails newreferenceNumberDetails = new Entity.ReferenceNumberDetails()
            {
                ID = 222,
                ReferenceNumber = newreferenceNumber
            };

            booking = new Booking(bookingID, newstartDate, newendDate, newroomID, newbalance, newpaidDeposit)
            {
                MyGuestDetails = guestDetails,
                MyReferenceNumberDetails = newreferenceNumberDetails
            };

            bookingController.DataMaintenance(booking, DB.DBOperation.Edit);

            Booking updatedBooking = bookingController.FindByID(bookingID);

            Assert.IsNotNull(updatedBooking);

            Assert.AreEqual(updatedBooking.ID, bookingID);
            Assert.AreEqual(updatedBooking.StartDate, newstartDate);
            Assert.AreEqual(updatedBooking.EndDate, newendDate);
            Assert.AreEqual(updatedBooking.RoomID, newroomID);
            Assert.AreEqual(updatedBooking.Balance, newbalance);
            Assert.AreEqual(updatedBooking.PaidDeposit, newpaidDeposit);
            Assert.AreEqual(updatedBooking.MyReferenceNumberDetails.ReferenceNumber, newreferenceNumber);

            #endregion

            #region Delete

            bookingController.DataMaintenance(updatedBooking, DB.DBOperation.Delete);

            Booking deletedBooking = bookingController.FindByID(bookingID);

            Assert.IsNull(deletedBooking);

            #endregion
        }
    }
}