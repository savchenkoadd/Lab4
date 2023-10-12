using System;
using System.Numerics;

namespace Lab4
{
	public class Frac : IMyNumber<Frac>, IComparable<Frac>
	{
		private BigInteger _numerator, _denominator;

		public Frac(BigInteger numerator, BigInteger denominator)
		{
			_numerator = numerator;
			_denominator = denominator;
			Reduce();
		}

		public Frac(int num, int denum)
		{
			_numerator = num;
			_denominator = denum;
			Reduce();
		}

		public Frac Add(Frac b)
		{
			var num = (_numerator * b._denominator) + (_denominator * b._numerator);
			var denum = (_denominator * b._denominator);
			return new Frac(num, denum);
		}

		public Frac Divide(Frac b)
		{
			if (b._numerator == 0)
			{
				throw new DivideByZeroException();
			}

			var num = (_numerator * b._denominator);
			var denum = (_denominator * b._numerator);
			return new Frac(num, denum);
		}

		public Frac Multiply(Frac b)
		{
			var num = _numerator * b._numerator;
			var denum = _denominator * b._denominator;
			return new Frac(num, denum);
		}

		public Frac Subtract(Frac b)
		{
			var num = (_numerator * b._denominator) - (_denominator * b._numerator);
			var denum = (_denominator * b._denominator);
			return new Frac(num, denum);
		}

		public override string ToString()
		{
			return $"{_numerator}/{_denominator}";
		}

		public int CompareTo(Frac? other)
		{
			if (other is null)
			{
				throw new ArgumentNullException();
			}

			BigInteger thisValue = _numerator * other._denominator;
			BigInteger otherValue = other._numerator * _denominator;

			return thisValue.CompareTo(otherValue);
		}

		private void Reduce()
		{
			BigInteger gcd = BigInteger.GreatestCommonDivisor(_numerator, _denominator);
			_numerator /= gcd;
			_denominator /= gcd;
		}
	}
}
