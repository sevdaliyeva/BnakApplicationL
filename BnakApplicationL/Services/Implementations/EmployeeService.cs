
using BankApplicationL.Services.Interfaces;
using BnakApplicationL.Data;
using BnakApplicationL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace BnakApplicationL.Services.Implementations
{
    public class EmployeeService : IBankService<Employee>,IEmployeeService 
    {
        public Bank<Employee> bank;
        public EmployeeService()
        {
            bank = new Bank<Employee>();
        }
       public void Create(Employee employee)
        {
            bank.Datas.Add(employee);
        }

        public void Delete(string name)
        {
            Employee employee = bank.Datas.Find(a => a.Name.ToLower().Trim() == name.ToLower());
            employee.SoftDelete = true;
            GetAll();
        }
          public void Get(string filter) {
            try
            {

                Employee employee = bank.Datas.Find(b => b.Name.ToLower().Trim().Contains(filter.Trim().ToLower())
                ||
                b.Surname.ToLower().Trim().Contains(filter.Trim().ToLower())
                ||
                b.Profession.ToLower().Trim().Contains(filter.Trim().ToLower()));
              Console.WriteLine(employee.Name + " " +employee.Surname + " " +employee.Profession);
            }
            catch (Exception ex)    
            { 
                Console.WriteLine("Employee not found:");
            }

        }

        public void GetAll()
        {
           foreach(var employee in bank.Datas.Where(c => c.SoftDelete == false))
            {
                Console.WriteLine(employee.Name + " " +employee.Surname + " " +employee.Salary + " " +employee.Profession);
            }
        }

        public void Update(string name, string profession, decimal salary)
        {

            Employee employee = bank.Datas.Find(g => g.Name.ToLower().Trim().Contains(name.Trim().ToLower()));
            employee.Profession = profession;
            employee.Salary = salary;
           




        }

    }
}
