using System;
using System.Collections.Generic;

namespace classes
{
     class Animal
    {
        public int Age { get; set; }
        public virtual void MakeNoise() { }

    }
    class Dog : Animal
    {
        public override void MakeNoise()
        {
            Console.WriteLine("Bark");
        }
    }

    class Cat : Animal
    {
        public override void MakeNoise()
        {
            Console.WriteLine("Meow");
        }
    }

    class Ant :Animal {
        public override void MakeNoise() { }
    }

    public abstract class Shape {
        public string Name { get; set; }
        public abstract double Area();
    }

    public class Circle : Shape
    {
        public Circle() {
            this.Name = "Circle";
        }
        public double Radius { get;set; }
        public override double Area()
        {
            return Math.PI * Math.Pow(Radius, 2);
        }
    }

    public class Square : Shape
    {
        public Square() {
            this.Name = "Square";
        }
        public double Size {get;set; }
        public override double Area()
        {
            return Size * Size;
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

            Circle myCircle = new Circle();
            
            Dog myDog = new Dog();
            myDog.Age = 4;


            Cat yourCat = new Cat();
            yourCat.Age = 12;


            Ant ant = new Ant();

            List<Animal> zoo = new List<Animal>();

            zoo.Add(myDog);
            zoo.Add(yourCat);
            zoo.Add(ant);

            WakeTheAnimals(zoo);

        }

        static void WakeTheAnimals(List<Animal> myAnimals) {

            foreach (Animal sleepyAnimal in myAnimals) {
                sleepyAnimal.MakeNoise();
            }
        }
    }
}