using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
	public class ComplexNumber : IMyNumber<ComplexNumber>
	{
		private BigInteger _real;
		private BigInteger _imaginary;

		public ComplexNumber(BigInteger real, BigInteger imaginary)
		{
			_real = real;
			_imaginary = imaginary;
		}

		public ComplexNumber Add(ComplexNumber b)
		{
			return new ComplexNumber(_real + b._real, _imaginary + b._imaginary);
		}

		public ComplexNumber Divide(ComplexNumber b)
		{
			if (b._real == 0 && b._imaginary == 0)
			{
				throw new DivideByZeroException();
			}

			BigInteger denominator = b._real * b._real + b._imaginary * b._imaginary;
			BigInteger realPart = (_real * b._real + _imaginary * b._imaginary) / denominator;
			BigInteger imaginaryPart = (_imaginary * b._real - _real * b._imaginary) / denominator;

			return new ComplexNumber(realPart, imaginaryPart);
		}

		public ComplexNumber Multiply(ComplexNumber b)
		{
			BigInteger realPart = _real * b._real - _imaginary * b._imaginary;
			BigInteger imaginaryPart = _real * b._imaginary + _imaginary * b._real;

			return new ComplexNumber(realPart, imaginaryPart);
		}

		public ComplexNumber Subtract(ComplexNumber b)
		{
			return new ComplexNumber(_real - b._real, _imaginary - b._imaginary);
		}

		public override string ToString()
		{
			return $"{_real} + {_imaginary}i";
		}
	}
}
