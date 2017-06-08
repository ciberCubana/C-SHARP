using System;
using System.Collections.Generic;

namespace today
{

    public abstract class Animal
    {
        public abstract void MakeNoise();

        public void Eat() { }
    }

    public class Cat : Animal
    {
        public void Scratch() { }
        public override void MakeNoise()
        {
            Console.WriteLine("Meow");
        }
    }



public class Dog : Animal
    {
        public void Dig() { }

        public void Jump() { }
        public override void MakeNoise()
        {
            Console.WriteLine("Bark");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Cat myCat = new Cat();

            Animal myDog = new Dog();
            myDog.Dig();

            List<Animal> zoo = new List<Animal>();

            zoo.Add(myCat);
            zoo.Add(myDog);

        }

        static void ProcessAnimals(List<Animal> roster) {

            foreach (Animal selection in roster) {
                if (selection is Dog) {
                    Dog casted = selection as Dog;
                    casted.Dig();
                    casted.Jump();
                }
                selection.MakeNoise();
            }
        }
    }
}
