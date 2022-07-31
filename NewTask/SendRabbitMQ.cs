using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RabbitMQ.Client;
using System.Text;

namespace NewTask
{
    public class SendRabbitMQ
    {


       public SendRabbitMQ(string args)
       {
            var factory = new ConnectionFactory() { HostName = "localhost", UserName = "guest", Password = "guest" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.ExchangeDeclare(exchange:"logs",type:ExchangeType.Fanout);

                string message = args;
                var body = Encoding.UTF8.GetBytes(message);
                var properties = channel.CreateBasicProperties();
                properties.Persistent = true;
                channel.BasicPublish(exchange: "logs",
                                    routingKey: "",
                                    basicProperties: null,
                                    body: body);
                Console.WriteLine(" [x] Sent {0}", message);
            }

            Console.WriteLine(" Press [enter] to exit.");
            Console.ReadLine();  
       } 

    }
}