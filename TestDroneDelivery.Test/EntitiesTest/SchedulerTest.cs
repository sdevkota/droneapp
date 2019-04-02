using System;
using System.Collections;
using DroneScheduler;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestDroneDelivery.Test.EntitiesTest
{
    [TestClass]
    public class SchedulerTest
    {
        [TestMethod]
        public void FilterOrdersToExcludeDetractors_Test()
        {
            var scheduler = Factory.CreateScheduler();
            var orders = Factory.CreateOrders();

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
            order4.OrderedTimeStamp = "02:11:50";
            order4.SetDeliveryTime();

            orders.Add((Order)order1);
            orders.Add((Order)order2);
            orders.Add((Order)order3);
            orders.Add((Order)order4);

            var goodOrders = Factory.CreateOrders();
            var detractors = Factory.CreateOrders();
            goodOrders.Add((Order)order1);
            goodOrders.Add((Order)order2);
            goodOrders.Add((Order)order3);
            detractors.Add((Order)order4);

            scheduler.BaseTime = "06:06:06";
            scheduler.PromotersAndNeutralOrders = orders;
            scheduler.FilterOrdersToExcludeDetractors();
            CollectionAssert.AreEqual((ICollection)goodOrders,
                (ICollection)scheduler.PromotersAndNeutralOrders);
            CollectionAssert.AreEqual((ICollection)detractors,
                (ICollection)scheduler.Detractors);

        }
    }
}
