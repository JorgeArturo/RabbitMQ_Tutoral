using System;

namespace Recieve
{
    class Program
    {
        static void Main(string[] args)
        {
            var receiveData = new ReceiveRabbitMQ();
            Console.WriteLine("received...");
        }
    }
}
