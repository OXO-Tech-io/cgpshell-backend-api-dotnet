using CGPExamBackend.Models;

namespace CGPExamBackend.Services
{
    public class SecurityEventService
    {
        private readonly List<SecurityEvent> _events = new();

        public void Add(SecurityEvent securityEvent)
        {
            _events.Add(securityEvent);
        }

        public List<SecurityEvent> GetAll()
        {
            return _events;
        }

        public List<SecurityEvent> GetBySession(Guid sessionId)
        {
            return _events.Where(x => x.SessionId == sessionId).ToList();
        }

        // NEW
        public int CalculateScore(List<SecurityEvent> events)
        {
            int score = 0;

            foreach (var e in events)
            {
                switch (e.EventType)
                {
                    case "ALT_TAB_ATTEMPT":
                        score += 10;
                        break;

                    case "WINDOWS_KEY_BLOCKED":
                        score += 5;
                        break;

                    case "MULTIPLE_MONITOR_DETECTED":
                        score += 50;
                        break;

                    case "APPLICATION_CLOSE_ATTEMPT":
                        score += 20;
                        break;

                    case "PRINT_SCREEN_BLOCKED":
                        score += 15;
                        break;
                }
            }

            return score;
        }
    }
}