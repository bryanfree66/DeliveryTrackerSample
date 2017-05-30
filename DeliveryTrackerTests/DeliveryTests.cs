using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DeliveryTracker.Tests
{
    [TestClass]
    public class DeliveryTests
    {
        private int expectedTrackingNumberLength = 10;
        private DateTime expectedScheduledDepartureTime = DateTime.Now.AddHours(5);
        DeliveryFactoryImpl deliveryFactory = new DeliveryFactoryImpl();
        int actualLocalMiles = 50;
        int actualLongDistanceMiles = 175;
        int localMilesTraveledPerHour = 20;
        int longDistanceMilesTraveledPerHour = 50;

        // Departure Time Tests

        [TestMethod]
        public void CanSetAndGetDeliveryDepartureTime()
        {
            var delivery = deliveryFactory.CreateDelivery(actualLocalMiles);
            var scheduledDepartureTime = DateTime.Now.AddHours(5);
            delivery.SetDepartureTime(scheduledDepartureTime);
            var actualScheduledDepartureTime = delivery.GetDepartureTime();
            Assert.AreEqual(expectedScheduledDepartureTime.Hour, actualScheduledDepartureTime.Hour);
        }

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentException))]
        public void SettingDepatureTimeInThePastCausesArgumentException()
        {
            var delivery = deliveryFactory.CreateDelivery(actualLocalMiles);
            var scheduledDepartureTime = DateTime.Today.AddYears(-1);
            delivery.SetDepartureTime(scheduledDepartureTime);
        }

        [TestMethod]
        [ExpectedException(typeof(System.ApplicationException))]
        public void DeliveryNotYetScheduledCausesApplicationException()
        {
            var delivery = deliveryFactory.CreateDelivery(actualLocalMiles);
            var actual = delivery.GetDepartureTime();
        }

        // Tracking Number Tests

        [TestMethod]
        public void CanSetAndGetTrackingNumber()
        {
            var delivery = deliveryFactory.CreateDelivery(actualLocalMiles);
            var actualTrackingNumber = delivery.GetTrackingNumber();
            Assert.AreEqual(expectedTrackingNumberLength, actualTrackingNumber.Length);
        }

        // Delivery Time Tests
        [TestMethod]
        public void CanCalculateLocalDeliveryTime()
        {
            var delivery = deliveryFactory.CreateDelivery(actualLocalMiles);
            double expectedDeliveryTime = Math.Round((double)actualLocalMiles / localMilesTraveledPerHour, 2);
            double actualDeliveryTime = delivery.CalculateDeliveryTimeInHoursAndHundredths();
            Assert.AreEqual(expectedDeliveryTime, actualDeliveryTime);
        }

        [TestMethod]
        public void CanCalculateLongDistanceDeliveryTime()
        {
            var delivery = deliveryFactory.CreateDelivery(actualLongDistanceMiles);
            double expectedDeliveryTime = Math.Round((double)actualLongDistanceMiles / longDistanceMilesTraveledPerHour, 2);
            double actualDeliveryTime = delivery.CalculateDeliveryTimeInHoursAndHundredths();
            Assert.AreEqual(expectedDeliveryTime, actualDeliveryTime);
        }
    }
}
