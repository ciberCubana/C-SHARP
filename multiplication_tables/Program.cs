using System;

namespace multiplication_tables
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Give me an integer:");
            int n = Convert.ToInt32(Console.ReadLine());
            multiplication_tables(n);
        }

        static void multiplication_tables(int n){
            for(int i = 1; i <= n; i++ ){
                for(int j = 1; j <= n; j++){                    
                     Console.Write(" "+ i*j);
                }
                Console.WriteLine("");
            }
        }
    }
}
