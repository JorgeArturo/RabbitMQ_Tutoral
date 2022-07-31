using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Threading;

namespace Worker
{
    public class ReceiveRabbitMQ
    {
        public ReceiveRabbitMQ()
        {


            var factory = new ConnectionFactory() { HostName = "localhost",UserName = "guest",Password = "guest" };
            using(var connection = factory.CreateConnection())
            using(var channel = connection.CreateModel())
            {

                channel.ExchangeDeclare(exchange:"logs",type:ExchangeType.Fanout);

                var queueName = channel.QueueDeclare().QueueName;

                channel.QueueBind(queue:queueName,exchange:"logs",routingKey:"");

                channel.BasicQos(prefetchSize:0,prefetchCount:1,global:false);

                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (model, ea) =>
                {
                    var body = ea.Body.ToArray();
                    var message = Encoding.UTF8.GetString(body);
                    Console.WriteLine(" [x] Received {0}", message);
                    int dots = message.Split('.').Length - 1;
                    Thread.Sleep(dots * 1000);
                    Console.WriteLine(" [x] Done");
                    channel.BasicAck(deliveryTag:ea.DeliveryTag,multiple:false);
                };
                channel.BasicConsume(queue: queueName,
                                    autoAck: true,
                                    consumer: consumer);

                Console.WriteLine(" Press [enter] to exit.");
                Console.ReadLine();     
            }
        }
    }
}