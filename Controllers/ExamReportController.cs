using Microsoft.AspNetCore.Mvc;
using CGPExamBackend.Services;
using CGPExamBackend.DTOs;
using CGPExamBackend.Models;

namespace CGPExamBackend.Controllers
{
    [ApiController]
    [Route("audit")]
    public class ExamReportController : ControllerBase
    {
        private readonly SecurityEventService _securityService;
        private readonly AuditLogService _auditService;

        public ExamReportController(
            SecurityEventService securityService,
            AuditLogService auditService)
        {
            _securityService = securityService;
            _auditService = auditService;
        }

        [HttpGet("exam-logs")]
        public IActionResult GetExamLogs([FromQuery] string examId, [FromQuery] string studentId, [FromQuery] string sessionToken)
        {
            var session = SessionService.Find(examId, studentId, sessionToken);

            if (session == null)
                return NotFound();

            var securityEvents = _securityService.GetBySession(session.SessionId);
            var auditLogs = _auditService.GetBySession(session.SessionId);

            int riskScore = _securityService.CalculateScore(securityEvents);

            return Ok(new
            {
                examId = session.ExamId,
                studentId = session.StudentId,
                sessionToken = session.SessionToken,
                securityEvents = securityEvents,
                auditLogs = auditLogs
            });
        }
    }
}