using static matrix;

//generating a random matrix of some size
public static class Matrix{
	public static matrix Random(int size1, int size2){
		matrix RandomMatrix = new matrix(size1, size2);
		var rnd = new System.Random(1);
		for (int i=0; i<size1; i++){
			for (int j=0; j<size2; j++){
                        	RandomMatrix[i, j] = rnd.NextDouble()*10 - 5;
			}
		}
		return RandomMatrix;
	}

//generating a vector of some size
	public static vector Random(int size){
		vector RandomVector = new vector(size);

		var rnd = new System.Random(1);

		for (int i = 0; i<size; i++){
			RandomVector[i] = rnd.NextDouble()*10-5;
		}
		return RandomVector;
	}

//vector to matrix

public static vector[] Vecs(matrix A){
		vector[] columns = new vector[A.size2];
    		for (int i = 0; i < A.size2; i++){
			vector e = new vector(A.size1);
			for (int j = 0; j < A.size1; j++){
				e[j] = A[j, i];
			}
			columns[i] = e;
		}
		return columns;
	}//Vecs

	public static matrix VecsToMatrix(vector[] A){
		int rows = A[0].size;
		int columns = A.Length;
		matrix VTM = new matrix(rows,columns);
		for (int i=0; i<columns; i++){
			for (int j=0; j<rows; j++){
				VTM[j, i] = A[i][j];
			}
		}
		return VTM;
	}//VecsToMatrix

}//End of Matrix

public static class QRGS{
	//gram smith orthoginalization
	public static (matrix, matrix) decomp(matrix A){
		matrix Q = new matrix(A.size1, A.size2);
		matrix R = new matrix(A.size2, A.size2);

		vector[] As = new vector[A.size2];
		vector[] orthoVecs = new vector[A.size2];

		for (int i=0; i<A.size2; i++){
			vector ai = Matrix.Vecs(A)[i];
			vector ui = ai;
			for (int j=0; j<i; j++){
				ui = ui - orthoVecs[j] * ui.dot(orthoVecs[j]);
			}
			vector ei = ui/ui.norm();
			As[i] = ai;
			orthoVecs[i] = ei;
		}
		Q = Matrix.VecsToMatrix(orthoVecs);

		for (int i=0; i<A.size2; i++){
			for (int j=0; j<A.size2; j++){
				R[i,j] = As[j].dot(orthoVecs[i]);
			}
		}

			return (Q, R);
	}//decomp


	//solving equation
	public static vector solve(matrix Q, matrix R, vector b){
		int length = b.size;
		vector x = new vector(length);
		matrix QT = Q.T;
		vector QTb = QT*b;
		//solving the lineq from the bottom since R is upper triangular
		for (int i = length - 1; i>=0; i--){
			double sum = 0;
			for (int j=i; j<length; j++){
				sum += R[i,j] * x[j];
			}

			x[i] = (QTb[i] - sum)/R[i, i];
		}
		return x;
		}

	public static double det(matrix R){
		int size = R.size1;
		double det = 1;
		for (int i = 0; i<size; i++){
			det *= R[i, i];
		}
		return det;
		}


	public static matrix inverse(matrix Q, matrix R){
		matrix B = new matrix(R.size1, R.size2);
		matrix Q_trans = Q.T;
		vector[] xs = new vector[R.size1];

		for (int i=0; i<R.size1; i++){
			vector E = new vector(R.size2);
                	E[i] = 1;
			xs[i] = solve(Q, R, E);
			}

		B = Matrix.VecsToMatrix(xs);

		return B;
		}


	}//QRGS


public static class main{
static void Main(){
	System.Console.Write("Making a random matrix");
	matrix A = Matrix.Random(3,3);
	A.print();

	System.Console.Write("Making a random vector \n");
	vector H = Matrix.Random(3);
	H.print();

	matrix I = matrix.id(A.size2);

	//decomp testing

	System.Console.Write("decomp works");
	(matrix Q, matrix R) = QRGS.decomp(A);
	Q.print();
	matrix C = Q*R;
	C.print();
	System.Console.Write("R is upper tringular");
	R.print();
	System.Console.Write("Q^T*Q=1");
	matrix QTQ = Q.T*Q;
	QTQ.print();

	//solve testing
	System.Console.Write("Decomposing using decomp from before");
	//(matrix Q, matrix R) = QRGS.decomp(A);
	Q.print();
	System.Console.Write("The solution to the system \n");
	vector a = QRGS.solve(Q, R, H);
	a.print();
	System.Console.Write("Ax=b \n");
	vector D = A*a;
	D.print();

	//testing inverse
	matrix A_inverse = QRGS.inverse(Q, R);
	System.Console.Write($"A*A^-1=I : {I.approx(A*A_inverse)}");

	}//Main
	}//main
