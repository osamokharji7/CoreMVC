using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dbBackend.Models;
namespace dbBackend.Repositories
{
    public interface IGeneralRepository<T> where T:class
    {
        public string GetTs();
        public string GetTById(int id);
        public string AddT(T entity);
        public string UpdateT(T entity);
        public string DeleteT(T entity);
    }
}
