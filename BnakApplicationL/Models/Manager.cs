using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BnakApplicationL.Models
{
    public class Manager:BaseEntity
    {   
        public string Surname { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public Manager(string name,string surname,string username,string password)
        {   
            Name = name;
            Surname = surname;
            Username = username;    
            Password = password;
            SoftDelete = false;

        }

    }
}
