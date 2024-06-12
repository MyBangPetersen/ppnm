using System;
using static System.Math;
using static System.Console;

public static class main{
	public static void Main(){
	int i = 0;
	int j = 0;

	Func<vector,double> rosenbrock = x => {
    	i++;
   	return Pow((1 - x[0]),2) + 100 * Pow((x[1] - Pow(x[0],2)),2);
	};

	Func<vector,double> himmelblau = x => {
    	j++;
    	return Pow((Pow(x[0],2) + x[1] - 11),2) + Pow((x[0] + Pow(x[1],2) - 7),2);
	};

	vector x0 = new vector(10,10); // initial guess

	var rosenbrock_minima = minimize.newton(rosenbrock,x0);
	var himmelblau_minima = minimize.newton(himmelblau,x0);


WriteLine("The Rosenbrock valley function looks like f(x,y) = (1-x)^2 + 100*(y-x^2)^2:\n");
rosenbrock_minima.print("Found minimum (x,y):");
x0.print("Initial guess (x,y):");
WriteLine($"Value of function at found minimum: {rosenbrock(rosenbrock_minima)}");
WriteLine($"Steps used: {i}\n");

WriteLine("The Himmelblau function looks like f(x,y) = (x^2+y-11)^2 + (x+y^2-7)^2:\n");
himmelblau_minima.print("Found minimum (x,y):");
x0.print("Initial guess (x,y):");
WriteLine($"Value of function at found minimum: {himmelblau(himmelblau_minima)}");
WriteLine($"Steps used: {j}");
} // Main
} // main
