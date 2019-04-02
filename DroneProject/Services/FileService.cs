using System;
using System.Collections.Generic;
using System.IO;

namespace DroneScheduler
{
    public class FileService : IDataIOService
    {/// <summary>
    /// This class is used to read and write data to the file.
    /// </summary>
    /// 
        IDeliveryService _deliveryService;
        public FileService()
        {
        }
        public FileService(IDeliveryService deliveryService)
        {
            _deliveryService = deliveryService;
        }
        /// <summary>
        /// Reads the orders from the text file to return list of orders
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public IList<Order> ReadOrders(string path)
        {
            var orders = new List<Order>();
            try
            {
                String[] lines = File.ReadAllLines(path);
                foreach (string line in lines)
                {
                    var orderArray = line.Split(' ');
                    var order = Factory.CreateOrder();
                    order.OrderId = orderArray[0];
                    order.Direction = orderArray[1];
                    order.OrderedTimeStamp = orderArray[2];
                    order.SetDeliveryTime();
                    orders.Add((Order)order);
                }
            }
            catch (Exception e)

            {
                Console.WriteLine("Error while reading the file");
                //throwing exception, but this can be logged or a custom message can be sent to user
                throw new Exception("Something went wrong: " + e.Message);
            }

            return orders;
        }
        /// <summary>
        /// Creates a file and returns the path to the user
        /// </summary>
        /// <param name="deliveries"></param>
        /// <returns></returns>
        public string CreateOutput(IList<Delivery> deliveries)
        {
            //creates the output file where the application runs
            var path = System.AppDomain.CurrentDomain.BaseDirectory + @"output.txt";
            try
            {
                // Delete the file if it exists.
                if (File.Exists(path))
                {
                    File.Delete(path);
                }
                // Create a new file.
                using (FileStream fs = File.Create(path)) { }
                using (TextWriter tw = new StreamWriter(path))
                {
                    foreach (var delivery in deliveries)
                    {
                        tw.WriteLine(delivery.OrderId + " " + delivery.ScheduledTime);
                    }
                    tw.WriteLine("NPS: " + Math.Round(_deliveryService.CalculateActualNPS(deliveries)).ToString());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while creating the output");
                throw new Exception("Something went wrong:" + ex.Message);
            }
            return path;
        }

    }

}
