using System;

namespace NewTask
{
    class Program
    {
        static void Main(string[] args)
        {
            var message = GetMessage(args);
            var sendData = new SendRabbitMQ(message);
            
        }

        private static string GetMessage(string[] args)
        {
            return ((args.Length > 0) ? string.Join(" ", args) : "Hello World!");
        }
    }
}
