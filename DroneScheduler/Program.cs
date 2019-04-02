using System;
using System.IO;

namespace DroneScheduler
{
    public class Program
    {
        static void Main(string[] args)
        {
            IMessageService message = Factory.CreateMessageService();
            message.WelcomeMessage();
            //read the path given by the user
            string filePath = Console.ReadLine();
            message.WorkingMessage();
            var FileService = Factory.CreateFileService();
            //read the orders from the file
            var orders = FileService.ReadOrders(filePath);
            var DeliveryService = Factory.CreateDeliveryService();
            var deliveries = DeliveryService.GetScheduledDeliveries(orders);
            //creates the output file
            var outputFilePath = FileService.CreateOutput(deliveries);
            message.ShowOutPutMessage(outputFilePath);
        }
    }
}
