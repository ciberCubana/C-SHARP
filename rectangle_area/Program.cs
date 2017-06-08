using System;

namespace rectangle_area
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 3;
            int b = 4;
            int result = rectangle_area(a,b);
            Console.WriteLine("Area of a rectangle 4 cm long and 3 cm wide  is " + result + "cm^2" );
        }

        static int rectangle_area(int a, int b){
            return a*b;
        }
    }
}
