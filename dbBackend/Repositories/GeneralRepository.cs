using dbBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace dbBackend.Repositories
{
    public class GeneralRepository<T>: IGeneralRepository<T> where T:class
    {
        protected DbSet<T> table;
        protected DbContext dbcontext;
        public GeneralRepository()
        {
            
        }
        public GeneralRepository(masterContext context)
        {
            this.table = context.Set<T>();
        }
     

        public string AddT(T entity)
        {
          
            table.Add(entity);
            return "done";
        }

        public string DeleteT(T entity)
        {
            table.Remove(entity);
            return "done";
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public string GetTById(int id)
        {
            return JsonConvert.SerializeObject(table.Find(id));
        }

        public string GetTs()
        {
            return JsonConvert.SerializeObject(table.ToList());
        }

        public string UpdateT(T entity)
        {
            table.Update(entity);
            dbcontext.SaveChanges();
            return "done";
        }
    }
}
