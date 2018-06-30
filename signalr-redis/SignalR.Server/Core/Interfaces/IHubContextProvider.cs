using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.Server.Core.Interfaces
{
    public interface IHubContextProvider<THubClient>
        where THubClient : class
    {
        IHubContext<THubClient> GetHubContext<THub>()
            where THub : Hub<THubClient>;
    }
}
