using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace SignalR.Server.Core
{
    public class MessageWatcherMiddeware :OwinMiddleware
    {
        //public MessageWatcherMiddeware()
        //{
        //    RedisConnectorHelper.Connection.GetSubscriber().PublishAsync("RPChanel", "Hello rupic!");
        //}
        public MessageWatcherMiddeware(OwinMiddleware next) : base(next)
        {
        }

        public override async Task Invoke(IOwinContext context)
        {
            Debug.WriteLine("Owin middleware entered => begin request");

            await RedisConnectorHelper.Connection.GetSubscriber().PublishAsync("RPChanel", "Hello rupic!");

            //var cache = RedisConnectorHelper.Connection.GetDatabase();
            //var devicesCount = 1000;
            //for (int i = 0; i < devicesCount; i++)
            //{
            //    cache.StringGet($"Device_Status:{i}");
            //}


            await Next.Invoke(context);
            Debug.WriteLine("Owin middleware exited => end request");
        }
    }
}