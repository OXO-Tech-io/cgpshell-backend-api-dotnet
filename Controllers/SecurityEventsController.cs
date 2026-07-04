using Microsoft.AspNetCore.Mvc;
using CGPExamBackend.Services;
using CGPExamBackend.DTOs;
using CGPExamBackend.Models;

namespace CGPExamBackend.Controllers
{
    [ApiController]
    [Route("api/security-events")]
    public class SecurityEventsController : ControllerBase
    {
        private readonly SecurityEventService _service;

        public SecurityEventsController(SecurityEventService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult Log(SecurityEventRequest req)
        {
            var securityEvent = new SecurityEvent
            {
                Id = Guid.NewGuid(),
                SessionId = req.SessionId,
                EventType = req.EventType,
                Description = req.Description,
                OccuredAt = req.OccuredAt
            };

            _service.Add(securityEvent);
            return Ok(securityEvent);
        }

        [HttpGet("report/{sessionId}")]
        public IActionResult GetAll(Guid sessionId)
        {
            var events = _service.GetBySession(sessionId);

            var score = _service.CalculateScore(events);

            return Ok(new
            {
                sessionId,
                totalEvents = events.Count,
                riskScore = score,
                status = score >= 50 ? "FLAGGED"
                    : score >= 20 ? "WARNING"
                    : "CLEAN",
                events
            });
        }
    }
}