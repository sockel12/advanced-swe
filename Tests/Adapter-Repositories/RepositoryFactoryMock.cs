using Application_Code.Interfaces;
using Domain_Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.Adapter_Repositories
{
    internal class RepositoryFactoryMock(bool DoesContain = false) : IRepositoryFactory
    {
        public IRepository<T> CreateRepository<T>() where T : Identifiable
        {
            return new RepositoryMock<T>();
        }

        public IRepository<T> GetRepository<T>() where T : Identifiable
        {
            if (DoesContain)
                return new RepositoryMock<T>();
            return null;
        }

        public bool HasRecords<T>() where T : Identifiable
        {
            return DoesContain;
        }
    }
}
