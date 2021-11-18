using CatalogoProdutos.Models;
using CatalogoProdutos.Services.ProdutoService;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Linq;
using System.Text;

namespace CatalogoProdutos.RabbitMQ
{
    public class ConnectionProduto
    {
        public static void ReceiveNew()
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "cria_produto",
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
                        Produto produto = JsonConvert.DeserializeObject<Produto>(message);
                        new InsertService().Execute(produto);
                    };
                }
                catch(Exception)
                {
                }

                channel.BasicConsume(queue: "cria_produto",
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
                channel.QueueDeclare(queue: "atualiza_produto",
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
                        Produto categoria = JsonConvert.DeserializeObject<Produto>(message);
                        new UpdateService().Execute(categoria);
                    };
                }
                catch(Exception)
                {
                }

                channel.BasicConsume(queue: "atualiza_produto",
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
                channel.QueueDeclare(queue: "deleta_produto",
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

                channel.BasicConsume(queue: "deleta_produto",
                                     autoAck: true,
                                     consumer: consumer);
                Console.ReadLine();
            }
        }
    }
}
