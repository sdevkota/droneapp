using System;
using System.Collections.Generic;
using DroneScheduler;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestDroneDelivery.Test.ServicesTest
{
    [TestClass]
    public class DeliveryServiceTest
    {
        IDeliveryService _deliveryService;
        IList<Delivery> _deliveries;
        IList<Order> _orders;

        [TestInitialize]
        public void TestInit()
        {
            _deliveryService = Factory.CreateDeliveryService();
            _deliveries = Factory.CreateDeliveries();
            _orders = Factory.CreateOrders();

            /*I am creating these test data here (not very clean) but in the real world, 
            they would come from somewhere else */
            var order1 = Factory.CreateOrder();
            order1.OrderId = "WM001";
            order1.Direction = "N11W5";
            order1.OrderedTimeStamp = "05:11:50";
            order1.SetDeliveryTime();

            var order2 = Factory.CreateOrder();
            order2.OrderId = "WM002";
            order2.Direction = "S3E2";
            order2.OrderedTimeStamp = "05:11:55";
            order2.SetDeliveryTime();

            var order3 = Factory.CreateOrder();
            order3.OrderId = "WM003";
            order3.Direction = "N7E50";
            order3.OrderedTimeStamp = "05:31:50";
            order3.SetDeliveryTime();

            var order4 = Factory.CreateOrder();
            order4.OrderId = "WM004";
            order4.Direction = "N11E5";
            order4.OrderedTimeStamp = "06:11:50";
            order4.SetDeliveryTime();
            _orders.Add((Order)order1);
            _orders.Add((Order)order2);
            _orders.Add((Order)order3);
            _orders.Add((Order)order4);

            _deliveries.Add(new Delivery()
            {
                OrderId = "WM001",
                IsPromoter = true,
                IsDetractor = false,
                ScheduledTime = "06:00:00",
            });
            _deliveries.Add(new Delivery()
            {
                OrderId = "WM002",
                IsPromoter = true,
                IsDetractor = false,
                ScheduledTime = "06:23:00",
            });
            _deliveries.Add(new Delivery()
            {
                OrderId = "WM003",
                IsPromoter = false,
                IsDetractor = false,
                ScheduledTime = "06:45:00",
            });
            _deliveries.Add(new Delivery()
            {
                OrderId = "WM004",
                IsPromoter = false,
                IsDetractor = true,
                ScheduledTime = "07:00:00",
            });
        }
        [TestCleanup]
        public void TestClean()
        {
            _deliveryService = null;
        }
        /// <summary>
        /// HardCoded the NPS to be 25
        /// </summary>
        [TestMethod]
        public void TestForCalculateActualNPSMthod_ShouldBe25()
        {
            Assert.AreEqual(25, _deliveryService.CalculateActualNPS(_deliveries));

        }
        [TestMethod]
        public void Test_ScheduleDelivery_ShouldProvideSchedules()
        {
            var schedules = _deliveryService.GetScheduledDeliveries(_orders);

            Assert.AreEqual("WM002 06:00:00", schedules[0].OrderId + " " + schedules[0].ScheduledTime);
            Assert.AreEqual("WM001 06:07:12", schedules[1].OrderId + " " + schedules[1].ScheduledTime);
            Assert.AreEqual("WM004 06:31:22", schedules[2].OrderId + " " + schedules[2].ScheduledTime);
            Assert.AreEqual("WM003 06:55:32", schedules[3].OrderId + " " + schedules[3].ScheduledTime);
        }

    }
}
