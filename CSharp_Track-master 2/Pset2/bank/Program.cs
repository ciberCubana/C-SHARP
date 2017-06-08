using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace bank
{
    class Program
    {
        static void Main(string[] args)
        {
            Client customer = new Client();
            customer.allAccounts = new List<Account>();
            string[] person;

            Client.Greet();
            int nameCheck = yesNo("Hi! Are you a BIG BANK's customer?", "Yes", "No", false);
            
            if (nameCheck == 1) // IF PERSON IS A CUSTOMER
            {
                bool status;
                do
                {
                    Program.header();
                    Console.WriteLine("To access your account please provide your full name.");
                    person = Client.askName();
                    status = checkStatus(person, out customer);
                    if (!status) // IF NOT A CUSTOMER
                    {
                       nameCheck = appologize(person);
                    }
                    else nameCheck = 0;
                } while (nameCheck == 1);
            }
            
            if (nameCheck == 2) // IF PERSON WANTS TO BECOME A CUSTOMER
            {
                if (yesNo("Would you like to become a BIG BANK's customer?", "Yes", "No", true) == 1)
                {
                    Program.header();
                    Console.WriteLine("Wonderful!!! We just need your full name to register you in our system!");
                    person = Client.askName();
                    customer.name = person[0];
                    customer.lastName = person[1];
                    saveToFile(customer);
                }
                else // IF WANTS TO LEAVE
                {
                    Client.thankYou();
                    return;
                }
            }
            menu(customer); // ENTERS THE MAIN MENU
        }


        /*********************************************
                            METHODS
        *********************************************/

        // GIVES TO A CLIENT CHOICE OF TWO, RETURNS NUMBER OF THE CHOICE
        public static int yesNo(string message, string yes, string no, bool needHeader)
        {
            int choice;
            int count = 0;
            do {
                count++;
                if (count > 1)
                    needHeader = true;
                if (needHeader) header();
                Console.WriteLine(message);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"[1] {yes}");
                Console.WriteLine($"[2] {no}");
                Console.ResetColor();
                Console.Write("Plese select 1 or 2: ");
                int.TryParse(Console.ReadLine(), out choice);

            } while (choice < 1 || choice > 2);
            return choice;
        }

        public static void menu(Client myCustomer) // MAIN MENU - BACK END
        {
            int choice = 0;
            // infinite loop with a break point.
            while (true)
            {
                // displays the menu
                int all = myCustomer.allAccounts.Count;
                Client.makeChoice(ref choice, myCustomer.name);

                if (choice == 1)
                {
                    string type = Account.selectType();
                    header();
                    myCustomer.OpenAccount(type);
                    saveToFile(myCustomer);
                    continueOrExit(myCustomer.name);
                }
                else if (choice == 2)
                {
                    if (all == 0)
                        myCustomer.noAccounts();
                    else
                    {
                        int index = myCustomer.select("close");
                        myCustomer.CloseAccount(index);
                    }
                }
                else if (choice == 3) // LIST ALL ACCOUNTS
                {
                    header();
                    if (all == 0)
                        myCustomer.noAccounts();
                    else
                    {
                        myCustomer.listOpen();
                        saveToFile(myCustomer);
                        continueOrExit(myCustomer.name);
                    }
                }
                else if (choice == 4)
                {
                    if (all == 0)
                        myCustomer.noAccounts();
                    else
                    {
                        int deposit = 0;
                        int indexToDeposit = myCustomer.selectAndDeposit(out deposit);
                        myCustomer.Deposit(indexToDeposit, deposit);
                    }
                }
                else if (choice == 5)
                {
                    if (all == 0)
                        myCustomer.noAccounts();
                    else
                    {
                        int withdraw = 0;
                        int indexToDeposit = myCustomer.selectAndWithdraw(out withdraw);
                        withdraw = -withdraw;
                        myCustomer.Deposit(indexToDeposit, withdraw);
                    }
                }
                else if (choice == 6)
                {
                    if (all == 0)
                        myCustomer.noAccounts();
                    else
                    {
                        int index = myCustomer.select("get information for");
                        myCustomer.allAccounts[index-1].PrintInfo();
                    }
                }
                else
                {
                    saveToFile(myCustomer);
                    Client.thankYou();
                    break;
                }
            }
        }

        public static void header() // PRINTS THE HEADER WITH DATE AND TIME
        {
            DateTime dt = DateTime.Now;
            string date = dt.ToString("yyyy-MM-dd");
            string time = dt.ToString("HH:mm");

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("=======================================");
            Console.WriteLine("=               BIG BANK              =");
            Console.WriteLine("=======================================");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{date}                  Time: {time}\n");
            Console.ResetColor();
        }

        public static void continueOrExit(string name) // ASKS CLIENT IF HE?SHE WANTS TO CONTINUE
        {
            if (yesNo($"Would you like to continue, {name}?", "Yes", "No, quit", false) == 2)
            {
                Client.thankYou();
                System.Environment.Exit(0);
            }
        }

        public static void saveToFile(Client toSave) // SAVES CLIENTS INFO IN A TXT FILE AS JSON
        {
            string json = JsonConvert.SerializeObject(toSave);
            string fileName = "clients/" + toSave.name.ToLower() + toSave.lastName.ToLower() + ".txt";
            System.IO.File.WriteAllText(fileName, json);
        }

        // CHECKS IF CUSTOMER IS IN THE DATABASE
        public static bool checkStatus(string[] person, out Client toCheck)
        {
            string fileName = "clients/" + person[2] + ".txt";
            if (System.IO.File.Exists(fileName))
            {
                string text = System.IO.File.ReadAllText(fileName);
                toCheck = JsonConvert.DeserializeObject<Client>(text);
                return true;
            }
            toCheck = new Client();
            return false;
        }

        // APOLOGIZES & AND ASKS CLIENT IF HE WANTS TO TRY AGAIN
        public static int appologize(string[] person)
        {
            header();
            Client.red("Sorry, but we couldn't find your profile! If you would like to try again, please make sure that you spelled your name correctly.");

            if (yesNo($"Would you like to continue, {person[0]}?", "Yes", "No, quit", false) == 2)
            {
                Client.thankYou();
                System.Environment.Exit(0);
            }
            else
            {
                if (yesNo($"What would you like to do next, {person[0]}?", "Try again", "I want to open an account in BIG BANK", true) == 2)
                {
                    return 2;
                }
            }
            return 1;
        }
    }
}