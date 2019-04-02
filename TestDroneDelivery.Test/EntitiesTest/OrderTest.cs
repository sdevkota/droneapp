using System;
using DroneScheduler;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestDroneDelivery.Test
{
    [TestClass]
    public class OrderItemsTest
    {
        IOrder _order;

        [TestInitialize]
        public void TestInit()
        {
            _order = Factory.CreateOrder();
            _order.OrderId = "WM001";
            _order.Direction = "N11W5";
            _order.OrderedTimeStamp = "05:11:50";
            _order.SetDeliveryTime();
        }
        [TestCleanup]
        public void TestClean()
        {
            _order = null;
        }
        [TestMethod]
        public void SettingDeliveryTimeTest()
        {
            Assert.AreEqual(1450, Math.Round(_order.DeliveryTime));

        }
        [TestMethod]
        public void CanMakeItAsPromoter_Test()
        {
            var baseTime = "07:32:00";
            Assert.IsFalse(_order.CanMakeItAsPromoter(baseTime));
            baseTime = "06:00:00";
            var canMakeIt = _order.CanMakeItAsPromoter(baseTime);
            Assert.IsTrue(canMakeIt);
        }
        [TestMethod]
        public void CanMakeItAsNeutral_Test()
        {
            var baseTime = "08:50:00";
            Assert.IsFalse(_order.CanMakeItAsNeutral(baseTime));
            baseTime = "06:00:00";
            Assert.IsTrue(_order.CanMakeItAsNeutral(baseTime));
        }

    }
}
