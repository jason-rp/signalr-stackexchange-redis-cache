using SignalR.Server.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SignalR.Server.Core.Repositories
{
    public class GameRepository : IGameRepository
    {
        public void Add(string name, string message)
        {
           //send to redis
        }
    }
}