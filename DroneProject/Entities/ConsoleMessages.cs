
using System;
using System.Collections.Generic;
using System.Text;

namespace DroneScheduler
{
    public class ConsoleMessages : IMessageService
    { 
        public void WelcomeMessage()
        {
            Console.WriteLine("Enter the path to your orders file\n");
            Console.WriteLine("Example: c:\\users\\sd103456\\documents\\orders.txt");
        }
        public void WorkingMessage()
        {
            Console.WriteLine("reading your file...");

            Console.WriteLine("Creating a Schedule...\n");
        }
        public void ShowOutPutMessage(string path)
        {
            Console.WriteLine($"Output File Path:\n {path}");
            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
        }
    }
}
