using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Tests;
using System.Text;
using System.Threading.Tasks;

namespace System.Net.WebSockets.Tests
{
    [TestClass]
    public class ClientWebSocketTests
    {
        [TestMethod]
        public void AddUserAgentsToClientWebSocket()
        {
            var agents = UserAgentTests.GetUserAgents();
            using ClientWebSocket client = new();
            foreach(var agent in agents)
                client.Options.SetUserAgent(agent);
        }
    }
}
