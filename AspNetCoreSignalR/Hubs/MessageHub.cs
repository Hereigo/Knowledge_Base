using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace AspNetCoreSignalR.Hubs
{
    public class MessageHub : Hub
    {
        const string receiveMsgMethodName = "ReceiveMessage";

        public Task SendMessageToAll(string message)
        {
            return Clients.All.SendAsync(receiveMsgMethodName, message);
        }

        public Task SendMessageToCaller(string message)
        {
            return Clients.Caller.SendAsync(receiveMsgMethodName, message);
        }

        public Task SendMessageToUser(string connectionId, string message)
        {
            return Clients.Client(connectionId).SendAsync(receiveMsgMethodName, message);
        }

        public Task JoinGroup(string group)
        {
            return Groups.AddToGroupAsync(Context.ConnectionId, group);
        }

        public Task SendMessageToGroup(string group, string message)
        {
            return Clients.Group(group).SendAsync(receiveMsgMethodName, message);
        }

        public override async Task OnConnectedAsync()
        {
            await Clients.All.SendAsync("UserConnected", Context.ConnectionId);
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception ex)
        {
            await Clients.All.SendAsync("UserDisconnected", Context.ConnectionId);
            await base.OnDisconnectedAsync(ex);
        }
    }
}
