using Microsoft.AspNetCore.SignalR;

namespace Imi.Project.Blazor.Hubs
{
    public class LogbookHub : Hub
    {
        private readonly string RereshEventsString = "RefreshEvents";

        public async Task CreatedEvent(string test)
        {
            await Clients.All.SendAsync(RereshEventsString);
        }
    }
}
