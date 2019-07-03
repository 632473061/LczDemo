using RabbitMQ;
using System;

namespace RabbitClient
{
    class Program
    {
        static void Main(string[] args)
        {
            RabbitMQHelper.SentMessage("asdas");
            RabbitMQHelper.GetMessage();
        }
    }
}
