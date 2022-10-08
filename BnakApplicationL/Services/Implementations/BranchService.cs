
using BankApplicationL.Services.Interfaces;
using BnakApplicationL.Data;
using BnakApplicationL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BnakApplicationL.Services.Implementations
{
    public class BranchService :IBankService<Branch>
    {
        public Bank<Branch> bank;
        public Bank<Employee> employees;
        public BranchService()
        {
          bank = new Bank<Branch>();
          employees = new Bank<Employee>();   
        }
        public void Create(Branch branch)
        {
          bank.Datas.Add(branch);
        }
        public void Update(string name,string address,decimal budget)
        {
            
            
                Branch branch = bank.Datas.Where (x => x.Name.ToLower().Trim() == name.ToLower().Trim()).FirstOrDefault();
                branch.Budget = budget;
                branch.Address = address;
             Console.WriteLine(branch.Name + " "+branch.Budget + " " +branch.Address);
            GetAll();


        }
        public void Delete(string DName)
        {
         Branch branch = bank.Datas.Find(x => x.Name.ToLower().Trim() == DName.ToLower().Trim());
         branch.SoftDelete = true;
        GetAll();
        }
        public void Get(string filter)
        {
            try
            {

                Branch branch = bank.Datas.Find(a => a.Name.Contains(filter.ToLower().Trim())
            ||
            a.Address.Contains(filter.ToLower().Trim())); 
            Console.WriteLine(branch.Name + " " + branch.Address);

            }
            catch (Exception)
            {
             Console.WriteLine("Branch not found:");
            }


           }
        public void GetAll()
        {
         foreach(var branch in bank.Datas.Where(m => m.SoftDelete == false))
          {
           Console.WriteLine(branch.Name +" "+branch.Address+" "+branch.Budget);
          }

        }
        public void HireEmployee(string namee,string nameb)
        {
            Employee employee = employees.Datas.Find(x => x.Name.ToLower().Trim() == namee.ToLower().Trim());
            Branch branch = bank.Datas.Find(a => a.Name.ToLower().Trim() == nameb.ToLower().ToLower());
            branch.Employees.Add(employee);

        }
        public void GetProfit(string name)
        {
            Branch branch = bank.Datas.Find(b => b.Name.ToLower().Trim() == name.ToLower().Trim());
          if(branch != null)
            {

                if (branch.Employees.Any())
                {
                    decimal ssalary = 0;
                    foreach(var employee in branch.Employees)
                    {
                        ssalary+=employee.Salary;
                    }
                    decimal bprofit=branch.Budget-ssalary;
                    Console.WriteLine(bprofit);
                }
                 }
            else
            {
                Console.WriteLine("This branch is empty:");
            }
             }
        public void TransferMoney(string name1,string name2,decimal budget)
        {
            Branch branch1 = bank.Datas.Find(b => b.Name.ToLower().Trim() == name1.ToLower().Trim());
            Branch branch2= bank.Datas.Find(b => b.Name.ToLower().Trim() == name2.ToLower().Trim());
            branch1.Budget = branch1.Budget - budget;
            branch2.Budget= branch2.Budget + budget;
        }
        public void TransferEmployee(string name,string name1,string name2)
        {
            Employee employee = employees.Datas.Find(x => x.Name.ToLower().Trim() == name.ToLower().Trim());
            Branch branch1 = bank.Datas.Find(a => a.Name.ToLower().Trim() == name1.Trim());
            Branch branch2 = bank.Datas.Find(a => a.Name.ToLower().Trim() == name2.Trim());

            branch1.Employees.Remove(employee);
            branch2.Employees.Add(employee);

        }
       

       
    }
    
}
