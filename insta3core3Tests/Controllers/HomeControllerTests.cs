using Microsoft.VisualStudio.TestTools.UnitTesting;
using insta3core3.Controllers;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;

namespace insta3core3.Controllers.Tests
{
    [TestClass()]
    public class HomeControllerTests
    {
        ILogger<HomeController> logger = null;

        [TestMethod()]
        public void HomeControllerTest()
        {
            ILogger<HomeController> logger = null;

        }
        [TestMethod()]
        public void TicketConfirmationTest()
        {
            // arrange
            string usernamePassenger = "Rahul";
            string emailPassenger = "rahul@gmail.com";
            string mobilePassenger = "9512312345";
            string addressPassenger = "Bangalore ,Karnataka";
            string traveDatePassenger = "2020-12-12";
            string traveTimePassenger = "10:00";
            string driverDetails = "Amit";

            // act
            var controller = new HomeController(logger);
            var result = controller.TicketConfirmation(usernamePassenger, emailPassenger, mobilePassenger, addressPassenger, traveDatePassenger, traveTimePassenger, driverDetails) as ViewResult;

            // assert
            Assert.AreEqual("TicketConfirmation", result.ViewName);

        }
        [TestMethod()]
        public void BookingTest()
        {
            // arrange
            string totalKm = "315";
            string destination = "Bangalore ,Karnataka";
            string travelDate = "2020-12-12";
            string rateperKm = "15";
            string driverName = "Amit";

            // act
            var controller = new HomeController(logger);
            var result = controller.Booking(driverName, rateperKm, travelDate, destination, totalKm) as ViewResult;

            // assert
            Assert.AreEqual("Booking", result.ViewName);

        }

        [TestMethod()]
        public void ListingCar()
        {
            // arrange
            string sourceVal = "Bangalore";
            string destinationVal = "Chennai";
            string dateVal = "2020-12-12";
            int distanceVal = 315;

            // act
            var controller = new HomeController(logger);
            var result = controller.ListingCar(sourceVal, destinationVal, dateVal, distanceVal) as PartialViewResult;

            // assert
            Assert.AreEqual("Listing", result.ViewName);

        }
    }
}