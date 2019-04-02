using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DroneScheduler
{
    public class Delivery : IDelivery
    {
        public string OrderId { get; set; }
        public bool IsPromoter { get; set; } = false;
        public bool IsDetractor{ get; set; } = false;
        public string ScheduledTime { get; set; }
    }
}
