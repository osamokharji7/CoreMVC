using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace dbBackend.Models
{
    public partial class Emp
    {
        [Key] 
        public int? Id { get; set; }
        [DisplayFormat(NullDisplayText = "Null name")]
        [StringLength(50, ErrorMessage = "Name cannot be longer than 50 characters.")]
        public string Name { get; set; }
        public string City { get; set; }
        public string Salary { get; set; }
    }
}
