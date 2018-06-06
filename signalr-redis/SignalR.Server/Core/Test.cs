using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace SignalR.Server.Core
{
    public class Test
    {
        public void Start() {
            Debug.WriteLine("Owin middleware entered => begin request");
        }
    }
}