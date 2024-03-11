using System;
using static System.Console;
using static cmath;

class main{
	static void Main(){

	//sqrt(-1)
	complex comn = new complex(-1,0);
	Console.WriteLine($"sqrt(-1) = {cmath.sqrt(comn)}");
	Console.WriteLine();


	complex i = new complex(0,1);
	//sqrt(i)
	complex sqrti = cmath.sqrt(i);
	Console.WriteLine($"sqrt(i) = {sqrti}");
        Console.WriteLine();

	//exp(i)
	complex expi = cmath.exp(i);
	Console.WriteLine($"exp(i) = {expi}");
        Console.WriteLine();

	//exp(i pi)
	complex expipi = cmath.exp(i*Math.PI);
	Console.WriteLine($"exp(ipi) = {expipi}");
        Console.WriteLine();

	//i^i
	itoi = i.pow(i);
	Console.Writeline($"i^i = {itoi}");
        Console.WriteLine();

	//ln(i)
	complex lni = cmath.Log(i);
	Console.WriteLine($"ln(i) = {lni}");
        Console.WriteLine();

	//sin(i pi)
	double sinipi = Math.Sin(i*Math.PI);
	Console.WriteLine($"sin(i pi) = {sinipi}");
        Console.WriteLine();


}//Main
}//main
