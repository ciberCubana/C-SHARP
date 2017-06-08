using System;
using System.Collections.Generic;

namespace classes
{

    public class Box {
        public double Length { get;set; }
        public double Width { get;set; }
        public double Height { get;set; }

        public double Volume() {
            return Length * Height * Width;
        }
    }

    public class Container {
        public double MaxVolume { get;set; }
        public List<Box> ShippingBoxes {get;set; }

        public Container(double maxVolume) {
            this.MaxVolume = maxVolume;
            this.ShippingBoxes = new List<Box>();
        }

         public Container(double maxVolume, string color) {
            this.MaxVolume = maxVolume;
            this.ShippingBoxes = new List<Box>();
        }
        public double OccupiedSpace() {

            double totalVolume = 0;
            foreach (Box littleBox in ShippingBoxes) {
                totalVolume += littleBox.Volume();
            }

            return totalVolume;
        }
    }

    class Program
    {
        static void ShowMenu()
        {
            Console.WriteLine("*******************");
            Console.WriteLine("Please select your choice");
            Console.WriteLine("1 - List Animals");
            Console.WriteLine("2 - Add Dog");
            Console.WriteLine("2 - Add Cat");

            Console.WriteLine("q - Quit");
            Console.WriteLine("*******************");
            Console.Write("> ");
        }

        static void Run()
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
        static void Main(string[] args)
        {
            Container iPhoneContainer = new Container(123.0);
            Box box1 = new Box();
            box1.Height = 2.0;
            box1.Width = 3.0;
            box1.Length = 3.0;

             Box box2 = new Box();
            box2.Height = 1.0;
            box2.Width = 3.0;
            box2.Length = 3.2;

            iPhoneContainer.ShippingBoxes.Add(box1);
            iPhoneContainer.ShippingBoxes.Add(box2);

            Console.WriteLine("Occupied space = " + iPhoneContainer.OccupiedSpace());
            Console.WriteLine("Remaining space = " + (iPhoneContainer.MaxVolume - iPhoneContainer.OccupiedSpace()));

        }


    }
}
