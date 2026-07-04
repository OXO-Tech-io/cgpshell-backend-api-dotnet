namespace CGPExamBackend.Models
{
    public class AuditLog
    {
        public Guid Id { get; set; }

        public Guid SessionToken { get; set; }

        public string Action { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public DateTime Timestamp { get; set; }
    }
}