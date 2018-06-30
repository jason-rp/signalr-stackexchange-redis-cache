using Autofac;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Infrastructure;
using SignalR.Server.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SignalR.Server.Core
{
    public class MessageWatcher : IStartable
    {
        private HubConfiguration _hubConfiguration;
        public MessageWatcher(HubConfiguration hubConfiguration)
        {
            _hubConfiguration = hubConfiguration;
        }

        public void Start()
        {
            RedisConnectorHelper.Connection.GetSubscriber().Subscribe("*", (channel, value) =>
            {
                _hubConfiguration.Resolver.Resolve<IConnectionManager>().GetHubContext<GameHub>().Clients.All.senme("aaaaaaaaaaaaaaaaa");
            });
        }
    }
}