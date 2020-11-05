using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace dbBackend.Models
{
    public partial class Employee
    {
        public Employee()
        {

        }
        public Employee(int eid, string fn, string ln, int des, DateTime jd)
        {
            Id = eid;
            FirstName = fn;
            LastName = ln;
            Designation = des;
            JoiningDate = jd;
        }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(Order = 1, TypeName = "serial")]
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public int Designation { get; set; }
        public DateTime JoiningDate { get; set; }

        public virtual Designation DesignationNavigation { get; set; }
    }
}
