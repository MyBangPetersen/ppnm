using System;
using static System.Console;
using static System.Math;
using static matrix;

public static class Matrix{

	//Generating a random matrix of size n
	public static matrix Random(int size1, int size2){
		matrix RandomMatrix = new matrix(size1, size2);
		var rnd = new System.Random(1);
		for (int n = 0; n < size1; n++){
			for (int j = n; j < size2; j++){
				RandomMatrix[n, j] = rnd.NextDouble()*10 - 5;
				RandomMatrix[j, n] = RandomMatrix[n, j]; //Symmetry
			}
		}
		return RandomMatrix;
	}// Random matrix




}//Matrix

public static class main{
	static void Main(){
	System.Console.Write("Making a random matrix of size n");
	matrix A = Matrix.Random(3, 3);
	A.print();

	}//Main
}//main
