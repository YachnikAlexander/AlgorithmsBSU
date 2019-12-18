using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQ
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the message u wanna to transport");
            var msg = Console.ReadLine();

            var rabbitService = new RabbitService("test.Yachnik", "test.Msg");

            var status = rabbitService.PublishMessage(msg);
            Console.WriteLine(status);
            Console.ReadKey();
        }
    }
}
