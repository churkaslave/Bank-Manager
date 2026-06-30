using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Bank_Manager
{
    internal class Program
    {

        class BankAccount
        {
            public int Balance;
            public string OwnerName;
        }

        static void CreateAccount(List<BankAccount> accounts)
        {
            BankAccount account = new BankAccount();
            Console.WriteLine("Enter Name For Your Account");
            account.OwnerName = Console.ReadLine();
            account.Balance = 0;
            accounts.Add(account);
        }

        static void ShowAccount(List<BankAccount> accounts)
        {
            for (int i = 0; i < accounts.Count; i++)
            {
                Console.WriteLine($"{i + 1}.Account: {accounts[i].OwnerName} \nBalance: {accounts[i].Balance}$");
            }
        }


        static void DepositMoney(List<BankAccount> accounts)
        {
            Console.WriteLine("Which Account You Want To Deposite ? ");
            ShowAccount(accounts);
            int choose = int.Parse(Console.ReadLine());
            int index = choose - 1;
            if (index >= 0 && index < accounts.Count)
            {
                Console.WriteLine("Enter The Amount You Want To Deposit Into Your Account.");
                int Deposite = int.Parse(Console.ReadLine());
                accounts[index].Balance += Deposite;
            }
            else
            {
                Console.WriteLine("Wrong Choice");
            }
        }

        static void WithdrawMoney(List<BankAccount> accounts)
        {
            Console.WriteLine("Which Account You Want To Select ? ");
            ShowAccount(accounts);
            int choose = int.Parse(Console.ReadLine());
            int index = choose - 1;
            if (index >= 0 && index < accounts.Count)
            {
                    Console.WriteLine("How Much Do You Want To Debit?");
                    int amount = int.Parse(Console.ReadLine());
                    if (accounts[index].Balance >= amount)
                    {
                        accounts[index].Balance -= amount;
                    }else
                    {
                        Console.WriteLine("Insufficient Funds");
                    }
            }
            else
            {
                Console.WriteLine("Wrong Choice");
            }
        }

        static void SearchAccount(List<BankAccount> accounts)
        {
            Console.WriteLine("Enter Account That You Want To Search");
            string search = Console.ReadLine();
            for (int i = 0; i < accounts.Count; i++)
            {
                if (search == accounts[i].OwnerName)
                {
                    Console.WriteLine("Found Your Account");
                    Console.WriteLine($"{i + 1}.Account: {accounts[i].OwnerName} \nBalance: {accounts[i].Balance}$");
                    return;
                }
            }
            Console.WriteLine("Not Found \nTry Again");
        }
        static void DeleteAccount(List<BankAccount> accounts)
        {
            Console.WriteLine("Which Account Do You Want To Delete");
            ShowAccount(accounts);
            int choose = int.Parse(Console.ReadLine());
            int index = choose - 1;
            if (index >= 0 && index < accounts.Count)
            {
                accounts.RemoveAt(index);
            }
            else
            {
                Console.WriteLine("Wrong Choice");
            }
        }

        static void EditOwnerName(List<BankAccount> accounts)
        {
            Console.WriteLine("Which Account You Want To Edit Name");
            ShowAccount(accounts);
            int choose = int.Parse(Console.ReadLine());
            int index = choose - 1;
            if(index >= 0 && index < accounts.Count)
            {
                Console.WriteLine("Change Name");
                string change = Console.ReadLine();
                accounts[index].OwnerName = change;
            }
            else
            {
                Console.WriteLine("Wrong Choice");
            }
        }

        static void ShowRichAccounts(List<BankAccount> accounts)
        {
            for (int i =0;i < accounts.Count; i++)
            {
                if (accounts[i].Balance >= 2000)
                {
                    Console.WriteLine($"{i + 1}.Account: {accounts[i].OwnerName} \nBalance: {accounts[i].Balance}$");
                    return;
                }
            }
            Console.WriteLine("Not Found");

        }

        static void Main(string[] args)
        {
            List<BankAccount> accounts = new List<BankAccount>();
            while (true)
            {
                Console.Clear();
                Console.WriteLine("===== BANK ACCOUNT MANAGER =====");
                Console.WriteLine();
                Console.WriteLine("1. Create Account");
                Console.WriteLine("2. Show Accounts");
                Console.WriteLine("3. Deposit Money");
                Console.WriteLine("4. Withdraw Money");
                Console.WriteLine("5. Search Account");
                Console.WriteLine("6. Delete Account");
                Console.WriteLine("7. Edit Owner Name");
                Console.WriteLine("8. Show Rich Accounts");
                Console.WriteLine("9. Exit");
                Console.WriteLine();
                Console.Write("Choose: ");


                int choice = int.Parse(Console.ReadLine());
                if (choice == 1)
                {
                    CreateAccount(accounts);
                }
                else if (choice == 2)
                {
                    ShowAccount(accounts);
                }
                else if (choice == 3)
                {
                    DepositMoney(accounts);
                }
                else if (choice == 4)
                {
                    WithdrawMoney(accounts);
                }
                else if (choice == 5)
                {
                    SearchAccount(accounts);
                }
                else if (choice == 6)
                {
                    DeleteAccount(accounts);
                }
                else if (choice == 7)
                {
                    EditOwnerName(accounts);
                }
                else if (choice == 8)
                {
                   ShowRichAccounts(accounts);
                }
                else if (choice == 9)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Wrong Choice");
                }

                Console.WriteLine();  
                Console.WriteLine("Press Any Key...");  
                Console.ReadKey();  
            }
        }
    }
}
