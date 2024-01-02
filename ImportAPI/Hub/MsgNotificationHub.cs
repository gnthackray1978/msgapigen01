using System.Threading.Tasks;
using Microsoft.AspNet.SignalR.Hubs;
using Microsoft.AspNetCore.SignalR;

namespace ImportAPI.Hub
{
    [HubName("msgnotificationhub")]
    public class MsgNotificationHub : Microsoft.AspNetCore.SignalR.Hub
    {

        public MsgNotificationHub()
        {
            Serilog.Log.Information("MsgNotificationHub constructed");
        }

        public override Task OnConnectedAsync()
        {
            Serilog.Log.Information("MsgNotificationHub OnConnectedAsync: " + Context.ConnectionId);

            Clients.All.SendAsync("fred", "test1", "test2");

            

            return base.OnConnectedAsync();
        }

        public void BroadcastMessage(string name, string message)
        {
            Clients.All.SendAsync("broadcastMessage", name, message);
        }

        public void Echo(string name, string message)
        {
            Clients.Client(Context.ConnectionId).SendAsync("echo", name, message + " (echo from server)");
        }
    }
}