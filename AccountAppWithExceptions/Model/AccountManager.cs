using AccountAppWithExceptions.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountAppWithExceptions.Model
{
    internal class AccountManager
    {
        /*const double MIN_BALANCE = 500;

        public string Deposit(Account account, double amount)
        {
            account.Balance += amount;
            return $"Rs. {amount} Deposited succesfully.";
        }

        public string Withdraw(Account account, double amount)
        {
            if (account.Balance - amount >= MIN_BALANCE)
            {
                account.Balance -= amount;
                return $"Rs. {amount} Withdrawn succesfully.";
            }

            return "Insufficient Balance"; //custom exception

            throw new InsufficientBalanceException($"Minimum Balance of Rs.{MIN_BALANCE} should be " +
                "maintained. Withdraw denied!");
        }

        public double CheckBalance(Account account)
        {
            return account.Balance;
        }*/

        private List<Account> accounts;
        private const string AccountFilePath = "account.dat"; // File path for account data
        private const double MIN_BALANCE = 500.0;

        public AccountManager()
        {
            accounts = new List<Account>();
            InitializeAccounts();
        }

        private void InitializeAccounts()
        {
            // Load account data from file, or create a new account if the file doesn't exist.
            Account savedAccount = DataSerialization.BinaryDeserializer(AccountFilePath);
            if (savedAccount != null)
            {
                accounts.Add(savedAccount);
            }
            
        }

        public string CreateAccount(int accountNo, string accountHolderName, string bankName, double balance)
        {
            Account newAccount = new Account(accountNo, accountHolderName, bankName, balance);
            accounts.Add(newAccount);
            DataSerialization.BinarySerializer(AccountFilePath, newAccount);
            return "Account created successfully.";
        }

        public string Deposit(double amount)
        {
            if (amount <= 0)
            {
                return "Invalid deposit amount.";
            }

            if (accounts.Count > 0)
            {
                Account account = accounts[0]; // Assuming only one account exists
                account.Balance += amount;
                DataSerialization.BinarySerializer(AccountFilePath, account);
                return "Deposit successful.";
            }
            else
            {
                return "No account exists to deposit into.";
            }
        }

        public string Withdraw(double amount)
        {
            if (amount <= 0)
            {
                return "Invalid withdrawal amount.";
            }

            if (accounts.Count > 0)
            {
                Account account = accounts[0]; // Assuming only one account exists

                // Check if the withdrawal would leave the balance below the minimum balance
                if (account.Balance - amount < MIN_BALANCE)
                {
                    throw new InsufficientBalanceException("Withdrawal would result in balance below the minimum.");
                }

                // Proceed with the withdrawal
                account.Balance -= amount;
                DataSerialization.BinarySerializer(AccountFilePath, account);
                return "Withdrawal successful.";
            }
            else
            {
                return "No account exists to withdraw from.";
            }
        }

        public double CheckBalance()
        {
            if (accounts.Count > 0)
            {
                Account account = accounts[0]; // Assuming only one account exists
                return account.Balance;
            }
            else
            {
                return 0.0; // Return a default balance or handle the error as needed
            }
        }
    }
}
