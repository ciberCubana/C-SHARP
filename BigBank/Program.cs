using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;


namespace BigBank
{
    class Program
    {

        static void ShowMenu()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("                    ");
            Console.WriteLine("                                         MENU  ");
            Console.WriteLine("                    ");
             Console.WriteLine("                   ***************************************************************************"); 
            Console.WriteLine("                   *       [1] - Create an account     [5] - View all my account staments    *");
            Console.WriteLine("                   *       [2] - Make a deposit        [6] - Make a transference             *");
            Console.WriteLine("                   *       [3] - Withdraw Funs         [7] - Export information              *");
            Console.WriteLine("                   *       [4] - Remove an account     [8] - Change user                     *");
            Console.WriteLine("                   *                                   [q] - Exit                            *");
            Console.WriteLine("                   ***************************************************************************"); 
        }

        static void ShowMenuAccountType()
        {
            Console.WriteLine("                                 ***************************************************");   
            Console.WriteLine("                                 What type of account do you want to create today?");
            Console.WriteLine("                                      [1] - Savings Account");
            Console.WriteLine("                                      [2] - Checking Account");
            Console.WriteLine("                                      [q] - Quit");
            Console.WriteLine("                                 ****************************************************");          
        }

        static void ShowMenuDeposit()
        {
            Console.WriteLine("                                 ***************************************************");   
            Console.WriteLine("                                      [1] - Savings Account");
            Console.WriteLine("                                      [2] - Checking Account");
            Console.WriteLine("                                      [q] - Quit");
            Console.WriteLine("                                 ****************************************************");          
        }

       

        public class Customer{
            
        public Customer(String nameCustomer) 
        {
            this.nameCustomer = nameCustomer;
               
        }
            public String nameCustomer{get; set;}
            public List<SavingsAccount> sac = new List<SavingsAccount>();
            public List<CheckingAccount> cal = new List<CheckingAccount>();

        }

        public class Account {
            public int accNumber{get;set;}
            public decimal balance {get;set;}
            public double interestRate {get; set;}
             
            public virtual decimal Balance {
                get {return balance;}
            }

            public virtual void Withdraw (decimal quantity) {
                balance -= quantity;
            }

            public virtual void Deposit (decimal quantity) {
                balance += quantity;
            }

            public virtual void AddInterests() {
                balance += balance * (decimal)interestRate;
            }              
            } 
        
            public class CheckingAccount: Account {

                public override void Withdraw (decimal amount) {
                        if (amount < balance)
                            balance -= amount;
                        else
                            throw new Exception("Insufficient balance cannot withdraw...Sorry!!");
                    }
                } 

                public class SavingsAccount: Account {

                    public override void Withdraw (decimal quantity) {
                    balance -= quantity;
                    if (quantity < balance)
                        interestRate = -1.5;
                    }

                    public override void AddInterests() {
                        balance = balance + balance * (decimal)interestRate - 100.0M;
                    }   
                }  
        
