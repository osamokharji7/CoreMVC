using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace dbBackend.Models
{
    public partial class Designation
    {
        public Designation()
        {
            Employee = new HashSet<Employee>();
        }

        [Key] 
        public int Id { get; set; }
        [DisplayFormat(NullDisplayText = "Null name")]
        [StringLength(50, ErrorMessage = "Name cannot be longer than 50 characters.")]
        public string Name { get; set; }

        public virtual ICollection<Employee> Employee { get; set; }
    }
}
