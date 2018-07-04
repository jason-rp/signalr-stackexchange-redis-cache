using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Infrastructure;
using SignalR.Server.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SignalR.Server.Core
{
    public class HubContextProvider<THubClient> : IHubContextProvider<THubClient>
        where THubClient : class
    {
        private readonly IConnectionManager _connectionManager;
        public HubContextProvider(HubConfiguration hubConfiguration)
        {
            this._connectionManager = hubConfiguration.Resolver.Resolve<IConnectionManager>();
        }

        public IHubContext<THubClient> GetHubContext<THub>()
            where THub : Hub<THubClient>
        {
            return this._connectionManager.GetHubContext<THub, THubClient>();
        }
    }
}