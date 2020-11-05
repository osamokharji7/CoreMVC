using System;
using System.Collections.Generic;

namespace dbBackend.Models
{
    public partial class Salary
    {
        public int? SalId { get; set; }
        public string Grade { get; set; }
        public decimal? Structure { get; set; }
        public decimal? Tax { get; set; }
    }
}
