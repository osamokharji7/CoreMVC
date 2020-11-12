using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dbBackend.Models
{
    public class HelperModels
    {
        public HelperModels()
        { 
        }
        public HelperModels(int Hid)
        {
            Id = Hid;
        }
        public int Id { get; set; }
    }
}
