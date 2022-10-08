// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
using BnakApplicationL.Models;
using BnakApplicationL.Services.Implementations;
using System;
using System.ComponentModel.Design;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;

namespace BnakApplicationL
{
    class Program
    {

        static void Main(string[] args)
        {
            
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            BranchService branchService = new BranchService();
            EmployeeService employeeService = new EmployeeService();
            SeedDataBase(employeeService,branchService);
            Console.Clear();
            Console.WriteLine("");
            string username = "Sevda";
            string password = "SA11";
        Retrieve:
            Console.WriteLine("Please Enter your Username:");
            string usern1 = Console.ReadLine();
            Console.WriteLine("Please enter your password:");
            string passwordn1 = Console.ReadLine();
            if (username == usern1 && password == passwordn1)
            {
            Menu:
                Console.Clear();
                Console.WriteLine($"Welcome {username},please select your option :");
                Console.WriteLine("1.Branch operations:");
                Console.WriteLine("2.Employee operations :");
                int choice;
                try
                {
                    choice = int.Parse(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("Format is not correct,press any key to start again :");
                    Console.ReadKey();
                    goto Menu;
                }
                if (choice != 0)
                {
                    if (choice == 1 || choice == 2)
                    {
                        switch (choice)
                        {
                            case 1:
                               Console.Clear();
                                Menu1();
                                int operation1;
                                try
                                {
                                    operation1 = int.Parse(Console.ReadLine());
                                }
                                catch (FormatException)
                                {
                                    Console.WriteLine(" Wrong format,press any key to start again:");
                                    Console.ReadKey();
                                    goto Menu;
                                }
                                if (operation1 != 0)
                                {
                                    if (operation1 < 10 || operation1 == 111 || operation1 == 222)
                                        switch (operation1)
                                        {
                                            case 1:
                                                Console.Clear();
                                                Console.WriteLine("Please enter Name,address,Budget for a new branch :");
                                                string nname = Console.ReadLine();
                                                string naddress = Console.ReadLine();
                                                decimal nbudget = decimal.Parse(Console.ReadLine());
                                                if (nname != null && naddress != null && nbudget != 0)
                                                {
                                                    Branch branchn = new Branch(nname, naddress, nbudget);
                                                    branchService.Create(branchn);
                                                    branchService.GetAll();
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Enter the correct information: ");
                                                }
                                                Console.ReadKey();
                                                goto Menu;
                                            case 2:
                                                Console.Clear();
                                                Console.WriteLine("Enter the name of the branch to delete:");
                                                string dname = Console.ReadLine();
                                                if (dname != null)
                                                {
                                                    branchService.Delete(dname);
                                                }
                                                Console.ReadKey();
                                                goto Menu;
                                            case 3:
                                                Console.Clear();
                                                Console.WriteLine("Enter branchname to update:");
                                                string uname = Console.ReadLine();
                                                Console.WriteLine("Enter address and budget:");
                                                string uaddress = Console.ReadLine();
                                                decimal ubudget = decimal.Parse(Console.ReadLine());
                                                if (ubudget != 0 && uaddress != null && uname != null)
                                                {
                                                    branchService.Update(uname, uaddress, ubudget);
                                                }
                                                Console.ReadKey();
                                                goto Menu;
                                            case 4:
                                                Console.Clear();
                                                Console.WriteLine("Enter branchname to find any branch:");
                                                string gname = Console.ReadLine();
                                             
                                                if (gname != null)
                                                {
                                                    branchService.Get(gname);
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Enter the name of the branch");
                                                }
                                                Console.ReadKey();
                                                goto Menu;
                                            case 5:
                                                Console.Clear();
                                                branchService.GetAll();
                                                Console.ReadKey();
                                                goto Menu;
                                            case 6:
                                                Console.Clear();
                                                Console.WriteLine("Genclik,Nerimanov,28May,Icerseher:");
                                                Console.WriteLine("Enter branch name to calculate profit:");
                                                string gname1 = Console.ReadLine();
                                                branchService.GetProfit(gname1);
                                                Console.ReadKey();
                                                goto Menu;
                                            case 7:
                                                Console.Clear();
                                                Console.WriteLine("Enter employee name to hire employee:"); 
                                                string nameh = Console.ReadLine();
                                                Console.WriteLine("Enter branch name :");
                                                string namebr=Console.ReadLine();
                                                branchService.HireEmployee(nameh,namebr);
                                                Console.ReadKey();
                                                goto Menu;
                                            case 8:
                                                Console.Clear();
                                                Console.WriteLine("Enter employee name :");
                                                string bname1 = Console.ReadLine();
                                                Console.WriteLine("Enter first branch name:");
                                                string bname2 = Console.ReadLine();
                                                Console.WriteLine("Enter second branch name:");
                                                string ename = Console.ReadLine();
                                                branchService.TransferEmployee(bname1, bname2, ename);
                                                Console.ReadKey();

                                                break;
                                                goto Menu;
                                            case 9:
                                                Console.Clear();
                                                Console.WriteLine("Select first branch");
                                                var firstbranch = Console.ReadLine();
                                                Console.WriteLine("Select second branch:");
                                                var secondbranch = Console.ReadLine();
                                                Console.WriteLine("Enter budget:");
                                                var budget = int.Parse(Console.ReadLine());
                                                branchService.TransferMoney(firstbranch, secondbranch, budget);
                                                branchService.GetAll();
                                                Console.ReadKey();
                                                goto Menu;
                                            case 10:
                                                Console.Clear();
                                                Console.WriteLine();
                                                Console.ReadKey();
                                                goto Menu;
                                            case 11:
                                                Console.Clear();
                                                Console.WriteLine("Press any key to quit:");
                                                Console.ReadKey();
                                                Environment.Exit(0);
                                                break;
                                        }
                                }
                                     else
                                {
                                    Console.WriteLine("Enter a number  ");
                                    Console.ReadKey();
                                    goto Menu;
                                 }
                                break;

                                case 2:
                                Console.Clear();
                                Menu2(); 
                                int operation2;
                                try
                                {
                                    operation2 = int.Parse(Console.ReadLine());
                                }
                                catch (FormatException)
                                {
                                    Console.WriteLine(" Enter number :");
                                    Console.ReadKey();
                                    goto Menu;
                                }
                                if (operation2 != 0)
                                {
                                    if (operation2 <= 5 || operation2 == 13 || operation2 == 14)
                                    {
                                        switch (operation2)
                                        {
                                            case 1:
                                                Console.Clear();
                                                Console.WriteLine("Enter name,surname,salary,profession:");
                                                string nname2 = Console.ReadLine();
                                                string nsurname2 = Console.ReadLine();
                                                int nSalary = int.Parse(Console.ReadLine());
                                                string nprofesion = Console.ReadLine();
                                                if (nname2 != null && nsurname2 != null && nprofesion != null)
                                                {
                                                    Employee newemployee = new Employee(nname2, nsurname2, nSalary, nprofesion,false);
                                                    employeeService.Create(newemployee);

                                                   Console.WriteLine(newemployee.Name + " " + newemployee.Surname + " " + newemployee.Salary + " " + newemployee.Profession);
                                                   employeeService.GetAll();
                                                }
                                                else
                                                {
                                                    Console.WriteLine("The format you entered is incorret:");
                                                   
                                                }
                                                Console.ReadKey();
                                                goto Menu;

                                            case 2:
                                                Console.Clear();
                                                Console.Write("Enter the name of employee to delete from list:");
                                                string dname1 = Console.ReadLine();
                                                if (dname1 != null)
                                                {
                                                    employeeService.Delete(dname1);
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Please enter name:");
                                                }
                                                Console.ReadKey();
                                                goto Menu;
                                            case 3:
                                                Console.Clear();
                                                Console.WriteLine("Enter a employeeName to update:");
                                                string uname = Console.ReadLine();
                                                Console.WriteLine("Enter a employeeSurname:");
                                                string usurname = Console.ReadLine();
                                               
                                                if (uname != null && username!=null)
                                                {
                                                    Console.WriteLine("Enter new salary:");
                                                    decimal usalary = decimal.Parse(Console.ReadLine());
                                                    Console.WriteLine("Enter new profession: ");
                                                    string uprofession1 = Console.ReadLine();
                                                    if (uprofession1 != null && usalary != 0)
                                                    {
                                                         employeeService.Update(uname, uprofession1, usalary);
                                                        employeeService.GetAll();
                                                       
                                                    }
                                                }
                                                Console.ReadKey();
                                                goto Menu;
                                            case 4:
                                                Console.Clear();
                                                Console.WriteLine("Enter any Employee`s name or surname:");
                                               
                                               string getname=Console.ReadLine();
                                            
                                                if (getname != null)
                                                {
                                                   employeeService.Get(getname);
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Enter correct information and format :");
                                                }
                                                Console.ReadKey();
                                                goto Menu;
                                            case 5:
                                                Console.Clear();
                                               
                                                employeeService.GetAll();
                                                Console.ReadKey();
                                                goto Menu;
                                            case 13:
                                                Console.Clear();
                                                Console.WriteLine("Press any key to go back to the menu:");
                                                Console.ReadKey();
                                                goto Menu;
                                            case 14:
                                                Console.Clear();
                                                Console.WriteLine("Press any key to quit:");
                                                Console.ReadKey();
                                                Environment.Exit(0);
                                                break;
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Enter number from 1 to 5 ");
                                        Console.ReadKey();
                                        goto Menu;
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Enter correct format:");
                                    Console.ReadKey();
                                    goto Menu;
                                }
                                break;
                             }
                          }
                    else
                    {
                        Console.WriteLine("Enter 1 0r 2 :");
                        Console.ReadKey();
                        goto Menu;
                    }
                }
                else
                {
                    Console.WriteLine("enter correct format:");
                    Console.ReadKey();
                    goto Menu;
                }
            }
            else
            {
                Console.WriteLine("Incorret password or null,press any key to return Menu:");
                Console.ReadKey();
                goto Retrieve;
            }
  
            static void SeedDataBase(EmployeeService employeeService, BranchService branchService)
            {
                
                Employee employee1 = new Employee("Adil", "Mehdiyev", 7000, "IT",false);
                Employee employee2 = new Employee("Nezrin", "Aliyeva", 4000, "HR",false);
                Employee employee3 = new Employee("Gulnar", "Huseynova", 8000, "QAE",false);
                Employee employee4 = new Employee("Tural", "Babayev", 10000, "IT",false);
                Employee employee5 = new Employee("Jale", "Qasimzade", 3000, "HR",false);
                
                Branch branch1 = new Branch("Genclik", "GenclikT ", 1000000);
                Branch branch2 = new Branch("Nerimanov", "NerimanovT", 2000000);
                Branch branch3 = new Branch("28May", "28MayT", 4000000);
                Branch branch4 = new Branch("IceriSeher", "IceriSeherT", 5000000);

                branch1.Employees.Add(employee1);
                branch2.Employees.Add(employee2);
                branch3.Employees.Add(employee3);
                branch4.Employees.Add(employee4);



                branchService.Create(branch1);
                branchService.Create(branch2);
                branchService.Create(branch3);
                branchService.Create(branch4);
                

                employeeService.Create(employee1);
                employeeService.Create(employee2);
                employeeService.Create(employee3);
                employeeService.Create(employee4);
                employeeService.Create(employee5);
 }

   static void Menu1()
            {
                Console.WriteLine("Please select transaction:");
                Console.WriteLine("1.Create:");
                Console.WriteLine("2.Delete:");
                Console.WriteLine("3.Update:");
                Console.WriteLine("4.Get:");
                Console.WriteLine("5.Get All:");
                Console.WriteLine("6.GetProfit:");
                Console.WriteLine("7.HireEmployee:");
                Console.WriteLine("8.TransferEmployee:");
                Console.WriteLine("9.TransferMoney:");
                Console.WriteLine("                ");
                Console.WriteLine("                ");
                Console.WriteLine("                ");
                Console.WriteLine(10 + ")" + "Main menu:");
                Console.WriteLine(11 + ")" + "Quit:");
            }

                 static void Menu2()
                {
                    Console.WriteLine("Please select transaction:");
                    Console.WriteLine("1.Create:");
                    Console.WriteLine("2.Delete:");
                    Console.WriteLine("3.Update:");
                    Console.WriteLine("4.Get:");
                    Console.WriteLine("5.Get All:");
                    Console.WriteLine("Press 13 to go back to Main Menu: ");
                    Console.WriteLine("Press 14 to quit:");

                }
            }
        }
    }

      








