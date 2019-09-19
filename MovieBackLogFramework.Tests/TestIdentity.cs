using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace MovieBackLogFramework.Tests
{
    class TestIdentity : IIdentity
    {

        private string userId;
        public TestIdentity(string name, string authenticationType, string userId, bool isAuthenticated)
        {
            Name = name;
            AuthenticationType = authenticationType;
            this.userId = userId;
            IsAuthenticated = isAuthenticated;
        }
        public string Name { get; }

        public string AuthenticationType { get; }

        public bool IsAuthenticated { get; }

        public string GetUserId() { return userId; }
    }
}

