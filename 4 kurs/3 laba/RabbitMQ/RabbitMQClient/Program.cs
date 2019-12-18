using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQClient
{
    class Program
    {
        static void Main(string[] args)
        {

            var rabbitClientService = new RabbitClientService("test.Msg");
            var msg = rabbitClientService.GetMessage();
            Console.WriteLine(msg);

            var azureService = new AzureService();
            var response = azureService.CallAzureFunction();
            Console.WriteLine(response);


            var messageService = new MessageService();
            var status = messageService.SendEmail("Azure", response);
            Console.WriteLine(status);

            Console.ReadLine();
        }
    }
}
