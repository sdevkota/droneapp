using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DroneScheduler;

namespace TestDroneDelivery.Test
{
    [TestClass]
    public class DeliveryTest
    {
        private readonly IDelivery delivery;
        public DeliveryTest()
        {
            delivery = new Delivery()
            {
                OrderId = "WM123",
                IsPromoter = true,
                IsDetractor = false,
                ScheduledTime = "06:00:00",
            };
        }
        /// <summary>
        /// Just Testing the object Creation
        /// </summary>
        [TestMethod]
        public void CreateIntstance_ShouldCreateAnObjectOfTypeDelivery()
        {
            Assert.IsInstanceOfType(Factory.CreateDelivery(), typeof(IDelivery));

        }
        [TestMethod]
        public void TestProperties_OfAnInstance_ShouldBeSame()
        {
            Assert.IsFalse(delivery.IsDetractor);
            Assert.IsTrue(delivery.IsPromoter);
            Assert.IsTrue(delivery.ScheduledTime.Equals("06:00:00"));
            Assert.AreEqual(delivery.OrderId, "WM123");
        }
    }
}
