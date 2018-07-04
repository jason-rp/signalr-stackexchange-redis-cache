using System;
using System.Diagnostics;
using System.Reflection;
using System.Threading.Tasks;
using Autofac;
using Autofac.Integration.SignalR;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Infrastructure;
using Owin;
using SignalR.Server.Core;
using SignalR.Server.Core.Interfaces;

namespace SignalR.Server
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var hubConfig = new HubConfiguration();
            var container = new AutofacContainer(hubConfig).Container;
            hubConfig.Resolver = new AutofacDependencyResolver(container);
            app.UseAutofacMiddleware(container);
            app.MapSignalR(hubConfig);
        }
    }
}
