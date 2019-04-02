
using DroneProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DroneScheduler
{
    public class DeliveryService : IDeliveryService
    {
        IUtilityService _utilityService;
        public DeliveryService(IUtilityService utilityService)
        {
            _utilityService = utilityService;
        }
        /// <summary>
        /// Calculates the NPS of deliveries
        /// </summary>
        /// <param name="deliveries"></param>
        /// <returns></returns>
        public double CalculateActualNPS(IList<Delivery> deliveries)
        {
            int totalOrders = deliveries.Count;
            var totalDetractors = deliveries.Where(d => d.IsDetractor == true).Count();
            var totalPromoters = deliveries.Where(d => d.IsPromoter == true).Count();
            return (double)totalPromoters / totalOrders * 100 -
                (double)totalDetractors / totalOrders * 100;
        }
        /// <summary>
        /// Returns deliveries based on the input orders
        /// </summary>
        /// <param name="orders"></param>
        /// <returns></returns>
        public IList<Delivery> GetScheduledDeliveries(IList<Order> orders)
        {
            var deliveries = Factory.CreateDeliveries();
            //This is to calculate the total time elapsed since 6 AM
            var timeElapsed = 0.0;
            var scheduler = Factory.CreateScheduler();
            //This is the start of the delivery   
            scheduler.PromotersAndNeutralOrders = orders;
            //see if there is no delivery before 6 or at 6. The basetime should be time of the first delivery
            var deliveryOrderedAfterSix = scheduler.PromotersAndNeutralOrders
                .OrderBy(o => _utilityService.GetTimeInSecondsFromRawString(o.OrderedTimeStamp)).ElementAt(0);
            scheduler.BaseTime = _utilityService.GetTimeInSecondsFromRawString(deliveryOrderedAfterSix.OrderedTimeStamp)
                > _utilityService.GetTimeInSecondsFromRawString("06:00:00") ?
                deliveryOrderedAfterSix.OrderedTimeStamp : "06:00:00";
            scheduler.FilterOrdersToExcludeDetractors();

            //schedules the promoters and neutral orders first
            while (scheduler.PromotersAndNeutralOrders.Count > 0)
            {
                var order = scheduler.PromotersAndNeutralOrders
                    .OrderBy(p => p.CanMakeItAsPromoter(scheduler.BaseTime))
                    .ThenBy(o => o.DeliveryTime).ElementAt(0);
                order.SetDeliveryTime();
                var delivery = Factory.CreateDelivery();
                delivery.OrderId = order.OrderId;
                delivery.ScheduledTime = _utilityService.GetSecondsToHMS(21600 + timeElapsed);
                delivery.IsPromoter = ((21600 + timeElapsed) - _utilityService.GetTimeInSecondsFromRawString(order.OrderedTimeStamp)) <= 5400;
                delivery.IsDetractor = ((21600 + timeElapsed) - _utilityService.GetTimeInSecondsFromRawString(order.OrderedTimeStamp)) >= 12600;
                scheduler.BaseTime = delivery.ScheduledTime;
               
                deliveries.Add((Delivery)delivery);
                scheduler.PromotersAndNeutralOrders.Remove(order);
                if (timeElapsed + 21600 > 79200)
                {
                    timeElapsed = order.DeliveryTime;
                }
                else
                {
                    timeElapsed += order.DeliveryTime;
                }
                scheduler.FilterOrdersToExcludeDetractors();
            }
            /*Detractors are schedules after promoters and neutrals are done and they
            are delivered in the order which they are ordered */
            foreach (var order in scheduler.Detractors.OrderBy(o =>
             _utilityService.GetTimeInSecondsFromRawString(o.OrderedTimeStamp)))
            {
                var delivery = Factory.CreateDelivery();
                order.SetDeliveryTime();
                delivery.OrderId = order.OrderId;
                delivery.ScheduledTime = _utilityService.GetSecondsToHMS(21600 + timeElapsed);
                delivery.IsDetractor = true;
                deliveries.Add((Delivery)delivery);
                if (timeElapsed + 21600 > 79200)
                {
                    timeElapsed = order.DeliveryTime;
                }
                else
                {
                    timeElapsed += order.DeliveryTime;
                }
            }
            return deliveries;
        }
    }
}
