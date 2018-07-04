

using Autofac;
using Microsoft.AspNet.SignalR;
using SignalR.Server.Core;

namespace SignalR.Server
{
    public class AutofacContainer
    {
        public IContainer Container { get; set; }

        public AutofacContainer(HubConfiguration hubConfig)
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<GameHub>().ExternallyOwned();

            builder.RegisterInstance(hubConfig);
            //builder.RegisterGeneric(typeof(HubContextProvider<>)).As(typeof(IHubContextProvider<>)).SingleInstance();
            builder.RegisterType<MessageWatcher>().As<IStartable>().SingleInstance();

            Container = builder.Build();
        }
    }
}