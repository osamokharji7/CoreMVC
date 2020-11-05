using System;
using System.Collections.Generic;

namespace dbBackend.Models
{
    public partial class Emp
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Salary { get; set; }
    }
}
