using System;
using static System.Console;
using static System.Math;

//class for determining the eigenvalues
public class eigenvalues{

	//setup of the matrix A
	public static matrix setmat(matrix D, vector u, int p){
		int n = D.size1;
		matrix A = new matrix(n, n);

		//A is created from D
		for(int i = 0; i < n; i++){
			A[i, i] = D[i, i];
		}
		for(int i = 0; i < n; i++){
			for(int j = 0; j < n; j++){

			if(j==p){ A[i,j] = A[i,j] + u[i];
			}
			if(i==j){ A[i,j] = A[i,j] + u[j];
			}
			}
		}
	return A;
	}//setmat

	//the eigenvalue problem itself
	public static vector eig(matrix A, int p){
		int n = A.size1;
		int iterations = 75;

		//the eigenvalues
		vector e = new vector(n);

		double x = 0;
		double dx = 0;
		double e0;

		for(int i = 0; i < n; i++){
			e[i] = A[i,i] + 0.1;
		}

		//using Newtons method for solving as it completes with O(n²) operations
		for(int i = 0; i < n; i++){
			for(int j = 0; j < iterations; j++){
				x = 0;
				dx = 0;
			//the value of x
			for(int l = 0; l < n; l++){
				if(l == p) x = x - (A[p, p] - e[i]);
				else x = x + A[l,p]*A[l,p]/(A[l,p]-e[i]);
			}
			//the valuee of dx
			for(int l = 0; l < n; l++){
				if(l == p) dx = dx + 1;
				else dx = dx + A[l,p] * A[l,p]/((A[l,l] - e[i]) * (A[l,l] - e[i]));
			}
			//the method itself
			e0 = e[i];
			e[i] = (e[i] - x/dx);
		}
		}
		return e;
	}//eig
}//eigenvalues
