
using System;
using System.IO;
using static System.Console;
using System.Collections.Generic;
using static matrix;

public class ODE{
	public static (vector,vector) rkstep12(Func<double,vector,vector> f, double x, vector y,double h){
		vector k0 = f(x,y);              /* embedded lower order formula (Euler) */
		vector k1 = f(x+h/2,y+k0*(h/2)); /* higher order formula (midpoint) */
		vector yh = y+k1*h;              /* y(x+h) estimate */
		vector dy = (k1-k0)*h;           /* error estimate */
		return (yh,dy);
	}//rkstep12

	public static (genlist<double>,genlist<vector>) driver(Func<double,vector,vector> F, (double,double) interval, vector ystart,
		double h = 0.125, double acc = 0.01, double eps = 0.01){

	var (a,b) = interval;
	double x = a;
	vector y = ystart.copy();

	var xlist = new genlist<double>();
	xlist.add(x);

	var ylist = new genlist<vector>();
	ylist.add(y);

	do{

	        if(x >= b) return (xlist, ylist); /* job done */

        	if(x + h > b) h = b - x;               /* last step should end at b */

		var (yh, dy) = rkstep12(F, x, y, h);
		double tol = (acc + eps*yh.norm()) * Sqrt(h/(b-a));
		double err = δy.norm();

		if(err <= tol){
			x += h;
			y = yh;
			xlist.add(x);
			ylist.add(y);
		}

		h *= Math.Min(Math.Pow(tol/err,0.25)*0.95 , 2); // readjust stepsize
        }while(true);
}//driver
}//ODE

public static class main{
	public static vector HarmOsci(double x, vector y){
		return new vector(y[1], -y[0]);
			}

	public static vector DampOsci(double x, vector y, double gamma, double omega){
		return new vector(y[1], -2*gamma*y[1] - omega*omega*y[0]);
			}

	static void Main(){
		vector ystart = new vector(1.0, 0.0);
		var (xlist_HO, ylist_HO) = ODE.driver(HarmOsci, (0,10), ystart);

		string Harm = "HarmOsci.txt";
		using (StreamWriter writer = new StreamWriter(Harm)){
			for (int i=0; i < xlist_HO.Count; i++){writer.WriteLine($"{xlist_HO[i]} {ylist_HO[i][0]} {ylist_HO[i][1]}");
			}}

		double gamma = 0.1;
		double omega = 2.0;
		Func<double, vector, vector> dampOsci = (x,y) => DampOsci(x, y, gamma, omega);
		var (xlist_DO, ylist_DO) = ODE.driver(dampOsci, (0,10), ystart);

		string Damp = "DampOsci.txt";
		using (StreamWriter writer = new StreamWriter(Damp)){
			for (int i=0; i < xlist_DO.Count; i++){writer.WriteLine($"{xlist_DO[i]} {ylist_DO[i][0]} {ylist_DO[i][1]}");
			}}
	}//Main()
}//main



