namespace CGPExamBackend.Models
{
    public class SecurityEvent
    {
        public Guid Id { get; set; }
        public Guid SessionId { get; set; }
        public string EventType { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime OccuredAt { get; set; }
    }
}