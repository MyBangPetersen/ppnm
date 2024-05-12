//generating a random matrix of some size
public static class RM{
	public static matrix randommatrix(int rowsize,int colsize){
		matrix emptm = new matrix(rowsize, colsize);

		var rnd = new System.Random(1);

		for (int i = 0; i<rowsize; i++){
			for (int j = 0; j<colsize; j++){
			emptm[i,j] = rnd.NextDouble();
			}}

		return emptm;
		}
	}


//generating a vector of some size
public static class RV{
	public static vector randomvector(int indexsize){
		vector emptv = new vector(indexsize);

		var rnd = new System.Random(1);

		for (int n = 0; n<indexsize; n++){
		emptv[n] = rnd.NextDouble();
		}

		return emptv;
		}
	}

public static class QRGS{
	//gram smith orthoginalization
	public static (matrix, matrix) decomp(matrix A){
		matrix Q = new matrix(A.rows, A.cols);
		matrix R = new matrix(A.rows, A.cols);

		for(int i = 0; i<A.rows; i++){
			R[i,i] = Q[i].norm();
			Q[i]/= R[i,i];
			for(int j = i + 1; j<A.cols ; j++){R[i, j] = Q[i].dot(Q[j]);
			Q[j]-= Q[i] * R[i,j];
			}}
			return (Q, R);
		}


	//solving equation
	public static vector solve(matrix Q, matrix R, vector b){
		int length = b.size;
		vector a = new vector(length);
		matrix QT = Q.T;
		vector QTb = QT*b;
		//solving the lineq from the bottom since R is upper triangular
		for (int i = length - 1; i>=0; i--){
			double sum = 0;
			for (int j=i; j<length; j++){
				sum += R[i,j] * a[j];
			}

			a[i] = (QTb[i] - sum)/R[i, i];
		}
		return a;
		}

	public static double det(matrix R){
		int size = R.rows;
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


class main{
static void Main(){
	System.Console.Write("Making a random matrix");
	matrix A = RM.randommatrix(3,3);
	A.print();

	System.Console.Write("Making a random vector \n");
	vector H = RV.randomvector(3);
	H.print();

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
	/*
	System.Console.Write("Making a vector and square matrix of same size");
	matrix A = RM.randommatrix(3,3);
        A.print();
	System.Console.Write("\n");
        vector H = RV.randomvector(3);
	H.print();
	*/
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
	Syetem.Console.Write($"A*A^-1=I : {I.approx(A*A_inverse)}");

	}//Main
	}//main
