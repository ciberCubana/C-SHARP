using System;
using System.Collections.Generic;

namespace shapesClass
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    public abstract class shapes
    {
        public String Name {get; set;}
        public int x {get; set;}
        public int y {get; set;}

        public abstrac double Area(){
            throw new NotImplementedException();
        }

        public virtual double Perimetro(){
            return 2 * (large + high);
        }
    }

    class Square : shapes
    {
        public double Size {get; set;}
        public override double Area(){
                return Size * Size;
        }
        public override double Perimetro(){

        }
    }

    class circle : shapes
    {
        public double radius {get;set;}
        public override double Area(){
            return Math.PI * Math.Pow(radius,2);
        }
        public override double Perimetro(){

        }
    }
}
