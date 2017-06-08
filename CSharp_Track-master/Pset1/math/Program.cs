using System;

namespace math
{
	class Program
	{
		static void Main(string[] args)
		{
			int number;
			do
			{
				Console.Write("Please, pick any integer from 1 to 10: ");
				string input = Console.ReadLine();
				int.TryParse(input, out number);
			} while (number < 1 || number > 10);

			Console.Write("\n");
			for (int i = 1; i <= number; i++)
			{
				for (int j = 1; j <= number; j++)
				{
					Console.Write("{0,4:#}", i * j);
				}
				Console.Write("\n\n");
			}
		}
	}
}
