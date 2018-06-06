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
using SignalR.Server.Core.Repositories;

namespace SignalR.Server
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            GlobalHost.DependencyResolver.Register(
    typeof(GameHub),
    () => new GameHub());
            var t = new Test();
            t.Start();
            //var builder = new ContainerBuilder();

            //builder.RegisterType<GameHub>().ExternallyOwned();
            //builder.RegisterType<LivePoolHub>().ExternallyOwned();
            //builder.RegisterType<GameRepository>().As<IGameRepository>();
            //var container = builder.Build();
            //var config = new HubConfiguration();
            //config.Resolver = new AutofacDependencyResolver(container);

            //app.UseAutofacMiddleware(container);
            //app.MapSignalR(config);

            app.MapSignalR();
        }
    }
}
