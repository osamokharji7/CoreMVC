using System;
using System.Collections.Generic;

namespace dbBackend.Models
{
    public partial class Designation
    {
        public Designation()
        {
            Employee = new HashSet<Employee>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Employee> Employee { get; set; }
    }
}
