namespace CGPExamBackend.DTOs
{
    public class SecurityEventRequest
    {
        public Guid SessionId { get; set; }
        public string EventType { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime OccuredAt { get; set; }
    }
}