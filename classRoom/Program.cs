using System;

namespace classRoom
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }


    class classRoom
    {
        public int numberDesk { get; set; }
        public int roomNumber { get; set; }
    }

    

         class Student {
        public string FirstName { get; set; }
        public string LastName {get; set; }

        public void SitDown(Desk myDesk) {
            myDesk.IsOccupied = true;
        }
    }

    class Desk {
        public bool IsOccupied { get;set; }
    }

    }

