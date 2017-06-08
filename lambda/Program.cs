using System;
using System.Collections.Generic;
using System.Linq;

namespace lambda2
{
      class Program
    {

        static IEnumerable<int> RetrieveNumbers(Func<int, bool> filterBy)
        {
            var list = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            return list.Where(filterBy);
        }

        static void Main(string[] args)
        {

            Func<int, bool> myFilterFunction = (int x) => x % 3 == 0;

            var result = RetrieveNumbers((x) => x % 2==0);

            foreach (int item in result)
            {
                Console.WriteLine("We got " + item);
            }
        }
    }
}
