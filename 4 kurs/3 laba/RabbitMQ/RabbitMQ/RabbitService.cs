using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQ
{
    public class RabbitService
    {

        public string ExchangeName { get; set; }
        private string QueueName { get; set; }
        private string HostName = "localhost";
        private string ExchangeType = "direct";

        private RabbitService()
        {
            ExchangeName = "test.Yachnik";
            QueueName = "test.Msg";
        }

        public RabbitService(string exchangeName, string queueName, string hostName = null, string exchangeType = null)
        {
            this.ExchangeName = exchangeName;
            this.QueueName = queueName;

            if(hostName != null)
            {
                this.HostName = hostName;
            }
            if(exchangeType != null) 
            {
                this.ExchangeType = exchangeType;
            }
        }

        public Status PublishMessage(string msg)
        {
            
            try
            {
                var rabbitMqFactory = new ConnectionFactory() { HostName = HostName };

                using (IConnection conn = rabbitMqFactory.CreateConnection())
                using (IModel channel = conn.CreateModel())
                {
                    channel.ExchangeDeclare(ExchangeName, ExchangeType, durable: true, autoDelete: false, arguments: null);

                    channel.QueueDeclare(QueueName, durable: true, exclusive: false, autoDelete: false, arguments: null);
                    channel.QueueBind(QueueName, ExchangeName, routingKey: QueueName);

                    var props = channel.CreateBasicProperties();
                    props.SetPersistent(true);

                    var msgBody = Encoding.UTF8.GetBytes(msg);
                    channel.BasicPublish(ExchangeName, routingKey: QueueName, basicProperties: props, body: msgBody);
                }

                return Status.ok;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return Status.error;
            }
        }
    }
}
