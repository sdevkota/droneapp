namespace DroneScheduler
{
    public interface IOrder
    {
        double DeliveryTime { get; }
        string Direction { get; set; }
        string OrderId { get; set; }
        string OrderedTimeStamp { get; set; }

        void SetDeliveryTime();
        bool CanMakeItAsPromoter(string baseTime);
        bool CanMakeItAsNeutral(string baseTime);
    }
}