        static void Main(string[] args)
        {
            Console.Clear();
            string choice = string.Empty;
            string choice1= string.Empty;
            string path = @"c:\temp\MyTest.txt";
            
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("                                        ***********************************");
            Console.WriteLine("                                        *      Welcome to Big Bank Inc.   *");
            Console.WriteLine("                                        ***********************************");
            Console.WriteLine("                             ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("                                                Customer's Name??");
            String name =  Console.ReadLine();

            Console.WriteLine("                    ");
            Console.WriteLine("                             Hi "  + name + " what would you like to do today?" );
            Customer c = new Customer(name);
            List<SavingsAccount> sac = new List<SavingsAccount>();
            List<CheckingAccount> cal = new List<CheckingAccount>();
             
            
            do
            {
                ShowMenu();
                choice = Console.ReadLine().ToLower();
                 Console.Clear();

                switch (choice)
                {
                    case "1"  : //Create an account
                        ShowMenuAccountType();
                        choice1 = Console.ReadLine().ToLower();

                        switch (choice1)
                            {
                                case "1"  : //Saving Account
                                    Console.Clear();                                                                     
                                    SavingsAccount sa = new SavingsAccount();                                                                 
                                    Random rnd = new Random();
                                    sa.accNumber = rnd.Next(100000000,999999999);                                 
                                    sac.Add(sa);                                 
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("                                            New Saving Account was created!! ");
                                    Console.WriteLine("                                             ");
                                    Console.WriteLine("                                               Account Number: "+ sa.accNumber);                  
                                    Console.WriteLine("                                                Interest Rate: 1.5 %");
                                    Console.WriteLine("                                                      Balance: "+ sa.balance);  
                                break; 
                                case "2"  :   //Checking Account
                                  Console.Clear();                                                                     
                                    CheckingAccount ch = new CheckingAccount();                              
                                    Random r = new Random();
                                    ch.accNumber = r.Next(100000000,999999999);                                 
                                    cal.Add(ch);
                                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                                    Console.WriteLine("                                            New Checking Account was created!! ");
                                    Console.WriteLine("                                             ");
                                    Console.WriteLine("                                               Account Number: "+ ch.accNumber);                  
                                    Console.WriteLine("                                                Interest Rate: 0 %");
                                    Console.WriteLine("                                                      Balance: "+ ch.balance);
                                 break;                            
                            }
                    break; 
                    case "2"  :   //deposit
                                    Console.Clear();
                                    string choiced = string.Empty;
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("                                        In what type of account do you want to make a deposit?");
                                    ShowMenuDeposit();
                                    choiced = Console.ReadLine().ToLower();
                                    switch (choiced){
                                                        case "1"  : //Saving Account Deposit
                                                            Console.Clear();
                                                            Console.ForegroundColor = ConsoleColor.Green;
                                                            int indexDeposito = 1;
                                                            Console.WriteLine("                                                   SAVING ACCOUNTS    ");
                                                            Console.WriteLine("                                    ---------------------------------------------    ");
                                                            Console.WriteLine("                                    Index | AccNumber   | Balance | Interest Rate");
                                                            Console.WriteLine("                                    ---------------------------------------------");         
                                                                    foreach (SavingsAccount savA in sac ){                                    
                                                            Console.WriteLine("                                    "+indexDeposito   +"         "+ sac[indexDeposito-1].accNumber + "      " + sac[indexDeposito-1].balance + "           1.5 %");                  
                                                                        indexDeposito++;
                                                                    } 
                                                    Console.WriteLine(" ");
                                                    Console.ForegroundColor = ConsoleColor.Red;
                                                    Console.WriteLine("                                 Enter the index of the account in which you want to deposit money");
                                                    int ind = int.Parse(Console.ReadLine().ToLower());
                                                    
                                                            if(ind <= sac.Count){
                                                                Console.WriteLine("                                     Enter the amount of money to deposit"); 
                                                            decimal qu = decimal.Parse(Console.ReadLine());   
                                                            sac[ind-1].Deposit(qu);
                                                            Console.ForegroundColor = ConsoleColor.Green;
                                                            Console.WriteLine("                                            Your deposit was successfull!! ");
                                                            Console.WriteLine("                                             ");
                                                            Console.WriteLine("                                               Account Number: "+ sac[ind-1].accNumber);                  
                                                            Console.WriteLine("                                                Interest Rate: 1.5 %");
                                                            Console.WriteLine("                                                      Balance: "+ sac[ind-1].balance); 

                                                            }else{
                                                                Console.Clear();
                                                                Console.WriteLine("                                      ERROR--------- Try again, your index is out of range!!!!!!!!!!!");
                                                            
                                                            }
                                                    
                                                                                                                                   
                                                                                                    
                                    break; 
                                                case "2"  : //Checking Account Deposit
                                                            Console.Clear();
                                                            Console.ForegroundColor = ConsoleColor.DarkMagenta;
                                                            int indexDeposito1 = 1;
                                                            Console.WriteLine("                                                   CHECKING ACCOUNTS    ");
                                                            Console.WriteLine("                                    ---------------------------------------------    ");
                                                            Console.WriteLine("                                    Index | AccNumber   | Balance | Interest Rate");
                                                            Console.WriteLine("                                    ---------------------------------------------");         
                                                                    foreach (CheckingAccount che in cal ){                                    
                                                            Console.WriteLine("                                    "+indexDeposito1   +"         "+ cal[indexDeposito1-1].accNumber + "      " + cal[indexDeposito1-1].balance + "           1.5 %");                  
                                                                        indexDeposito1++;
                                                                    } 
                                                    Console.WriteLine(" ");
                                                    Console.ForegroundColor = ConsoleColor.Red;
                                                    Console.WriteLine("                                     Enter the index of the account in which you want to deposit money");
                                                    int inde = int.Parse(Console.ReadLine().ToLower());
                                                    
                                                    if(inde <= cal.Count){
                                                    Console.WriteLine("                                     Enter the amount of money to deposit"); 
                                                    decimal qua = decimal.Parse(Console.ReadLine());   
                                                    cal[inde-1].Deposit(qua);
                                                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                                                    Console.WriteLine("                                            Your deposit was successfull!! ");
                                                    Console.WriteLine("                                             ");
                                                    Console.WriteLine("                                               Account Number: "+ cal[inde-1].accNumber);                  
                                                    Console.WriteLine("                                                Interest Rate: 1.5 %");
                                                    Console.WriteLine("                                                      Balance: "+ cal[inde-1].balance);                                                                                
                                                       } else {
                                                                Console.Clear();
                                                                Console.WriteLine("                                      ERROR--------- Try again, your index is out of range!!!!!!!!!!!");
                                                            
                                                            }
                                                                                   
                                                break;                                                    
                            }     
                    break; 
                    case "3"  :   //withdraw 
                                    Console.Clear();
                                    string choicew = string.Empty;
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("                                        In what type of account do you want to make a withdraw?");
                                    ShowMenuDeposit();
                                    choicew = Console.ReadLine().ToLower();
                                    switch (choicew){
                                                        case "1"  : //Saving Account withdraw
                                                            Console.Clear();
                                                            Console.ForegroundColor = ConsoleColor.Green;
                                                            int indexDeposito = 1;
                                                            Console.WriteLine("                                                   SAVING ACCOUNTS    ");
                                                            Console.WriteLine("                                    ---------------------------------------------    ");
                                                            Console.WriteLine("                                    Index | AccNumber   | Balance | Interest Rate");
                                                            Console.WriteLine("                                    ---------------------------------------------");         
                                                                    foreach (SavingsAccount savA in sac ){                                    
                                                            Console.WriteLine("                                    "+indexDeposito   +"         "+ sac[indexDeposito-1].accNumber + "      " + sac[indexDeposito-1].balance + "           1.5 %");                  
                                                                        indexDeposito++;
                                                                    } 
                                                    Console.WriteLine(" ");
                                                    Console.ForegroundColor = ConsoleColor.Red;
                                                    Console.WriteLine("                                 Enter the index of the account in which you want to withdraw money");
                                                    int ind = int.Parse(Console.ReadLine().ToLower());
                                                    if(ind <= sac.Count){
                                                    Console.WriteLine("                                     Enter the amount of money to withdraw"); 
                                                    decimal qu = decimal.Parse(Console.ReadLine());   
                                                    sac[ind-1].Withdraw(qu);
                                                    Console.ForegroundColor = ConsoleColor.Green;
                                                    Console.WriteLine("                                            Your withdraw was successfull!! ");
                                                    Console.WriteLine("                                             ");
                                                    Console.WriteLine("                                               Account Number: "+ sac[ind-1].accNumber);                  
                                                    Console.WriteLine("                                                Interest Rate: 1.5 %");
                                                    Console.WriteLine("                                                      Balance: "+ sac[ind-1].balance); 
                                                    } else {
                                                                Console.Clear();
                                                                Console.WriteLine("                                      ERROR--------- Try again, your index is out of range!!!!!!!!!!!");
                                                            
                                                            }                                                                
                                                                                                    
                                    break; 
                                                case "2"  : //Checking Account withdraw
                                                            Console.Clear();
                                                            Console.ForegroundColor = ConsoleColor.DarkMagenta;
                                                            int indexDeposito1 = 1;
                                                            Console.WriteLine("                                                   CHECKING ACCOUNTS    ");
                                                            Console.WriteLine("                                    ---------------------------------------------    ");
                                                            Console.WriteLine("                                    Index | AccNumber   | Balance | Interest Rate");
                                                            Console.WriteLine("                                    ---------------------------------------------");         
                                                                    foreach (CheckingAccount che in cal ){                                    
                                                            Console.WriteLine("                                    "+indexDeposito1   +"         "+ cal[indexDeposito1-1].accNumber + "      " + cal[indexDeposito1-1].balance + "           1.5 %");                  
                                                                        indexDeposito1++;
                                                                    } 
                                                    Console.WriteLine(" ");
                                                    Console.ForegroundColor = ConsoleColor.Red;               
                                                    Console.WriteLine("                                     Enter the index of the account in which you want to withdraw money");
                                                    int inde = int.Parse(Console.ReadLine().ToLower());
                                                    if(inde<= cal.Count){
                                                    Console.WriteLine("                                     Enter the amount of money to withdraw"); 
                                                    decimal qua = decimal.Parse(Console.ReadLine());   
                                                    cal[inde-1].Withdraw(qua);
                                                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                                                    Console.WriteLine("                                            Your withdraw was successfull!! ");
                                                    Console.WriteLine("                                             ");
                                                    Console.WriteLine("                                               Account Number: "+ cal[inde-1].accNumber);                  
                                                    Console.WriteLine("                                                Interest Rate: 1.5 %");
                                                    Console.WriteLine("                                                      Balance: "+ cal[inde-1].balance);                                                                                
                                                                   } else {
                                                                Console.Clear();
                                                                Console.WriteLine("                                      ERROR--------- Try again, your index is out of range!!!!!!!!!!!");
                                                            
                                                            }                                 
                                                break;
                                    }
                     break;  
                     case "4"  :   //Remove Account
                                    Console.Clear();
                                    string choicer = string.Empty;
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("                                        In what type of account do you want to make a remove?");
                                    ShowMenuDeposit();
                                    choicew = Console.ReadLine().ToLower();
                                    switch (choicew){
                                                        case "1"  : //Saving Account remove
                                                            Console.Clear();
                                                            Console.ForegroundColor = ConsoleColor.Green;
                                                            int indexDeposito = 1;
                                                            Console.WriteLine("                                                   SAVING ACCOUNTS    ");
                                                            Console.WriteLine("                                    ---------------------------------------------    ");
                                                            Console.WriteLine("                                    Index | AccNumber   | Balance | Interest Rate");
                                                            Console.WriteLine("                                    ---------------------------------------------");         
                                                                    foreach (SavingsAccount savA in sac ){                                    
                                                            Console.WriteLine("                                    "+indexDeposito   +"         "+ sac[indexDeposito-1].accNumber + "      " + sac[indexDeposito-1].balance + "           1.5 %");                  
                                                                        indexDeposito++;
                                                                    } 
                                                    Console.WriteLine(" ");
                                                    Console.ForegroundColor = ConsoleColor.Red;
                                                    Console.WriteLine("                                 Enter the index of the account which you want remove from your accounts");
                                                    int ind = int.Parse(Console.ReadLine().ToLower());
                                                    if(ind <= sac.Count){
                                                    sac.RemoveAt(ind-1);
                                                    Console.WriteLine("                                            Removed successfully !! ");
                                                    } else {
                                                                Console.Clear();
                                                                Console.WriteLine("                                      ERROR--------- Try again, your index is out of range!!!!!!!!!!!");
                                                            
                                                            }
                                                                                                                                   
                                                                                                    
                                    break; 
                                                case "2"  : //Checking Account remove
                                                            Console.Clear();
                                                            Console.ForegroundColor = ConsoleColor.DarkMagenta;
                                                            int indexDeposito1 = 1;
                                                            Console.WriteLine("                                                   CHECKING ACCOUNTS    ");
                                                            Console.WriteLine("                                    ---------------------------------------------    ");
                                                            Console.WriteLine("                                    Index | AccNumber   | Balance | Interest Rate");
                                                            Console.WriteLine("                                    ---------------------------------------------");         
                                                                    foreach (CheckingAccount che in cal ){                                    
                                                            Console.WriteLine("                                    "+indexDeposito1   +"         "+ cal[indexDeposito1-1].accNumber + "      " + cal[indexDeposito1-1].balance + "           1.5 %");                  
                                                                        indexDeposito1++;
                                                                    } 
                                                                    Console.WriteLine(" ");
                                                                    Console.ForegroundColor = ConsoleColor.Red;
                                                   Console.WriteLine("                                 Enter the index of the account which you want remove from your accounts");
                                                    int inde = int.Parse(Console.ReadLine().ToLower());
                                                    if(inde <= cal.Count){
                                                    cal.RemoveAt(inde-1);
                                                    Console.ForegroundColor = ConsoleColor.Red;
                                                    Console.WriteLine("                                            Removed successfully !! ");  
                                                    } else {
                                                                Console.Clear();
                                                                Console.WriteLine("                                      ERROR--------- Try again, your index is out of range!!!!!!!!!!!");
                                                            
                                                            }              
                                                break;
                                    }                
                     break;
                     case "5"  :   //View all accounts
                              Console.ForegroundColor = ConsoleColor.Green;
                              int indexAcc = 1;
                              Console.WriteLine("                                                   SAVING ACCOUNTS    ");
                              Console.WriteLine("                                    ---------------------------------------------    ");
                              Console.WriteLine("                                    Index | AccNumber   | Balance | Interest Rate");
                              Console.WriteLine("                                    ---------------------------------------------");         
                                    foreach (SavingsAccount savA in sac ){                                    
                              Console.WriteLine("                                    "+indexAcc   +"         "+ sac[indexAcc-1].accNumber + "      " + sac[indexAcc-1].balance + "           1.5 %");                  
                                        indexAcc++;
                                    }  

                             Console.WriteLine(" ");         
                             Console.ForegroundColor = ConsoleColor.DarkMagenta;            
                             int indexAccCheck = 1;
                              Console.WriteLine("                                                   CHECKING ACCOUNTS    ");
                              Console.WriteLine("                                    ---------------------------------------------    ");
                              Console.WriteLine("                                    Index | AccNumber   | Balance | Interest Rate");
                              Console.WriteLine("                                    ---------------------------------------------");    
                                    foreach (CheckingAccount checA in cal ){              
                             Console.WriteLine("                                     "+ indexAccCheck + "      "  + cal[indexAccCheck-1].accNumber + "        " + cal[indexAccCheck-1].balance + "        0 %");                                                             
                                        indexAccCheck++;
                                    }    
                    break;  
                    case "6"  :   //Transference
                              Console.ForegroundColor = ConsoleColor.Red;
                              Console.WriteLine("                                 Select the type of the account from which you want transfer money");
                              ShowMenuDeposit();
                              choicew = Console.ReadLine().ToLower();
                                            if( choicew == "1"){
                                            Console.ForegroundColor = ConsoleColor.Green;
                                            int indexAcco = 1;
                                            Console.WriteLine("                                                   SAVING ACCOUNTS    ");
                                            Console.WriteLine("                                    ---------------------------------------------    ");
                                            Console.WriteLine("                                    Index | AccNumber   | Balance | Interest Rate");
                                            Console.WriteLine("                                    ---------------------------------------------");         
                                                    foreach (SavingsAccount savA in sac ){                                    
                                            Console.WriteLine("                                    "+indexAcco   +"         "+ sac[indexAcco-1].accNumber + "      " + sac[indexAcco-1].balance + "           1.5 %");                  
                                                        indexAcco++;
                                                    }  
             
                                            Console.WriteLine(" ");
                                            Console.ForegroundColor = ConsoleColor.Red;
                                            Console.WriteLine("                                 Enter the index of the account from which you want transfer money");
                                            int i1 = int.Parse(Console.ReadLine().ToLower());
                                                            Console.Clear();
                                                            Console.WriteLine("                                 Select the type of the account to deposit the transfer money");
                                                            Console.ForegroundColor = ConsoleColor.Blue;
                                                            ShowMenuDeposit();
                                                            choicew = Console.ReadLine().ToLower();
                                                                if(choicew == "1"){ //transferir de cuenta de savings a  cuenta de savings
                                                                        Console.ForegroundColor = ConsoleColor.Green;
                                                                        int indexAccon = 1;
                                                                        Console.WriteLine("                                                   SAVING ACCOUNTS    ");
                                                                        Console.WriteLine("                                    ---------------------------------------------    ");
                                                                        Console.WriteLine("                                    Index | AccNumber   | Balance | Interest Rate");
                                                                        Console.WriteLine("                                    ---------------------------------------------");         
                                                                                foreach (SavingsAccount savA in sac ){                                    
                                                                        Console.WriteLine("                                    "+indexAccon   +"         "+ sac[indexAccon-1].accNumber + "      " + sac[indexAccon-1].balance + "           1.5 %");                  
                                                                        indexAccon++;
                                                                    }
                                                                   
                                                                    Console.ForegroundColor = ConsoleColor.Red;
                                                                    Console.WriteLine(" ");
                                                                    Console.WriteLine("                                 Enter the index of the account to deposit the transfer money");
                                                                    int i3 = int.Parse(Console.ReadLine().ToLower());
                                                                                    
                                                                                    Console.WriteLine("                                 Enter the amount to transfer");
                                                                                    decimal am = decimal.Parse(Console.ReadLine().ToLower());
                                                                                    sac[i1-1].Withdraw(am);
                                                                                    sac[i3-1].Deposit(am);
                                                                                    Console.ForegroundColor = ConsoleColor.Green;
                                                                                    Console.WriteLine("                                            Transference successfull !! ");
                                                                                    
                                                                     
                                                        
                                                                
                                
                                 //transferir de savings a checking
                              } else{
                                    Console.ForegroundColor = ConsoleColor.DarkMagenta;            
                                    int indexAccChecki = 1;
                                    Console.WriteLine("                                                   CHECKING ACCOUNTS    ");
                                    Console.WriteLine("                                    ---------------------------------------------    ");
                                    Console.WriteLine("                                    Index | AccNumber   | Balance | Interest Rate");
                                    Console.WriteLine("                                    ---------------------------------------------");    
                                            foreach (CheckingAccount checA in cal ){              
                                    Console.WriteLine("                                     "+ indexAccChecki + "      "  + cal[indexAccChecki-1].accNumber + "        " + cal[indexAccChecki-1].balance + "        0 %");                                                             
                                                indexAccChecki++;
                                            }
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine(" ");
                                    Console.WriteLine("                                 Enter the index of the account to deposit the transfer money");
                                    int i7 = int.Parse(Console.ReadLine().ToLower());
                                    Console.WriteLine("                                 Enter the amount to transfer");
                                    decimal am = decimal.Parse(Console.ReadLine().ToLower());
                                    sac[i1-1].Withdraw(am);
                                    cal[i7-1].Deposit(am);
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("                                            Transference successfull !! ");
                                        
                               }

                                 
                                 

                            }else{  //transferir de checking a checking
                              Console.ForegroundColor = ConsoleColor.Red;
                              Console.WriteLine("                                 Select the type of the account from which you want transfer money");
                              ShowMenuDeposit();
                              choicew = Console.ReadLine().ToLower();
                                    
                               Console.ForegroundColor = ConsoleColor.DarkMagenta;            
                                    int indexAccChecki = 1;
                                    Console.WriteLine("                                                   CHECKING ACCOUNTS    ");
                                    Console.WriteLine("                                    ---------------------------------------------    ");
                                    Console.WriteLine("                                    Index | AccNumber   | Balance | Interest Rate");
                                    Console.WriteLine("                                    ---------------------------------------------");    
                                            foreach (CheckingAccount checA in cal ){              
                                    Console.WriteLine("                                     "+ indexAccChecki + "      "  + cal[indexAccChecki-1].accNumber + "        " + cal[indexAccChecki-1].balance + "        0 %");                                                             
                                                indexAccChecki++;
                                            }

                              Console.WriteLine(" ");
                              Console.ForegroundColor = ConsoleColor.Red;
                              Console.WriteLine("                                 Enter the index of the account from which you want transfer money");
                              int i9 = int.Parse(Console.ReadLine().ToLower());
                              Console.Clear();
                              Console.WriteLine("                                 Select the type of the account to deposit the transfer money");
                              Console.ForegroundColor = ConsoleColor.Blue;
                              ShowMenuDeposit();
                              choicew = Console.ReadLine().ToLower();

                                if(choicew == "1"){ //transferir de cuenta de checking a  cuenta de savings
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        int indexAccon = 1;
                                        Console.WriteLine("                                                   SAVING ACCOUNTS    ");
                                        Console.WriteLine("                                    ---------------------------------------------    ");
                                        Console.WriteLine("                                    Index | AccNumber   | Balance | Interest Rate");
                                        Console.WriteLine("                                    ---------------------------------------------");         
                                                foreach (SavingsAccount savA in sac ){                                    
                                        Console.WriteLine("                                    "+indexAccon   +"         "+ sac[indexAccon-1].accNumber + "      " + sac[indexAccon-1].balance + "           1.5 %");                  
                                        indexAccon++;
                                    }
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine(" ");
                                    Console.WriteLine("                                 Enter the index of the account to deposit the transfer money");
                                    int i3 = int.Parse(Console.ReadLine().ToLower());
                                    Console.WriteLine("                                 Enter the amount to transfer");
                                    decimal am = decimal.Parse(Console.ReadLine().ToLower());
                                    cal[i9-1].Withdraw(am);
                                    sac[i3-1].Deposit(am);
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("                                            Transference successfull !! ");
                                   
                                }else{ //transferir de checking a checking
                                    Console.ForegroundColor = ConsoleColor.DarkMagenta;            
                                    int indexAccCheckin = 1;
                                    Console.WriteLine("                                                   CHECKING ACCOUNTS    ");
                                    Console.WriteLine("                                    ---------------------------------------------    ");
                                    Console.WriteLine("                                    Index | AccNumber   | Balance | Interest Rate");
                                    Console.WriteLine("                                    ---------------------------------------------");    
                                            foreach (CheckingAccount checA in cal ){              
                                    Console.WriteLine("                                     "+ indexAccCheckin + "      "  + cal[indexAccCheckin-1].accNumber + "        " + cal[indexAccCheckin-1].balance + "        0 %");                                                             
                                                indexAccCheckin++;
                                            }
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine(" ");
                                    Console.WriteLine("                                 Enter the index of the account to deposit the transfer money");
                                    int i3 = int.Parse(Console.ReadLine().ToLower());
                                    Console.WriteLine("                                 Enter the amount to transfer");
                                    decimal am = decimal.Parse(Console.ReadLine().ToLower());
                                    cal[i9-1].Withdraw(am);
                                    cal[i3-1].Deposit(am);
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("                                            Transference successfull !! ");
                                     
                                } 
                            }
                                 
                    break;
                    case "8":
                    sac.Clear();
                    cal.Clear();
                    Console.Clear();
            
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("                                        ***********************************");
            Console.WriteLine("                                        *      Welcome to Big Bank Inc.   *");
            Console.WriteLine("                                        ***********************************");
            Console.WriteLine("                             ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("                                                Customer's Name??");
            String namenew =  Console.ReadLine();
            Customer cnew = new Customer(namenew);
            File.Delete(path);

            


                    break;
                case "7" :
                     
                        if (!File.Exists(path)) 
                        {
                            using (StreamWriter sw = File.CreateText(path)) 
                            {
                                sw.WriteLine("                                           Welcome to Big Bank Inc.");
                                sw.WriteLine("                                          *************************");
                                sw.WriteLine("                                              Customer Name: " + name);
                                sw.WriteLine("                                                ");
                                sw.WriteLine("                                                 ACCOUNTS STATMENTS");
                                sw.WriteLine("                                                ");
                                sw.WriteLine("                                                ");
                                
                                int i4 = 1;
                              sw.WriteLine("                                                   SAVING ACCOUNTS    ");
                              sw.WriteLine("                                    ---------------------------------------------    ");
                              sw.WriteLine("                                    Index | AccNumber   | Balance | Interest Rate");
                              sw.WriteLine("                                    ---------------------------------------------");         
                                    foreach (SavingsAccount savA in sac ){                                    
                              sw.WriteLine("                                    "+i4   +"         "+ sac[i4-1].accNumber + "      " + sac[i4-1].balance + "           1.5 %");                  
                                        i4++;
                                    }  

                             sw.WriteLine(" ");         
                                         
                             int i5 = 1;
                              sw.WriteLine("                                                   CHECKING ACCOUNTS    ");
                              sw.WriteLine("                                    ---------------------------------------------    ");
                              sw.WriteLine("                                    Index | AccNumber   | Balance | Interest Rate");
                              sw.WriteLine("                                    ---------------------------------------------");    
                                    foreach (CheckingAccount checA in cal ){              
                             sw.WriteLine("                                     "+ i5 + "      "  + cal[i5-1].accNumber + "        " + cal[i5-1].balance + "        0 %");                                                             
                                        i5++;
                                    }    
                            }	
                        }

                        
                        using (StreamReader sr = File.OpenText(path)) 
                        {
                            string s = "";
                            while ((s = sr.ReadLine()) != null) 
                            {
                                Console.WriteLine(s);
                            }
                        }

                break;  
                }
            }
            while (choice != "q");
                         
            File.Delete(path);
            
            Console.Clear(); 
                   
        } 
    }
}     
    
    
            
        
