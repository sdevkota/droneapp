using DroneProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DroneScheduler
{/// <summary>
/// This is a factory class. In the real world, you would use
/// IOC containers (Autofac, Unity, StructureMap etc.) to create intances for you, but for the sake
/// of this demo, I am using a factory.
/// </summary>
    public static class Factory
    {
        public static IOrder CreateOrder()
        {
            return new Order(CreateUtilityService());
        }
        public static IDelivery CreateDelivery()
        {
            return new Delivery();
        }
        public static IList<Order> CreateOrders()
        {
            return new List<Order>();
        }
        public static IList<Delivery> CreateDeliveries()
        {
            return new List<Delivery>();
        }
        public static IDataIOService CreateFileService()
        {
            return new FileService(CreateDeliveryService());
        }
        public static IUtilityService CreateUtilityService()
        {
            return new UtilityService();
        }
        public static IDeliveryService CreateDeliveryService()
        {
            return new DeliveryService(CreateUtilityService());
        }
        public static IMessageService CreateMessageService()
        {
            return new ConsoleMessages();
        }
        public static Scheduler CreateScheduler()
        {
            return new Scheduler();
        }
    }
}

