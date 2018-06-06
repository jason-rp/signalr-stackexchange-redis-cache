using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace SignalR.Server
{
    [HubName("livepool")]
    public class LivePoolHub : Hub
    {
        public void Count(string message)
        {
            Clients.All.counter(message);
        }
    }
}