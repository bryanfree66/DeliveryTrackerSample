using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace DeliveryTracker.Tests
{
    [TestClass]
    public class VehicleTests
    {
        private DeliverySchedule localDeliverySchedule;
        private DeliverySchedule longDistanceDeliverySchedule;
        private double expectedLocalDeliveryTime = 7.50D;
        private double expectedLongDistanceDeliveryTime = 30.02D;

        [TestInitialize]
        public void TestSetup()
        {
            DeliveryFactory deliveryFactory = new DeliveryFactoryImpl();

            // Create some local deliveries
            var localDeliveryList = new List<Delivery>();
            localDeliveryList.Add(deliveryFactory.CreateDelivery(10));
            localDeliveryList.Add(deliveryFactory.CreateDelivery(20));
            localDeliveryList.Add(deliveryFactory.CreateDelivery(30));
            localDeliveryList.Add(deliveryFactory.CreateDelivery(40));
            localDeliveryList.Add(deliveryFactory.CreateDelivery(50));
            localDeliverySchedule = new DeliverySchedule(localDeliveryList);

            // Create some long distance deliveries
            var longDistanceDeliveryList = new List<Delivery>();
            longDistanceDeliveryList.Add(deliveryFactory.CreateDelivery(101));
            longDistanceDeliveryList.Add(deliveryFactory.CreateDelivery(200));
            longDistanceDeliveryList.Add(deliveryFactory.CreateDelivery(300));
            longDistanceDeliveryList.Add(deliveryFactory.CreateDelivery(400));
            longDistanceDeliveryList.Add(deliveryFactory.CreateDelivery(500));
            longDistanceDeliverySchedule = new DeliverySchedule(longDistanceDeliveryList);
        }

        [TestMethod]
        public void CanCalculateTimeForLocalDeliveries()
        {
            var localDeliveryVehicle = new Vehicle(localDeliverySchedule);
            var actualDeliveryTime = localDeliveryVehicle.CalculateDeliveryTimeInHoursAndHundredths();
            Assert.AreEqual(expectedLocalDeliveryTime, actualDeliveryTime);
        }

        [TestMethod]
        public void CanCalculateTimeForLongDistanceDeliveries()
        {
            var longDistanceDeliveryVehicle = new Vehicle(longDistanceDeliverySchedule);
            var actualLongDistanceDeliveryTime = longDistanceDeliveryVehicle.CalculateDeliveryTimeInHoursAndHundredths();
            Assert.AreEqual(expectedLongDistanceDeliveryTime, actualLongDistanceDeliveryTime);
        }
    }
}
