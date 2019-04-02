using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DroneScheduler
{/// <summary>
/// 
/// </summary>
    public class Order : IOrder
    {
        // 1.5 hours and 3.5 hours time calculated in seconds
        const int PROMOTER_TIME = 5400;
        const int NEUTRAL_TIME = 12600;

        public string OrderId { get; set; }
        public string Direction { get; set; }
        public string OrderedTimeStamp { get; set; }
        public double DeliveryTime { get; private set; } //total travel time to dest and back to the base station

        IUtilityService _utilityService;
        public Order(IUtilityService utilityService)
        {
            _utilityService = utilityService;
        }
        public void SetDeliveryTime()
        {
            char[] splitters = new char[] { 'E', 'W', 'S', 'N' };
            var array = this.Direction.Split(splitters,
                StringSplitOptions.RemoveEmptyEntries);
            var totalMinutes = 0;
            foreach (var d in array)
            {
                totalMinutes += _utilityService.ParseStringToInt(d) *
                    _utilityService.ParseStringToInt(d);
            }
            DeliveryTime = 2 * Math.Sqrt(totalMinutes) * 60;
        }
        /// <summary>
        /// Check to see if an order can be a promoter
        /// </summary>
        /// <param name="baseTime"></param>
        /// <returns></returns>
        public bool CanMakeItAsPromoter(string baseTime)
        {
            return _utilityService.GetTimeInSecondsFromRawString(baseTime) +
                (this.DeliveryTime / 2) <= _utilityService.GetTimeInSecondsFromRawString(this.OrderedTimeStamp)
                + PROMOTER_TIME &&
                (_utilityService.GetTimeInSecondsFromRawString(baseTime) +
                (this.DeliveryTime / 2))< _utilityService.GetTimeInSecondsFromRawString("22:00:00");

        }/// <summary>
         /// Check to see if an order can be a neutral
         /// </summary>
         /// <param name="baseTime"></param>
         /// <returns></returns>
        public bool CanMakeItAsNeutral(string baseTime)
        {
            return _utilityService.GetTimeInSecondsFromRawString(baseTime) +
              (this.DeliveryTime / 2) <= _utilityService.GetTimeInSecondsFromRawString(this.OrderedTimeStamp) + NEUTRAL_TIME &&
                (_utilityService.GetTimeInSecondsFromRawString(baseTime) +
                (this.DeliveryTime / 2)) < _utilityService.GetTimeInSecondsFromRawString("22:00:00");
        }
    }
}