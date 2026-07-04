using CGPExamBackend.Models;

namespace CGPExamBackend.Services
{
    public class AuditLogService
    {
        private readonly List<AuditLog> _logs = new();

        public void Add(AuditLog log)
        {
            _logs.Add(log);
        }

        public List<AuditLog> GetAll()
        {
            return _logs;
        }

        public List<AuditLog> GetBySession(Guid sessionToken)
        {
            return _logs
                .Where(x => x.SessionToken == sessionToken)
                .OrderBy(x => x.Timestamp)
                .ToList();
        }
    }
}