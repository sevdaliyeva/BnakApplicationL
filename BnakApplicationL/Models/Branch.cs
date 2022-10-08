using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BnakApplicationL.Models
{
    public  class Branch:BaseEntity
    {   
        public string Address { get; set; } 
        public decimal Budget { get; set; }    
        public List<Employee> Employees { get; set; }
        public Branch(string name,string address,decimal budget,bool SoftDelete=false)
        {
            Name = name;
            Address = address;
            Budget = budget;
            Employees = new List<Employee>();
            SoftDelete=false;
           



        }

        internal static void Add(Employee employee)
        {
            throw new NotImplementedException();
        }
    }
}
