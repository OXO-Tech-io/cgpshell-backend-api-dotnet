using Microsoft.AspNetCore.SignalR;
using CGPExamBackend.Hubs;

namespace CGPExamBackend.Services
{
    public class BotNotificationService
    {
        private readonly IHubContext<BotHub> _hub;

        public BotNotificationService(IHubContext<BotHub> hub)
        {
            _hub = hub;
        }

        public async Task SendExamCompleted(object report)
        {
            await _hub.Clients.All.SendAsync("ExamCompleted", report);
        }
    }
}