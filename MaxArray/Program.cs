using System;
using System.Linq;

namespace MaxArray
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Dimension of array????");
            int len = Convert.ToInt32(Console.ReadLine());
            int [] arr =  new int [len];
            
            for(int i = 0 ; i < len; i++){
                Console.WriteLine("Give me integer numbers to fill up your array:");
                int number = Convert.ToInt32(Console.ReadLine());
                arr[i]= number; 
            }
            Console.WriteLine("The max element in you array is: "+ MaxArray(arr));

        }

       public static int MaxArray(int[]a)
            {
            int max = a[0];
            for(int i = 0 ; i< a.Length ; i++)
                if(a[i] > max)
                    max = a[i];
            return max;
            }
        }
    }

