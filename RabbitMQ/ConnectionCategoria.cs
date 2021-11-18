using CatalogoProdutos.Models;
using CatalogoProdutos.Services.CategoriaService;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogoProdutos.RabbitMQ
{
    public class ConnectionCategoria
    {
        public static void ReceiveNew()
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "cria_categoria",
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                var consumer = new EventingBasicConsumer(channel);
                try
                {
                    consumer.Received += (model, ea) =>
                    {
                        var body = ea.Body.ToArray();
                        var message = Encoding.UTF8.GetString(body);
                        Categoria categoria = JsonConvert.DeserializeObject<Categoria>(message);
                        new InsertService().Execute(categoria);
                    };
                }
                catch(Exception)
                {
                }

                channel.BasicConsume(queue: "cria_categoria",
                                     autoAck: true,
                                     consumer: consumer);
                Console.ReadLine();
            }
        }

        public static void ReceiveUpdate()
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "atualiza_categoria",
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                var consumer = new EventingBasicConsumer(channel);
                try
                {
                    consumer.Received += (model, ea) =>
                    {
                        var body = ea.Body.ToArray();
                        var message = Encoding.UTF8.GetString(body);
                        Categoria categoria = JsonConvert.DeserializeObject<Categoria>(message);
                        new UpdateService().Execute(categoria);
                    };
                }
                catch(Exception)
                {
                }

                channel.BasicConsume(queue: "atualiza_categoria",
                                     autoAck: true,
                                     consumer: consumer);
                Console.ReadLine();
            }
        }

        public static void ReceiveDelete()
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "deleta_categoria",
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                var consumer = new EventingBasicConsumer(channel);
                try
                {
                    consumer.Received += (model, ea) =>
                    {
                        var body = ea.Body.ToArray();
                        var message = Encoding.UTF8.GetString(body);
                        int codigo = int.Parse(message);
                        new DeleteService().Execute(codigo);
                    };
                }
                catch(Exception)
                {
                }

                channel.BasicConsume(queue: "deleta_categoria",
                                     autoAck: true,
                                     consumer: consumer);
                Console.ReadLine();
            }
        }
    }
}
