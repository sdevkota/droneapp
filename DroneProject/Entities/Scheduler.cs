using DroneScheduler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DroneProject.Entities
{/// <summary>
/// Schedules the orders according to the algorithm
/// </summary>
    public class Scheduler
    {
        public IList<Order> PromotersAndNeutralOrders { get; set; }
        public IList<Order> Detractors { get; set; }
        public string BaseTime { get; set; } //Time at the base station(drone launch center)
        /// <summary>
        /// This method will exclude all the deliveries that  will not make it within 3.5 hours
        /// </summary>
        public void FilterOrdersToExcludeDetractors()
        {
            //if detrators are carried over from the last execution, add it to the list
            var detractors = this.Detractors == null ? Factory.CreateOrders()
                : this.Detractors;
            //creates a new list for the goodOrders
            var goodOrders = Factory.CreateOrders();
            if (this.PromotersAndNeutralOrders.Count>0)
            {
                foreach(var order in PromotersAndNeutralOrders)
                {
                    //checking to see if the order is still in the promoter and neutral state
                    if (order.CanMakeItAsPromoter(this.BaseTime) 
                       || order.CanMakeItAsNeutral(this.BaseTime))
                    {
                        goodOrders.Add(order);
                    }
                    else
                    {
                        detractors.Add(order);
                    }
                }
                this.PromotersAndNeutralOrders = goodOrders;
                this.Detractors = detractors;              
            }
        }
       
    }
}
