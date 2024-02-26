using static System.Console;
using static System.Math;
using System.Numerics;

class main{
	public static void max(){
		int i=1;
		while(i+1>i) {i++;}
		Write($"The max int = {0}\n",i);
		}

	public static void min(){
		int i=1;
		while(i-1<i) {i--;}
        	Write($"The min int = {0}\n",i);
		}

		//for comp exercise
	public static bool approx(double a, double b, double acc=1e-9, double eps=1e-9){
		if(Abs(b-a) <= acc) return true;
		if(Abs(b-a) <= Max(Abs(a),Abs(b))*eps) return true;
		return false;
		}

	static void Main(){
		//Machine Epsilon (double)
		double x=1;
		while(1+x!=1){x/=2;}
		x*=2;
		Write($"ME double = {x}\n");
		Write($"should be equal to = Pow(2,-52) = {Pow(2,-52)}\n");

		//Machine Epsilon (float)
		float y=1F;
		while((float)(1F+y) != 1F){y/=2F;}
		y*=2F;
		Write($"ME float = {y}\n");
		Write($"should be equal to = Pow(2,-23) = {Pow(2,-23)}\n");

		//tinyepsilon
		double epsilon=Pow(2,-52);
		double tiny=epsilon/2;
		double a=1+tiny+tiny;
		double b=tiny+tiny+1;

		Write($"a= {a}\n");
		Write($"b= {b}\n");
		Write($"tiny= {tiny}\n");

		Write($"a==b ? {a==b}\n");
		Write($"a>1  ? {a>1}\n");
		Write($"b>1  ? {b>1}\n");

		Write($"a==1 ? {a==1}\n");
		Write($"b==1 ? {b==1}\n");

		Write($"The order of adding tiny to the numbers\n");
		Write($"makes it so that b is not rounded back to 1\n");
		Write($"Thus a will be equal to one but b will not...\n");

		//comparing doubles
		double d1 = 0.1+0.1+0.1+0.1+0.1+0.1+0.1+0.1;
		double d2 = 8*0.1;

		Write($"d1={d1:e15}\n");
		Write($"d2={d2:e15}\n");
		Write($"d1==d2 ? => {d1==d2}\n");

		bool comparing = approx(d1, d2);
		Write($"Comparing d1 and d2 {comparing}\n");

		}//Main

}//main
