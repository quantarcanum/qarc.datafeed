using Microsoft.AspNetCore.SignalR;

namespace Qarc.DataFeed.Adapter.Api.Hubs
{
    public class AtasHub : Hub
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/aspnet/core/tutorials/signalr?view=aspnetcore-7.0&tabs=visual-studio
        /// 
        /// The ChatHub class inherits from the SignalR Hub class. The Hub class manages connections, groups, and messaging.
        /// 
        /// The SendMessage method can be called by a connected client to send a message to all clients. JavaScript client code that calls the method is shown later in the tutorial. SignalR code is asynchronous to provide maximum scalability.
        /// </summary>
        /// <param name="user"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public async Task ReceiveTrade(string message)
        {
            await Clients.All.SendAsync("ReceiveTrade", message);
        }
    }
}
