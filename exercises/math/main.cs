using System;
using System.numerics;
using static System.Console;

class math{
	double sqrt = Math.Sqrt(2.0);
	Write($"sqrt2^2 = {sqrt2*sqrt2} (should equal 2)\n");

	double power2 = Math.Pow(2.0, 1d/5d);
	Write($"2^1/5 = {power2} with (2^1/5)^5 = {Math.Pow(power2, 5.0)}\n");

}

