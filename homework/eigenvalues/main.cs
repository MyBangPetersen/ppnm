using System;
using static System.Console;
using static System.Math;
using static matrix;

public static class jacobi{
	public static void timesJ(matrix A, int p, int q, double theta){/*...*/}

	public static void Jtimes(matrix A, int p, int q, double theta){/*...*/}

	public static (vector,matrix) cyclic(matrix M){
		matrix A=M.copy();
		matrix V=matrix.id(M.size1);
		vector w=new vector(M.size1);

	/* run Jacobi rotations on A and update V */
	/* copy diagonal elements into w */

	return (w,V);
	}
}
