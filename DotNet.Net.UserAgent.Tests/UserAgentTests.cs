using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace System.Net.Tests
{
    [TestClass]
    public class UserAgentTests
    {
        [TestMethod]
        public void Construct()
        {
            _ = GetUserAgents();
        }

        [TestMethod]
        public void FromEntryAssembly()
        {
            var entryAssembly = Assembly.GetEntryAssembly();
            if (entryAssembly == null)
                Assert.Inconclusive();
            else
            {
                var agent = UserAgent.From(entryAssembly);
                Assert.IsNotNull(agent);
            }
        }

        [TestMethod]
        public void FromThisAssembly()
        {
            var executingAssembly = Assembly.GetExecutingAssembly();
            if (executingAssembly == null)
                Assert.Inconclusive();
            else
            {
                var agent = UserAgent.From(executingAssembly);
                Assert.IsNotNull(agent);
            }
        }

        [TestMethod]
        public void UrlWithoutPlus()
        {
            UserAgent ua = new("blabalbla");
            ua.Comments.Add("https://example.com/");
            Assert.AreEqual("+https://example.com/", ua.Comments[0]);
        }

        [TestMethod]
        public void UrlWithPlus()
        {
            UserAgent ua = new("blabalbla");
            ua.Comments.Add("+https://example.com/");
            Assert.AreEqual("+https://example.com/", ua.Comments[0]);
        }


        public static UserAgent[] GetUserAgents() => new UserAgent[]
        {
            new("hello"),
            new("hello", "1.2.3.4+1a2b3c"),
            new("hello", "1.2.3.4+1a2b3c", new string[] { "world", "cat" }),
            new("hello", "1.2.3.4+1a2b3c", new string[] { "world", "cat" }, new("hello"))
        };
    }
}
