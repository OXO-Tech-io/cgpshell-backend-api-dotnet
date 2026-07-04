namespace CGPExamBackend.DTOs
{
    public class AuditLogRequest
    {
        public Guid SessionToken {get; set;}
        public string Action {get; set; } = string.Empty;
        public string Description {get; set;} = string.Empty;
    }
}