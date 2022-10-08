using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BnakApplicationL.Models
{
    public  class Employee:BaseEntity
    {
        public string Surname { get; set; } 
        public decimal Salary { get; set; } 
        public string Profession { get; set; }
        public Employee(string name,string surname,decimal salary,string profession,bool SoftDelete)
        {   
            Name = name;    
            Surname = surname;
            Salary = salary;    
            Profession = profession;    
            SoftDelete = false;
        }
       
    }

}
