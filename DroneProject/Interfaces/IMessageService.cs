namespace DroneScheduler
{/// <summary>
/// Created this so that if the messaging service changes in the future, we can use this
/// </summary>
     public interface IMessageService
    {
        void WelcomeMessage();
        void WorkingMessage();
        void ShowOutPutMessage(string path);

    }
}