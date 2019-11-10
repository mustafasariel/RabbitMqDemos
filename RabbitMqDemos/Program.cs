using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMqDemos
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Mesajınız :");
            string strMessage = Console.ReadLine();
            Person person = new Person() { Name = "mustafa", SurName = "sarıel", ID = 1, BirthDate = new DateTime(1981, 2, 4), Message = strMessage };
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (IConnection connection = factory.CreateConnection())
            using (IModel channel = connection.CreateModel())
            {
                //channel.QueueDeclare(queue: "msariel2", durable:    false, exclusive: false,autoDelete: false, arguments: null);
              //  channel.QueueDeclare("msariel4", false, false, false, null);
                string message = JsonConvert.SerializeObject(person);
                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish(exchange: "",
                                     routingKey: "msariel2",
                                     basicProperties: null,
                                     body: body);
                Console.WriteLine($"Gönderilen kişi: {person.Name}-{person.SurName}");
            }

            Console.WriteLine(" İlgili kişi gönderildi...");
            Console.ReadLine();
        }

    }


}