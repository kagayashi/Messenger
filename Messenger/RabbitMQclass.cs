using RabbitMQ.Client;
using System.Text;

namespace Messenger
{
    public static class RabbitMQclass
    {
        public static void ProduceMessage(string message, string direction)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: direction,
                                     durable: false,
                                     exclusive:false,
                                     autoDelete:false,
                                     arguments: null);
                

                var body = Encoding.UTF8.GetBytes(message);
                channel.BasicPublish(exchange: "",
                                     routingKey: direction,
                                     basicProperties: null,
                                     body: body);
             


            }
        }
        
    }
}
