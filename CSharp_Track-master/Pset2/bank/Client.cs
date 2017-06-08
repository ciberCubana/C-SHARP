using System;
using System.Collections.Generic;

namespace bank
{
    public class Client
    {
        public string name { get; set; }
        public string lastName { get; set; }
        public List<Account> allAccounts { get; set; }

        public static void Greet() // GREETING MESSAGE
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Clear();
            Console.WriteLine("***************************************");
            Console.WriteLine(" Welcome to the best Bank in the World");
            Console.WriteLine("                BIG BANK              ");
            Console.WriteLine("***************************************\n");
            Console.ResetColor();
        }

        public void OpenAccount(string type) // CREATES A NEW ACCOUNT & ADDS TO THE LIST
        {
            Account newAccount = new Account();
            newAccount.transactions = new List<Transaction>();

            // creates unique account number, based on time and date
            DateTime dt = DateTime.Now;
            newAccount.Number = dt.ToString("yyyyMMddHHmmss");
            newAccount.Type = type;
            newAccount.Rate = type == "Saving" ? 1.5 : 0;
            newAccount.OwnerName = name;
            newAccount.OwnerLastName = lastName;
            newAccount.Funds = 0;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"----------------------------------");
            Console.WriteLine($"Your New Account #: {newAccount.Number}");
            Console.WriteLine($"              Type: {newAccount.Type}");
            Console.WriteLine($"      Interst Rate: {newAccount.Rate}%");
            Console.WriteLine($"----------------------------------\n");
            Console.ResetColor();
            newAccount.AddTransaction(0, "OPEN"); // ADDS "OPEN" TRANSACTION
            allAccounts.Add(newAccount);
        }

        public void CloseAccount(int index) // DELETES SELECTED ACCOUNT
        {
            Program.header();
            if (allAccounts[index-1].Funds != 0)
            {
                listOpen();
                red("This account isn't empty. You have to withdraw all funds in order to close the account!");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"-----------------------------------------------");
                Console.WriteLine($"Account #{allAccounts[index-1].Number} was SUCCESSFULLY closed");
                Console.WriteLine($"-----------------------------------------------\n");
                Console.ResetColor();
                allAccounts.RemoveAt(index-1);
            }
            Program.saveToFile(this);
            Program.continueOrExit(name);
        }

        public void listOpen()  // LISTS ALL ACCOUNTS AS TABLE
        {
            
            Console.WriteLine($" #   {"Account #", -17}{"Type", -11}{"Rate", -7}{"Funds", -14}");
            Console.WriteLine($"---------------------------------------------------");
            
            int count = 0;  // index in the table
            string index = "";  // index to string
            string rate = "";
            string funds = "";

            Console.ForegroundColor = ConsoleColor.Green;
            foreach (Account ac in allAccounts)
            {
                count++;
                index = $"[{count}]";
                rate = ac.Rate + "%";
                funds = $"{ac.Funds:C2}";
                Console.Write($"{index, -5}{ac.Number, -17}{ac.Type, - 11}{rate, -7}{funds, -14}");
                Console.Write("\n");
            }
            Console.ResetColor();
            Console.WriteLine($"---------------------------------------------------\n");
        }

        public void noAccounts() // MESSAGE WHEN THERE ARE NO ACCOUNTS OPENED
        {
            Program.header();
            red("Sorry, You don't have accounts yet!");
            Program.saveToFile(this);
            Program.continueOrExit(name);
        }

        public void Deposit(int index, int amount) // BALANCE CHANGE & ADDS TRANSACTION TO THE LIST
        {
            if (amount > 0)
                allAccounts[index-1].AddTransaction(amount, "IN");
            else if (amount < 0)
                allAccounts[index-1].AddTransaction(amount, "OUT");

            Program.header();
            allAccounts[index-1].Funds += amount;
            listOpen();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"[!] Transaction was SUCCESSFULL! New balance: {allAccounts[index-1].Funds:C2}\n");
            Console.ResetColor();
            Program.saveToFile(this);
            Program.continueOrExit(name);
        }

        public int select(string word) // ACCOUNT SELECTION FROM THE GIVEN LIST BY INDEX
        {
            int index = 0;
            int count = allAccounts.Count;
            do {
                Program.header();
                listOpen();
                Console.WriteLine($"Which account do you want to {word}?");
                Console.Write($"\nPlese select a number (1-{count}): ");
                int.TryParse(Console.ReadLine(), out index);
            } while (index < 1 || index > count);
            return index;
        }

        public int selectAndDeposit(out int deposit) // ASKS CLIENT THE AMOUNT OF THE DEPOSIT
        {
            int index = select("use");
            do {
                Program.header();
                listOpen();
                Console.WriteLine($"Account selected: [{index}]");
                Console.WriteLine($"Maximum: $100,000.00 per day ");
                Console.Write($"\nWhat is the deposit amount?: ");
                bool check = int.TryParse(Console.ReadLine(), out deposit);
                if (!check) deposit = -1;
            } while (deposit < 0 || deposit > 100000);
            return index;
        }

        public int selectAndWithdraw(out int deposit) // PROMTS ACCOUNT INDEX AND AMOUNT FOR WITHDRAWL
        {
            int index = 0;
            int count = allAccounts.Count;
            do {
                Program.header();
                listOpen();
                Console.WriteLine("Which account would you like to use?");
                Console.Write($"\nPlese select a number (1-{count}): ");
                int.TryParse(Console.ReadLine(), out index);
                if (index >= 1 && index <= count)
                {
                    if (allAccounts[index-1].Funds == 0)
                    {
                        Program.header();
                        listOpen();
                        red("This account is empty. Please choose another one.");
                        index = -1;
                        Program.saveToFile(this);
                        Program.continueOrExit(name);
                    }
                }
            } while (index < 1 || index > count);

            do {
                Program.header();
                listOpen();
                Console.WriteLine($"Account selected: [{index}]");
                Console.WriteLine($"Balance:{allAccounts[index-1].Funds:C2}");
                Console.Write($"\nHow much would you like to withdraw?: ");

                bool check = int.TryParse(Console.ReadLine(), out deposit);
                if (!check) deposit = -1; 
            } while (deposit < 0 || deposit > allAccounts[index-1].Funds);
            return index;
        }

        public static void makeChoice(ref int choice, string name) // MAIN MENU & CHOICE MAKING - FRONT END
        {
            do {
                Program.header();
                Console.WriteLine($"What would you like to do, {name}?");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("[1] Open New Account");
                Console.WriteLine("[2] Close Account");
                Console.WriteLine("[3] See all my Accounts");
                Console.WriteLine("[4] Make a Deposit");
                Console.WriteLine("[5] Withdraw Money");
                Console.WriteLine("[6] Detailed info for a specific account");
                Console.WriteLine("[7] Quit");
                Console.ResetColor();
                Console.Write("Plese select a number (1-7): ");
                int.TryParse(Console.ReadLine(), out choice);
                Console.Clear();
            } while (choice < 1 || choice > 7);
        }

        public static string[] askName() // ASKS CLIENTS THEIR FULL NAME & CREATES FILE NAME
        {
            string[] person = new string[3];
            Console.Write("\nWhat is your FIRST name: ");
            Console.ForegroundColor = ConsoleColor.Red;
            person[0] = Console.ReadLine().Trim();
            Console.ResetColor();

            Console.Write("              LAST name: ");
            Console.ForegroundColor = ConsoleColor.Red;
            person[1] = Console.ReadLine().Trim();
            Console.ResetColor();

            // FILENAME
            person[2] = person[0].ToLower() + person[1].ToLower();
            return person;
        }

        public static void thankYou() // SAYS THANK YOU TO A LEAVING CUSTOMER
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n\n\n====================================");
            Console.WriteLine($"* Thank you for visiting BIG BANK! *");
            Console.WriteLine("====================================\n\n\n");
            Console.ResetColor();
        }

        public static void red(string text) // PRINTS INFO MESSAGE IN RED ON A SEPARATE LINE
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"[!] {text}\n");
            Console.ResetColor();
        }
    }
}