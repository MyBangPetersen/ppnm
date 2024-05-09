using System;
using static System.Console;
using static cmath;

class main{
	static void Main(){

	complex i = new complex(0,1);
	complex a = -1;

	//sqrt(-1)
	complex comn = new complex(-1,0);
	Console.WriteLine($"sqrt(-1) = {cmath.sqrt(comn)} should be {i}: {i.approx(sqrt(a))}");
	Console.WriteLine();

	//sqrt(i)
	complex sqrti = cmath.sqrt(i);
	Console.WriteLine($"sqrt(i) = {sqrti} should be {sqrti}: {sqrti.approx(sqrt(i))}");
        Console.WriteLine();

	//exp(i)
	complex expi = cmath.exp(i);
	Console.WriteLine($"exp(i) = {expi} should be {expi}: {expi.approx(exp(i))}");
        Console.WriteLine();

	//exp(i pi)
	complex expipi = cmath.exp(i*Math.PI);
	Console.WriteLine($"exp(ipi) = {expipi} should be {expipi}: {expipi.approx(cmath.exp(i*Math.PI))}");
        Console.WriteLine();

	//i^i
	complex itoi = i.pow(i);
	Console.WriteLine($"i^i = {itoi} should be {itoi}: {itoi.approx(cmath.pow(i,i))}");
        Console.WriteLine();

	//ln(i)
	complex lni = cmath.log(i);
	Console.WriteLine($"ln(i) = {lni} should be {lni}: {lni.approx(cmath.log(i))}");
        Console.WriteLine();

	//sin(i pi)
	complex sinipi = cmath.sin(i*Math.PI);
	Console.WriteLine($"sin(i pi) = {sinipi} should be {sinipi}: {sinipi.approx(cmath.sin(i*Math.PI))}");
        Console.WriteLine();


}//Main
}//main
