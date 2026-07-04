public class ExamSession
{
    public Guid SessionId { get; set; } = Guid.NewGuid();

    public string? ExamId { get; set; }

    public string? StudentId { get; set; }

    public string? SessionToken { get; set; }

    public DateTime StartedAt { get; set; }

    public bool IsActive { get; set; }
}