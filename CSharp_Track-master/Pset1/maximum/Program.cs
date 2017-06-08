using System;
using System.Collections.Generic;
using System.Linq;

namespace max
{
    class Program
    {
        static void Main(string[] args)
        {
            
            string[] input;
            bool status;
            int answer;
            do {
                Console.Write("Please, provide integers, separated with a space: ");
                // gets string from user
                input = Console.ReadLine().Split(' ');
                answer = Max(input, out status);
            } while (input.Length < 1 || status != true);

            Console.WriteLine($"Max value is: {answer}");
        }
        
        /********************************/
        /* FINDS MAX VALUE IN THE ARRAY */
        /********************************/
        static int Max(string[] array, out bool status)
        {
            int number;
            int[] numbers = new int[array.Length];
            int index = 0;
            status = false;
            // casting strings to int
            foreach(string temp in array)
            {
                if (int.TryParse(temp, out number))
                {
                    numbers[index] = number;
                    index++;
                }
            }
            // if there is at least 1 int change status
            if (index != 0)
                status = true;
            return numbers.Max();
        }
    }
}