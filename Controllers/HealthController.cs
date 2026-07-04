using Microsoft.AspNetCore.Mvc;

namespace CGPExamBackend.Controllers
{
    [ApiController]
    [Route("api/health")]
    public class HealthController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetHealth()
        {
            return Ok(new { status = "ok", time = DateTime.UtcNow });
        }
    }
}