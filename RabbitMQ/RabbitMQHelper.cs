using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;

namespace RabbitMQ
{
    public class RabbitMQHelper
    {
        public static bool SentMessage(object data)
        {
            try
            {
                IConnectionFactory connectionFactory = new ConnectionFactory { HostName = "192.168.1.253", UserName = "mamba", Password = "mamba123" };
                using (IConnection con = connectionFactory.CreateConnection())
                {
                    using (IModel channel = con.CreateModel())
                    {
                        channel.QueueDeclare(
                             queue: "queueTest"//消息队列名称
                             , durable: false//消息队列名称
                             , exclusive: false,
                              autoDelete: false,
                               arguments: null
                            );
                        string message = Newtonsoft.Json.JsonConvert.SerializeObject(data);
                        byte[] body = Encoding.UTF8.GetBytes(message);
                        channel.BasicPublish("", "queueTest", null, body);
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
           
           
        }

        public static void GetMessage()
        {
            IConnectionFactory connectionFactory = new ConnectionFactory { HostName = "192.168.1.253", UserName = "mamba", Password = "mamba123" };
            using (IConnection con = connectionFactory.CreateConnection())
            {
                using (IModel channel = con.CreateModel())
                {
                    channel.QueueDeclare(
                         queue: "queueTest"//消息队列名称
                         , durable: false//消息队列名称
                         , exclusive: false,
                          autoDelete: false,
                           arguments: null
                        );
                    var consumer = new EventingBasicConsumer(channel);
                    consumer.Received += (model, ea) =>
                    {
                        byte[] message = ea.Body;//接收到的消息
                        Console.WriteLine("接收到信息为:" + Encoding.UTF8.GetString(message));
                    };
                    channel.BasicConsume("queueTest", true, consumer);
                }
            }
        }
    }
}
