using System;
using System.Numerics;
using static System.Console;

class math{
	//small tasks
	static int Main(){
		Write($"\n Part 1\n");
		double sqrt = Math.Sqrt(2.0);
		Write($"sqrt^2 = {sqrt*sqrt} (should equal 2)\n");

		double power2 = Math.Pow(2.0, 1d/5d);
		Write($"2^1/5 = {power2} with (2^1/5)^5 = {Math.Pow(power2, 5.0)}\n");

		double exp = Math.Exp(Math.PI);
		Write($"exp(Pi) = {exp} with Math.Log(Math.Exp(Math.PI)) = {Math.PI} \n");

		double epi = Math.Pow(Math.PI, Math.E);
		Write($"pi^e = {epi} with ln(pi^e) = {Math.Log(epi, Math.PI)} \n");

	//the gamma function
		Write($"\n Part 2\n");
		double prod=1;
		for(double x=1;x<10;x+=1){
		Write($"fgamma({x})={sfunc.fgamma(x)} \t {x-1}!={prod}\n");
		prod*=x;
		}

	//the modified gamma function
		Write($"\n Part 3\n");
                for(double x=1;x<10;x+=1){
                Write($"lngamma({x})={sfunc.lngamma(x)} \n");
                prod*=x;
                }
                return 0;




		}//main
}//math

