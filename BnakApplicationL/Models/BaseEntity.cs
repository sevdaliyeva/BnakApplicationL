using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BnakApplicationL.Models
{
    public  class BaseEntity
    {
        public string Name { get; set; }
        public bool SoftDelete { get; set; }    
    }
}
