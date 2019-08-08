using MovieBackLogFramework.Models;
using StoreApp.Tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieBackLogFramework.Tests
{
    class TestBackLogDbSet : TestDbSet<BackLog>
    {
        public override BackLog Find(params object[] keyValues)
        {
            return this.SingleOrDefault(bl => bl.Id == (int)keyValues.Single());
        }

    }
}
