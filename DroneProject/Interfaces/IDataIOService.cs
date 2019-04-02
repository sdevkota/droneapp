using System.Collections.Generic;

namespace DroneScheduler
{
    public interface IDataIOService
    {
        IList<Order> ReadOrders(string path);
        string CreateOutput(IList<Delivery> deliveries);
    }
}