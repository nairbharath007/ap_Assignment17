using AccountAppWithExceptions.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountAppWithExceptions.Model
{
    [Serializable]
    internal class Account
    {
        public int AccountNo { get; set; }
        public string AccountHolderName { get; set; }
        public string BankName { get; set; }
        public double Balance { get; set; }

        //public const double MIN_BALANCE = 500;

        public Account(int accountNo, string name, string bankName, double balance)
        {
            AccountNo = accountNo;
            AccountHolderName = name;
            BankName = bankName;
            Balance = balance;
        }

        

    }
}
