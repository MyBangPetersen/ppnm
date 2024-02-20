using System;
using System.Numerics;
using static System.Console;

class math{
	//small tasks
	static void main(){
		double sqrt = Math.Sqrt(2.0);
		Write($"sqrt2^2 = {sqrt2*sqrt2} (should equal 2)\n");

		double power2 = Math.Pow(2.0, 1d/5d);
		Write($"2^1/5 = {power2} with (2^1/5)^5 = {Math.Pow(power2, 5.0)}\n");

		double exp = Math.Exp(PI);
		Write($"exp(Pi) = {exp} with Math.Log(Exp(PI)) = {PI} \n");

		double epi = Math.Pow(Math.PI, Math.E);
		Write($"pi^e = {e} with ln(pi^e) = {Math.Log(epi, Math.PI)} \n");
		}//main

	//the gamma function
	static int Main(){
		double prod=1;
		for(double x=1;x<10;x+=1){
		Write($"fgamma({x})={sfunc.fgamma(x)} \t {x-1}!={prod}\n");
		prod*=x;
		}
		return 0;
		}

}//math

