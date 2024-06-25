using System;
using static System.Console;
using static System.Math;
using static matrix;

public static class Matrix{
	//Generating a symmetric matrix of some size to use as D
	//Ths matrix must be diagonal
	//If the matrix must be square use size1 = size2
	public static matrix Random(int size1, int size2){
		matrix RandomMatrix = new matrix(size1, size2);
		var rnd = new System.Random();

		for (int i = 0; i < size1; i++){

			for (int j = 0; j <= i; j++){

				RandomMatrix[i, j] = rnd.Next(100) + 1;
				RandomMatrix[i, j] = RandomMatrix[j, i];
			}
		}
		return RandomMatrix;
	}//Random matrix


	//generating a vector of size n
	public static vector Random(int size){

		vector RandomVector = new vector(size);
		var rnd = new System.Random(1);

		for(int i = 0; i < size; i++){
			RandomVector[i] = rnd.Next(100) + 1;
			}

		return RandomVector;
	}//Random vector






}//Matrix

public static class main{
	static void Main(){
	//start-matrix and vector
	System.Console.Write("Generating some random matrix of size n");
	matrix P = Matrix.Random(5, 5);
	P.print();
	System.Console.Write("and some vector of the same size \n");
	vector u = Matrix.Random(5);
	u.print();

	//the A-matrix
	System.Console.Write("Finding the matrix A \n");
	int p = 3;
	matrix A = eigenvalues.setmat(P, u, p);
	A.print();

	//the eigenvalues
	System.Console.Write("and the eigenvalues for A is \n");
	vector e = eigenvalues.eig(A, p);
	e.print();

}//Main
}//main
