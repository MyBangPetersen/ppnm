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

				RandomMatrix[i, j] = rnd.Next(100)+1;
				RandomMatrix[i, j] = RandomMatrix[j, i];
			}
		}
		return RandomMatrix;
	}//Random


	//generating a vector of size n



}//Matrix

public static class main{
	static void Main(){
	System.Console.Write("Making a random matrix of size n");
	matrix P = Matrix.Random(5, 5);
	P.print();
	System.Console.Write("Which is symmetric as it equals its transposed:");
	P.T.print();
	}//Main

}//main
