using System.Numerics;

namespace Lab4
{
	internal class Program
	{
		static void Main(string[] args)
		{
			TestAPlusBSquare(new Frac(1, 3), new Frac(1, 6));
			TestAPlusBSquare(new ComplexNumber(1, 3), new ComplexNumber(1, 6));
			TestMultiplicationAndDivision(new Frac(1, 3), new Frac(1, 6));
			TestMultiplicationAndDivision(new ComplexNumber(1, 3), new ComplexNumber(1, 6));

			Console.ReadKey();

			List<Frac> fractions = new List<Frac>
			{
				new Frac(1, 2),
				new Frac(3, 4),
				new Frac(1, 4),
				new Frac(5, 6)
			};

			fractions.Sort();

			foreach (var frac in fractions)
			{
				Console.WriteLine(frac);
			}
		}

		static void TestMultiplicationAndDivision<T>(T a, T b) where T : IMyNumber<T>
		{
			Console.WriteLine("=== Starting testing multiplication and division with a = " + a + ", b = " + b + " ===");

			T multiplicationResult = a.Multiply(b);
			Console.WriteLine("a * b = " + multiplicationResult);

			try
			{
				T divisionResult = a.Divide(b);
				Console.WriteLine("a / b = " + divisionResult);
			}
			catch (DivideByZeroException)
			{
				Console.WriteLine("Cannot divide by zero.");
			}

			Console.WriteLine("=== Finishing testing multiplication and division with a = " + a + ", b = " + b + " ===");
		}

		static void TestAPlusBSquare<T>(T a, T b) where T : IMyNumber<T>
		{
			Console.WriteLine("=== Starting testing (a+b)^2=a^2+2ab+b^2 with a = " + a + ", b = " + b + " ===");
			T aPlusB = a.Add(b);
			Console.WriteLine("a = " + a);
			Console.WriteLine("b = " + b);
			Console.WriteLine("(a + b) = " + aPlusB);
			Console.WriteLine("(a+b)^2 = " + aPlusB.Multiply(aPlusB));
			Console.WriteLine(" = = = ");
			T curr = a.Multiply(a);
			Console.WriteLine("a^2 = " + curr);
			T wholeRightPart = curr;
			curr = a.Multiply(b); // ab
			curr = curr.Add(curr); // ab + ab = 2ab
								   // I’m not sure how to create constant factor "2" in more elegant way,
								   // without knowing how IMyNumber is implemented
			Console.WriteLine("2*a*b = " + curr);
			wholeRightPart = wholeRightPart.Add(curr);
			curr = b.Multiply(b);
			Console.WriteLine("b^2 = " + curr);
			wholeRightPart = wholeRightPart.Add(curr);
			Console.WriteLine("a^2+2ab+b^2 = " + wholeRightPart);
			Console.WriteLine("=== Finishing testing (a+b)^2=a^2+2ab+b^2 with a = " + a + ", b = " + b + " ===");
		}
	}
}