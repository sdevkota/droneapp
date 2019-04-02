using System;
using System.Collections.Generic;
using DroneProject.Entities;
using DroneScheduler;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestDroneDelivery.Test.FactoryTest
{/// <summary>
/// Methods in this class simply create instances of each objects
/// to make sure that the factory is returning the right instances
/// </summary>
    [TestClass]
    public class FactoryTest
    {
        [TestMethod]
        public void CreateOrder_Test()
        {
            Assert.IsInstanceOfType(Factory.CreateOrder(), typeof(IOrder));
        }
        [TestMethod]
        public void CreateDelivery_Test()
        {
            Assert.IsInstanceOfType(Factory.CreateDelivery(), typeof(IDelivery));
        }
        [TestMethod]
        public void CreateOrders_Test()
        {
            Assert.IsInstanceOfType(Factory.CreateOrders(), typeof(IList<Order>));
        }
        [TestMethod]
        public void CreateDeliveries_Test()
        {
            Assert.IsInstanceOfType(Factory.CreateDeliveries(), typeof(IList<Delivery>));
        }
        [TestMethod]
        public void CreateFileService_Test()
        {
            Assert.IsInstanceOfType(Factory.CreateFileService(), typeof(IDataIOService));
        }
        [TestMethod]
        public void CreateUtilityService_Test()
        {
            Assert.IsInstanceOfType(Factory.CreateUtilityService(), typeof(IUtilityService));
        }
        [TestMethod]
        public void CreateDeliveryService_Test()
        {
            Assert.IsInstanceOfType(Factory.CreateDeliveryService(), typeof(IDeliveryService));
        }
        [TestMethod]
        public void CreateMessageService_Test()
        {
            Assert.IsInstanceOfType(Factory.CreateMessageService(), typeof(IMessageService));
        }
        [TestMethod]
        public void CreateScheduler_Test()
        {
            Assert.IsInstanceOfType(Factory.CreateScheduler(), typeof(Scheduler));
        }
    }
}
