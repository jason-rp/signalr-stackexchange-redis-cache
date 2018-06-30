using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using SignalR.Server.Core.Interfaces;

namespace SignalR.Server
{
    [HubName("gameHub")]
    public class GameHub : Hub<IGameHub>
    {
        public void Send(string message)
        {
            Clients.All.sendMessage("from gamehub");
        }
    }
}