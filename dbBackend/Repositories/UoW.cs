using dbBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dbBackend.Repositories
{

    public class UoW : IDisposable
    {
        public UoW ()
        {

        }
        private masterContext context = new masterContext();
        public static GeneralRepository<Employee> employeeRepository { get; set; }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
        public void Save()
        {
            context.SaveChanges();
        }

    }
}
