using System;
using static System.Math;
using static System.Console;

public static class min{

	public static (vector, int) newton(Func<vector,double> phi, vector x, double acc=1e-3){
		int loop_count = 0;
		//Newton iterations
		do{
		vector grad = gradient(phi, x);
		if(grad.norm() < acc) break; /* job done */

		matrix H = hessian(phi, x);
		(matrix HQ, matrix HR) = QRGS.decomp(H);

		vector dx = QRGS.solve(HQ, HR, -grad); /* Newton's step */
		double lambda = 1;
		double phi_x = phi(x);

		//linesearch
		do{
			if( phi(x + lambda * dx) < phi_x ) break; //good step
			if( lambda < 1d/1024d ) break; // accept anyway
			lambda = lambda/2;
		}while(true);

		x = x + lambda*dx;
	}while(true);

	return (x, loop_count);
	}//newton



	public static vector gradient(Func<vector,double> phi,vector x){
		vector grad = new vector(x.size);

		for(int i = 0; i < x.size; i++){
			double dx = Max(Abs(x[i]),1)*Pow(2,-26);
			vector x_step = x.copy();
			x_step[i] += dx;
			grad[i] = (phi(x_step) - phi(x))/dx;
			}
	return grad;
	}//gradient



	public static matrix hessian(Func<vector,double> phi,vector x){
		matrix H = new matrix(x.size);
		vector grad = gradient(phi,x);

		for(int j = 0; j < x.size; j++){
			double dxj = Max(Abs(x[j]),1)*Pow(2,-13); /* for numerical gradient */
			vector x_step = x.copy();
			x_step[j] = x_step[j] + dxj;
			vector grad_step = gradient(phi, x_step);

			for(int i = 0; i < x.size; i++){
				 H[i,j] = (grad_step[i] - grad[i])/dxj;
			}
		}
	return H;
	}//Hessian

}//min
