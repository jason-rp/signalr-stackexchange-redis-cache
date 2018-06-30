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

            HubConfiguration hubConfig = new HubConfiguration();
            var builder = new ContainerBuilder();
            
            builder.RegisterType<GameHub>().ExternallyOwned();

            

            builder.RegisterInstance(hubConfig);

            //builder.RegisterGeneric(typeof(HubContextProvider<>)).As(typeof(IHubContextProvider<>)).SingleInstance();
            builder.RegisterType<MessageWatcher>().As<IStartable>().SingleInstance();





            var container = builder.Build();


            var signalRResolver = new AutofacDependencyResolver(container);
            hubConfig.Resolver = signalRResolver;

            app.UseAutofacMiddleware(container);
            app.MapSignalR(hubConfig);
        }
    }
}
