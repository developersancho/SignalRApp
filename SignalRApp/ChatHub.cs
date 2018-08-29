using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace SignalRApp
{
    public class ChatHub : Hub
    {
        public void SendMessage(string username, string message)
        {
            Clients.All.MessageReceived(username, message);
        }

        public override Task OnConnected()
        {
            Clients.All.MessageReceived(Context.QueryString["username"], Context.ConnectionId +" Connected!");
            return base.OnConnected();
        }

        public override Task OnDisconnected(bool stopCalled)
        {
            Clients.All.MessageReceived(Context.QueryString["username"], Context.ConnectionId + " Disconnected!");
            return base.OnDisconnected(stopCalled);
        }

        public override Task OnReconnected()
        {
            Clients.All.MessageReceived(Context.QueryString["username"], Context.ConnectionId + " Reconnected!");
            return base.OnReconnected();
        }
    }
}