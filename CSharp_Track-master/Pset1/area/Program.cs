using System;

namespace area
{
	class Program
	{
		static void Main(string[] args)
		{
			int sideA = 10;
			int sideB = 20;
			Console.WriteLine($"Rectangle {sideA} ft X {sideB} ft has area = {area(sideA, sideB)} sq.ft!");
		}

		static int area(int a, int b)
		{
			return a * b;
		}
	}
}
