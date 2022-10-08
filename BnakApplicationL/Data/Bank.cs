using BnakApplicationL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BnakApplicationL.Data
{
    public class Bank<T> 
    {
        public List<T> Datas { get; set; }
        //List<Branch> branches = new List<Branch>();
        //List<Employee> employees = new List<Employee>();

        public Bank()
        {
            Datas = new List<T>();  
        }
    }
}
