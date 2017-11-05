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
    public class GuestControllerTests
    {
        [TestMethod()]
        public void GuestControllerTest()
        {
            GuestController guestController = new GuestController();
            #region Adding
            int id = 322;
            string guestAccountNumber = "g322";
            double balance = 322;
            GuestAccount guestAccount = new GuestAccount(guestAccountNumber, balance);
            string name = "322";
            string phoneNum = "322";
            string email = "322@GabeN";
            string address = "322 FailFish, Jebaited, 0";
            string referenceNumber = "322";
            Guest guest = new Guest(id, guestAccount, name, phoneNum, email, address)
            {
                MyReferenceNumberDetails = new Entity.ReferenceNumberDetails()
                {
                    ID = id,
                    ReferenceNumber = referenceNumber
                }
            };

            Assert.IsNull(guestController.FindByID(id)); // does not exist

            guestController.DataMaintenance(guest, DB.DBOperation.Add);

            Guest sameGuest = guestController.FindByID(id);

            Assert.IsNotNull(sameGuest);

            Assert.AreEqual(sameGuest.ID, id);
            Assert.AreEqual(sameGuest.GuestAccountNumber, guestAccountNumber);
            Assert.AreEqual(sameGuest.Name, name);
            Assert.AreEqual(sameGuest.PhoneNumber, phoneNum);
            Assert.AreEqual(sameGuest.Email, email);
            Assert.AreEqual(sameGuest.Address, address);
            Assert.AreEqual(sameGuest.Balance, balance);
            Assert.AreEqual(sameGuest.MyReferenceNumberDetails.ReferenceNumber, referenceNumber);
            #endregion

            #region Edit

            string newname = "233";
            string newphoneNum = "233";
            string newemail = "233@goglogo.co.uk";
            string newaddress = "233 HereandThere, Nowhere, 0";
            double newbalance = 223;
            string newreferenceNumber = "r223";
            guestAccount = new GuestAccount(guestAccountNumber, newbalance);

            guest = new Guest(id, guestAccount, newname, newphoneNum, newemail, newaddress)
            {
                MyReferenceNumberDetails = new Entity.ReferenceNumberDetails()
                {
                    ID = id,
                    ReferenceNumber = newreferenceNumber
                }
            };

            guestController.DataMaintenance(guest, DB.DBOperation.Edit);

            Guest updatedGuest = guestController.FindByID(id);

            Assert.IsNotNull(updatedGuest);

            Assert.AreEqual(updatedGuest.ID, id);
            Assert.AreEqual(updatedGuest.GuestAccountNumber, guestAccountNumber);
            Assert.AreEqual(updatedGuest.Name, newname);
            Assert.AreEqual(updatedGuest.PhoneNumber, newphoneNum);
            Assert.AreEqual(updatedGuest.Email, newemail);
            Assert.AreEqual(updatedGuest.Address, newaddress);
            Assert.AreEqual(updatedGuest.Balance, newbalance);
            Assert.AreEqual(updatedGuest.MyReferenceNumberDetails.ReferenceNumber, newreferenceNumber);

            #endregion

            #region Delete

            guestController.DataMaintenance(updatedGuest, DB.DBOperation.Delete);

            Guest deletedBooking = guestController.FindByID(id);

            Assert.IsNull(deletedBooking);

            #endregion
        }
    }
}