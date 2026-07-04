namespace CGPExamBackend.DTOs
{
    public class CreateSessionRequest
    {
        public required string ExamId { get; set; }
        public required string StudentId { get; set; }
        public required string SessionToken { get; set; }
    }
}