using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RabbitMQ.Client;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MultiShop.RabbitMqMessageApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateMessage()
        {
            var connectionFactory = new ConnectionFactory()
            {
                HostName = "localhost"
            };

            // SENKRON bağlantı
            using var connection = connectionFactory.CreateConnection();
            using var channel = connection.CreateModel();

            channel.QueueDeclare("Kuyruk1", durable: false, exclusive: false, autoDelete: false, arguments: null);

            var message = "Merhaba Bu Bir RabbitMQ Kuyruk Mesajıdır";
            var body = Encoding.UTF8.GetBytes(message);

            var props = channel.CreateBasicProperties();

            channel.BasicPublish(
                exchange: "",
                routingKey: "Kuyruk1",
                basicProperties: props,
                body: body);

            return Ok("Mesajınız Kuyruğa Alınmıştır");

        }

        [HttpGet]
        public async Task<IActionResult> GetMessage(CancellationToken cancellationToken)
        {
            var connectionFactory = new ConnectionFactory()
            {
                HostName = "localhost"
            };
            // SENKRON bağlantı
            using var connection = connectionFactory.CreateConnection();
            using var channel = connection.CreateModel();
            channel.QueueDeclare("Kuyruk1", durable: false, exclusive: false, autoDelete: false, arguments: null);
            var result = channel.BasicGet("Kuyruk1", autoAck: true);
            if (result == null)
            {
                return NotFound("Kuyrukta Mesaj Bulunamadı");
            }
            var message = Encoding.UTF8.GetString(result.Body.ToArray());
            return Ok(message);
        }
    }
}
