using Domain_Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.Adapter_Repositories
{
    internal class TestObject : IIdentifiable
    {
        public Key GetId()
        {
            return new Key("key");
        }
    }
}
