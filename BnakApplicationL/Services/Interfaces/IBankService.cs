using BnakApplicationL.Data;
using BnakApplicationL.Models;
using BnakApplicationL.Services.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApplicationL.Services.Interfaces
{
    public interface IBankService<T> where T: BaseEntity
    {
        public void Create(T entity);
        public void Update(string name,string addressOrProfession, decimal salary);
        public void Delete(string name);
        public void Get(string filter);
        public void GetAll();
    }
}
