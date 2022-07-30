using System;

namespace Send
{
    class Program
    {
        static void Main(string[] args)
        {
            var sendData = new SendRabbitMQ();
            Console.WriteLine("Sent...");
        }
    }
}
