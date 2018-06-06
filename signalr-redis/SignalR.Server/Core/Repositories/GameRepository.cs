using Newtonsoft.Json;
using SignalR.Server.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SignalR.Server.Core.Repositories
{
    public class GameRepository : IGameRepository
    {
        public string Add(string name, string message)
        {
            var result = string.Empty;
            RedisConnectorHelper.Connection.GetSubscriber().Subscribe("RPChanel", (chanel, value) =>
            {
                result = JsonConvert.DeserializeObject<DataReturn>(value).Data;
            });
            //send to redis

            return result;
        }
    }

    public class DataReturn {
        public string Data { get; set; }
    }
}