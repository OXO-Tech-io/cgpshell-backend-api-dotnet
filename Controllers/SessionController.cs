using CGPExamBackend.DTOs;
using CGPExamBackend.Services;
using Microsoft.AspNetCore.Mvc;

namespace CGPExamBackend.Controllers
{
    [ApiController]
    [Route("api/sessions")]
    public class SessionController : ControllerBase
    {
        [HttpPost]
        public IActionResult CreateSession([FromBody] CreateSessionRequest req)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var session = SessionService.Create(req);
            return Ok(session);
        }

        [HttpGet("find")]
        public IActionResult FindSession(
            [FromQuery] string examId,
            [FromQuery] string studentId,
            [FromQuery] string sessionToken)
        {
            var session = SessionService.Find(examId, studentId, sessionToken);

            if (session == null)
                return NotFound();

            return Ok(session);
        }
    }
}