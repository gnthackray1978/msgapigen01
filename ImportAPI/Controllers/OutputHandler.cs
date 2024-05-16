using ImportAPI.Hub;
using LoggingLib;
using Microsoft.AspNetCore.SignalR;
using System;

namespace ImportAPI.Controllers
{
    public class OutputHandler : Ilog
    {

        private readonly IHubContext<MsgNotificationHub> _hubContext;

        public OutputHandler(IHubContext<MsgNotificationHub> hubContext)
        {
            _hubContext = hubContext;
        }

        public OutputHandler() { 
        
        }

        public void WriteLine(string line, int subtype =0)
        {
            Serilog.Log.Information("WriteLine: "+ line);

            if (_hubContext == null)
                throw new Exception("Hub context can't be null");

            _hubContext.Clients.All.SendAsync("Notify", line);
        }

        public void ClearCurrentConsoleLine()
        {
           
        }

        public void ProgressSearch(int counter, int total, string message, string tailMessage = "")
        {
            
        }

        public void ProgressUpdate(int counter, int total, string message, string tailMessage = "")
        {
           

            double percentage = ((double)counter / (double)total) * 100;

            if (counter < 1)
            {
                 message = "UPDATING " + message.Trim() + " " + percentage.ToString("F") + " %   of " + total + " " + tailMessage.Trim();
            }
            else
            {
                if (counter == total)
                {
                    message = "UPDATING " + message.Trim() + " " + percentage.ToString("F") + " %   of " + total + " " + tailMessage.Trim();
                    
                }
                else
                {
                    message = "UPDATING " + message.Trim() + " " + percentage.ToString("F") + " %   of " + total + " " + tailMessage.Trim();
                }

            }

            _hubContext.Clients.All.SendAsync("Update", message);

        }

        public void StatusReport(string message, bool forceNewLine, bool pause = false)
        {
           
        }

        public void WriteCounter(string message)
        {
            _hubContext.Clients.All.SendAsync("Update", message);
        }
    }
}
