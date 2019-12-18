using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQClient
{
    public class RabbitClientService
    {
        public string QueueName { get; set; }
        public string HostName = "localhost";

        public RabbitClientService(string queueName, string hostName = null)
        {
            this.QueueName = queueName;

            if(hostName != null)
            {
                HostName = hostName;
            }
        }

        public string GetMessage()
        {
            var rabbitMqFactory = new ConnectionFactory() { HostName = HostName };

            using (IConnection conn = rabbitMqFactory.CreateConnection())
            using (IModel channel = conn.CreateModel())
            {
                BasicGetResult msgResponse = channel.BasicGet(QueueName, true);

                var msgBody = Encoding.UTF8.GetString(msgResponse.Body);
                return msgBody;
            }
        }

    }
}
