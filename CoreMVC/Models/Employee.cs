using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [Key]
        public int Id { get; set; }

        [ForeignKey("HotelID")]
        public Designation desg { get; set; }
        [DisplayFormat(NullDisplayText = "Null name")]
        [StringLength(50, ErrorMessage = "Name cannot be longer than 50 characters.")]
        public string LastName { get; set; }
        [DisplayFormat(NullDisplayText = "Null name")]
        [StringLength(50, ErrorMessage = "Name cannot be longer than 50 characters.")]
        public string FirstName { get; set; }
        public int Designation { get; set; }

        [DataType(DataType.Date)]
        public DateTime JoiningDate { get; set; }

        public virtual Designation DesignationNavigation { get; set; }
    }
}
