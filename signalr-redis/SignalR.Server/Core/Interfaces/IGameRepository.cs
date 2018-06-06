using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.Server.Core.Interfaces
{
    public interface IGameRepository
    {
        string Add(string name, string message);
    }
}
