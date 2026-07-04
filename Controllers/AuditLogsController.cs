using Microsoft.AspNetCore.Mvc;
using CGPExamBackend.Services;
using CGPExamBackend.DTOs;
using CGPExamBackend.Models;

namespace CGPExamBackend.Controllers
{
    [ApiController]
    [Route("api/audit-logs")]
    public class AuditLogsController : ControllerBase
    {
        private readonly AuditLogService _service;

        private readonly SecurityEventService _securityService;
        private readonly BotNotificationService _notificationService;

        public AuditLogsController(AuditLogService service, SecurityEventService securityService, BotNotificationService notificationService)
        {
            _service = service;
            _securityService = securityService;
            _notificationService = notificationService;
        }

        [HttpPost]
        public async Task<IActionResult> LogAuditLog(AuditLogRequest req)
        {
            var auditLog = new AuditLog
            {
                Id = Guid.NewGuid(),
                SessionToken = req.SessionToken,
                Action = req.Action,
                Description = req.Description,
                Timestamp = DateTime.UtcNow
            };

            _service.Add(auditLog);

            var securityEvents = 
                _securityService.GetBySession(req.SessionToken);
             var auditLogs =
                _service.GetBySession(req.SessionToken);
            

            var report = new
            {
                sessionToken = req.SessionToken,
                securityEvents,
                auditLogs
            };

            await _notificationService.SendExamCompleted(report);

            return Ok(auditLog);

        }

        [HttpGet]
        public IActionResult GetAll()
        {
            
            return Ok(_service.GetAll());
        }
    }
}