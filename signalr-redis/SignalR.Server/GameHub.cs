using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using SignalR.Server.Core.Interfaces;

namespace SignalR.Server
{
    [HubName("gameHub")]
    public class GameHub : Hub
    {
        private IGameRepository _gameRepository;
        public GameHub(IGameRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }
        public void Send(string message)
        {
            _gameRepository.Add("RP", message);

            Clients.All.sendMessage(message);
        }
    }
}