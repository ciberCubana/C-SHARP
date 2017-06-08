using System;
 namespace MenuDriver{
 class Program
    {
        static void ShowMenu()
        {
            Console.WriteLine("*******************");
            Console.WriteLine("Please select your choice");
            Console.WriteLine("1 - List Animals");
            Console.WriteLine("2 - Add Dog");
            Console.WriteLine("2 - Add Cat");

            Console.WriteLine("q - ");
            Console.WriteLine("*******************");
            Console.WriteLine(">  ");
        }
        static void Main(string[] args)
        {
            string choice = string.Empty;
            do
            {
                ShowMenu();
                choice = Console.ReadLine().ToLower();

                switch (choice)
                {

                }
            }
            while (choice != "q");
        }
    }

 }