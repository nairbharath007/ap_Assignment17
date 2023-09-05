using AccountAppWithExceptions.Exceptions;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountAppWithExceptions.Model
{
    internal class AccountController
    {
        AccountManager manager;

        public AccountController()
        {
            manager = new AccountManager();
            double balance = manager.CheckBalance();
            
            if (balance > 0)
            {
                Console.WriteLine($"Balance: {balance}");
                Console.WriteLine("----------------------------");
                DisplayMenu();

            }
            else
                CreateAccount();
        }

        private void CreateAccount()
        {
            Console.WriteLine("Welcome to Account Creation !"); 
            Console.WriteLine("Enter Account Details: "); 
            Console.WriteLine("Enter Account No."); 
            int accountNo = Convert.ToInt32(Console.ReadLine()); 
            Console.WriteLine("Enter Account Holder Name"); 
            string name = Console.ReadLine();
            Console.WriteLine("Enter Bank Name: ");
            string bankName = Console.ReadLine();
            Console.WriteLine("Enter Initial balance: (more than 500)");
            double balance = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter Bank Name: ");
            Console.WriteLine("Enter account Balance: ");
            
            Console.WriteLine(manager.CreateAccount(accountNo, name, bankName, balance));
        }

        private void DisplayMenu()
        {
            while (true)
            {
                Console.WriteLine("Welcome! What do you wish to do?\n" +
                    "1. Deposit\n" +
                    "2. Withdraw\n" +
                    "3. View balance\n" +
                    "4. Exit\n" +
                    "Enter your choice: ");

                int choice;
                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    switch (choice)
                    {
                        case 1:
                            DepositMoney();
                            break;
                        case 2:
                            WithdrawMoney();
                            break;
                        case 3:
                            CheckBalance();
                            break;
                        case 4:
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("Enter a valid choice.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid choice.");
                }
            }
        }

        private void CheckBalance()
        {
            Console.WriteLine("Balance: "+manager.CheckBalance());
        }

        private void DepositMoney()
        {
            double amount;
            Console.WriteLine("Enter amount to be deposited: ");
            amount = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine(manager.Deposit(amount));
        }

        private void WithdrawMoney()
        {
            double amount;
            Console.WriteLine("Enter money to be withdrawn: ");
            amount = Convert.ToDouble(Console.ReadLine());
            try
            {
                Console.WriteLine(manager.Withdraw(amount));
            }
            catch (InsufficientBalanceException ibe) 
            {
                Console.WriteLine(ibe.Message);
            }
        }

    }
}
