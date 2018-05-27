using System;
using System.Reflection;
using System.Threading.Tasks;
using Autofac;
using Autofac.Integration.SignalR;
using Microsoft.AspNet.SignalR;
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
            var builder = new ContainerBuilder();
            var config = new HubConfiguration();
            //builder.RegisterHubs(Assembly.GetExecutingAssembly());
            builder.RegisterType<GameHub>().ExternallyOwned();
            builder.RegisterType<GameRepository>().As<IGameRepository>();

            //register middleware
            builder.RegisterType<MessageWatcherMiddeware>().InstancePerRequest();

            var container = builder.Build();
            config.Resolver = new AutofacDependencyResolver(container);

            app.UseAutofacMiddleware(container);
            app.MapSignalR(config);
        }
    }
}
