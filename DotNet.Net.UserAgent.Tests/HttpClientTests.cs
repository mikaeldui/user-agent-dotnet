using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Tests;
using System.Text;
using System.Threading.Tasks;

namespace System.Net.Http.Tests
{
    [TestClass]
    public class HttpClientTests
    {
        [TestMethod]
        public void AddToUserAgent()
        {
            var agents = UserAgentTests.GetUserAgents();

            foreach (var agent in agents)
            {
                using HttpClient client = new();
                client.DefaultRequestHeaders.Add(agent);
            }
        }

        [TestMethod]
        public void CheckAddedUserAgents()
        {
            var agents = UserAgentTests.GetUserAgents();

            foreach (var agent in agents)
            {
                using HttpClient client = new();
                client.DefaultRequestHeaders.Add(agent);

                Assert.AreEqual(client.DefaultRequestHeaders.UserAgent.ToString(), agent.ToString());
            }
        }
    }
}
