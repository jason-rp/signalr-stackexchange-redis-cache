using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace SignalR.Server.Core
{
    public class MessageWatcherMiddeware : OwinMiddleware
    {
        public MessageWatcherMiddeware(OwinMiddleware next) : base(next)
        {
        }

        public override async Task Invoke(IOwinContext context)
        {
            await Next.Invoke(context);
        }
    }
}