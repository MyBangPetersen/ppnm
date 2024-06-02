using System;
using static System.Console;
using static matrix;
using System.IO;

public class Integration{
	public static double Integrate(Func<double,double> f, double a, double b, double δ=0.001, double ε=0.001, double f2=NaN, double f3=NaN){

	double h=b-a;
	if(IsNaN(f2)){
		f2=f(a+2*h/6);
	 	f3=f(a+4*h/6); 
		} // first call, no points to reuse

	double f1=f(a+h/6);
	double f4=f(a+5*h/6);

	double Q = (2*f1+f2+f3+2*f4)/6*(b-a); // higher order rule
	double q = (  f1+f2+f3+  f4)/4*(b-a); // lower order rule
	double err = Math.Abs(Q-q);

	if (err <= d+epsilon*Math.Abs(Q)) return Q;

	else return integrate(f,a,(a+b)/2,δ/√2,ε,f1,f2)+
	integrate(f,(a+b)/2,b,δ/√2,ε,f3,f4);
}


















}//Integration
