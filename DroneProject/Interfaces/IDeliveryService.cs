using System.Collections.Generic;


namespace DroneScheduler
{
    public interface IDeliveryService
    {
        double CalculateActualNPS(IList<Delivery> deliveries);
        IList<Delivery> GetScheduledDeliveries(IList<Order> orders);
    }
}