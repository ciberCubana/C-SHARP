using System;
using System.Collections.Generic;

namespace bank
{
    public class Account
    {
        public string Number { get; set; }
        public string Type { get; set; }
        public string OwnerName { get; set; }
        public string OwnerLastName { get; set; }
        public double Rate { get; set; }
        public int Funds { get; set; }
        public List<Transaction> transactions{ get; set; }

        public static string selectType() // ACCOUNT TYPE SELECTION
        {
            int value = Program.yesNo("What type of account would you like to open?", "Saving", "Cheking", true);
            string type = value == 1 ? "Saving" : "Checking";
            return type;
        }

        public void AddTransaction (double money, string type) // ADDS TRANSACTION TO THE LIST
        {
            Transaction toAdd = new Transaction();
            toAdd.Date = DateTime.Now.ToString("yyyy-MM-dd");
            toAdd.Time = DateTime.Now.ToString("HH:mm");
            toAdd.Amount = money;
            toAdd.Type = type;
            transactions.Add(toAdd);
        }

        public void PrintInfo () // DETAILED INFO FOR SPECIFIC ACCOUNT
        {
            Program.header();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine( "---------------------------------------------");
            Console.WriteLine($"  Detailed info for account# {this.Number}");
            Console.WriteLine( "---------------------------------------------");
            Console.ResetColor();
            Console.Write($"Type: "); redWord(Type);
            Console.Write($"  Rate: "); redWord(Rate +"%");
            string funds = $"{Funds:C2}";
            Console.Write($"  BALANCE: "); redWord(funds + "\n");
            Console.Write($"Owner: "); redWord(OwnerName + " " + OwnerLastName);
            Console.Write($"  Opened: "); redWord(transactions[0].Date + "\n\n");
            
            Console.WriteLine($"             Transaction History");
            Console.WriteLine($"---------------------------------------------");

            Console.WriteLine($" #   {"Date", -14}{"Time", -8}{"Type", -7}{"Amount", -11}");
            Console.WriteLine($"---------------------------------------------");
            
            int count = 0;  // index in the table
            string index = "";  // index to string
            funds = "";

            Console.ForegroundColor = ConsoleColor.Green;
            foreach (Transaction t in transactions)
            {
                count++;
                index = $"[{count}]";
                funds = $"{t.Amount:C2}";
                Console.Write($"{index, -5}{t.Date, -14}{t.Time, - 8}{t.Type, -7}{funds, -11}");
                Console.Write("\n");
            }
            Console.ResetColor();
            Console.WriteLine($"---------------------------------------------");
            Program.continueOrExit(OwnerName);
        }

    public void redWord (string word) // PRINTS TEXT IN RED 
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write($"{word}");
        Console.ResetColor();
    }

    }
    public class Transaction
    {
        public string Date { get; set; }
        public string Time { get; set; }
        public double Amount { get; set; }
        public string Type { get; set; } 
    }
}