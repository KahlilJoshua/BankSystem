
using System;
using System.Collections.Generic;

namespace BasicBankingSystem
{
    class Program
    {
        static List<Account> accounts = new List<Account>();

        static void Main(string[] args)
        {
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("Welcome to Basic Banking System");
                Console.WriteLine("1. Create Account");
                Console.WriteLine("2. Deposit");
                Console.WriteLine("3. Withdraw");
                Console.WriteLine("4. Check Balance");
                Console.WriteLine("5. Exit");
                Console.Write("Enter your choice: ");

                int choice;
                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    switch (choice)
                    {
                        case 1:
                            CreateAccount();
                            break;
                        case 2:
                            Deposit();
                            break;
                        case 3:
                            Withdraw();
                            break;
                        case 4:
                            CheckBalance();
                            break;
                        case 5:
                            exit = true;
                            Console.WriteLine("Thank you for using Basic Banking System.");
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Please try again.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please try again.");
                }

                Console.WriteLine();
            }
        }

        static void CreateAccount()
        {
            Console.Write("Enter account holder's name: ");
            string name = Console.ReadLine();
            Console.Write("Enter initial balance: ");
            double balance;
            if (double.TryParse(Console.ReadLine(), out balance))
            {
                Account account = new Account(name, balance);
                accounts.Add(account);
                Console.WriteLine($"Account created successfully. Account number: {account.AccountNumber}");
            }
            else
            {
                Console.WriteLine("Invalid balance. Please enter a valid number.");
            }
        }

        static void Deposit()
        {
            Console.Write("Enter account number: ");
            int accountNumber;
            if (int.TryParse(Console.ReadLine(), out accountNumber))
            {
                Account account = accounts.Find(a => a.AccountNumber == accountNumber);
                if (account != null)
                {
                    Console.Write("Enter deposit amount: ");
                    double amount;
                    if (double.TryParse(Console.ReadLine(), out amount))
                    {
                        account.Deposit(amount);
                        Console.WriteLine("Deposit successful.");
                    }
                    else
                    {
                        Console.WriteLine("Invalid amount. Please enter a valid number.");
                    }
                }
                else
                {
                    Console.WriteLine("Account not found. Please enter a valid account number.");
                }
            }
            else
            {
                Console.WriteLine("Invalid account number. Please enter a valid number.");
            }
        }

        static void Withdraw()
        {
            Console.Write("Enter account number: ");
            int accountNumber;
            if (int.TryParse(Console.ReadLine(), out accountNumber))
            {
                Account account = accounts.Find(a => a.AccountNumber == accountNumber);
                if (account != null)
                {
                    Console.Write("Enter withdrawal amount: ");
                    double amount;
                    if (double.TryParse(Console.ReadLine(), out amount))
                    {
                        if (account.Withdraw(amount))
                        {
                            Console.WriteLine("Withdrawal successful.");
                        }
                        else
                        {
                            Console.WriteLine("Insufficient balance.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid amount. Please enter a valid number.");
                    }
                }
                else
                {
                    Console.WriteLine("Account not found. Please enter a valid account number.");
                }
            }
            else
            {
                Console.WriteLine("Invalid account number. Please enter a valid number.");
            }
        }

        static void CheckBalance()
        {
            Console.Write("Enter account number: ");
            int accountNumber;
            if (int.TryParse(Console.ReadLine(), out accountNumber))
            {
                Account account = accounts.Find(a => a.AccountNumber == accountNumber);
                if (account != null)
                {
                    Console.WriteLine($"Account balance: {account.Balance}");
                }
                else
                {
                    Console.WriteLine("Account not found. Please enter a valid account number.");
                }
            }
            else
            {
                Console.WriteLine("Invalid account number. Please enter a valid number.");
            }
        }
    }

    class Account
    {
        private static int nextAccountNumber = 1;

        public int AccountNumber { get; private set; }
        public string AccountHolderName { get; private set; }
        public double Balance { get; private set; }

        public Account(string name, double balance)
        {
            AccountNumber = nextAccountNumber++;
            AccountHolderName = name;
            Balance = balance;
        }

        public void Deposit(double amount)
        {
            Balance += amount;
        }

        public bool Withdraw(double amount)
        {
            if (amount <= Balance)
            {
                Balance -= amount;
                return true;
            }
            return false;
        }
    }
}