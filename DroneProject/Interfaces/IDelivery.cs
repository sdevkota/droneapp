namespace DroneScheduler
{
    public interface IDelivery
    {
        bool IsDetractor { get; set; }
        bool IsPromoter { get; set; }
        string OrderId { get; set; }
        string ScheduledTime { get; set; }
    }
}