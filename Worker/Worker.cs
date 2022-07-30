using System;

namespace Worker
{
    class Program
    {
        static void Main(string[] args)
        {
            var workers = new ReceiveRabbitMQ();
            Console.WriteLine("Hello World!");
        }
    }
}
