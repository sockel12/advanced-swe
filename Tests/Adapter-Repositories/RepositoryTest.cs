using Adapter_Repositories;
using Application_Code.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.Adapter_Repositories
{
    internal class RepositoryTest
    {
        private Repository<TestObject> cut;

        public void Setup()
        {
            IList<IRepository<TestObject>> list = new List<IRepository<TestObject>>();
            cut = new Repository<TestObject>(list);
        }
    }
}
