using Microsoft.AspNetCore.Mvc;
using WebApiDemo.Services;

namespace WebApiDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KafkaController : ControllerBase
    {
        private readonly IKafkaService _kafkaService;

        public KafkaController(IKafkaService kafkaService)
        {
            _kafkaService = kafkaService;
        }

        [HttpPost("send")]
        public async Task<IActionResult> SendMessage([FromBody] string message)
        {
            await _kafkaService.ProduceAsync("webapi-demo", message);
            return Ok(new { status = "Message sent to Kafka" });
        }
    }
}