using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DroneScheduler;
using System.Collections.Generic;

namespace TestDroneDelivery.Test
{
    [TestClass]
    public class _utilityServiceTest
    {
        IUtilityService _utilityService;

        [TestInitialize]
        public void TestInit()
        {
            _utilityService = Factory.CreateUtilityService();
        }
        [TestCleanup]
        public void TestClean()
        {
            _utilityService = null;
        }

        [TestMethod]
        public void testForgetSecondsToHMSMethod()
        {
            Assert.IsTrue(_utilityService.GetSecondsToHMS(9935).Equals("02:45:35"));
        }

        [TestMethod]
        public void testForGetTimeInSecondsMethod()
        {
            Assert.AreEqual(9935, _utilityService.GetTimeInSeconds("02", "45", "35"));
        }

        [TestMethod]
        public void testForGetTimeInSecondsFromRawStringMethod()
        {
            Assert.AreEqual(9935, _utilityService.GetTimeInSecondsFromRawString("02:45:35"));

        }

        [TestMethod]
        public void testForParseStringToIntMethod()
        {
            Assert.AreEqual(1, _utilityService.ParseStringToInt("1"));
        }

        [TestMethod]
        public void testForParseStringToIntMethodForNonNumeric()
        {
            Assert.AreEqual(-1, _utilityService.ParseStringToInt("C"));
        }

        [TestMethod]
        public void testForGetScheduledDeliveriesForOneOrderToBeAtSixMethod()
        {
            //List<Order> orders = new List<Order>();
            //orders.Add(new Order("WM001", "N11W5", "05:11:53"));
            //var deliveries = _utilityService.GetScheduledDeliveries(orders);
            //Assert.AreEqual(1, deliveries.Count);
            //Assert.IsTrue(deliveries[0].ScheduledTime.Equals("06:00:00"));
        }

        [TestMethod]
        public void testForOrderWithShorterDeliveryTimeShouldbeDeliveredFirst()
        {
            //List<Order> orders = new List<Order>();
            //orders.Add(new Order("WM001", "N11W5", "05:11:50"));
            //orders.Add(new Order("WM002", "S3E2", "05:11:55"));
            //var deliveries = _utilityService.GetScheduledDeliveries(orders);
            //Assert.IsTrue(deliveries[0].OrderId.Equals("WM002"));

        }

        [TestMethod]
        public void testForSecondOrdersShouldBeScheduledAfterTheDeliveryTimeOfFirst()
        {
            //List<Order> orders = new List<Order>();
            //orders.Add(new Order("WM001", "N11W5", "05:11:50"));
            //orders.Add(new Order("WM002", "S3E2", "05:11:55"));
            //var deliveries = _utilityService.GetScheduledDeliveries(orders);
            //Assert.AreEqual(2, deliveries.Count);
            //Assert.IsTrue(deliveries[1].ScheduledTime.Equals("06:07:12"));

        }
    }
}
