using System.Collections.Generic;
using CGPExamBackend.Models;

namespace CGPExamBackend.Services
{
    public class ExamReportService
    {
        public int CalculateRiskScore(List<SecurityEvent> events)
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
                }
            }

            return score;
        }
    }
}
