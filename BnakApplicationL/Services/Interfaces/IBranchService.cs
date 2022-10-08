using BnakApplicationL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApplicationL.Services.Interfaces
{
    public interface IBranchService:IBankService<Branch>
    {
        public void HireEmployee();
        public void GetProfit(string name, decimal salary);
        public void TransferMoney(string name1,string name2,decimal budget);
        public void TransferEmployee(string name,string name1,string name2);
    }
}
