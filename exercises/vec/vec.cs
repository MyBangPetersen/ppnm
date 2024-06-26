using static System.Console;
using static System.Math;

public class vec{
	public double x,y,z;

	//constructors
	public vec(){x=y=z=0;}
	public vec(double x,double y,double z){
		this.x=x;
		this.y=y;
		this.z=z;
		}

	//operators:
	public static vec operator*(vec v, double c){
		return new vec(c*v.x,c*v.y,c*v.z);
		}

	public static vec operator*(double c, vec v){
		return v*c;
		}

	public static vec operator+(vec v, vec u){
		return new vec(v.x+u.x, v.y+u.y, v.z+u.z);
		}

	public static vec operator-(vec u){
		return new vec(-u.x,-u.y,-u.z);
		}

	public static vec operator-(vec v, vec u){
		return new vec(v.x-u.x, v.y-u.y, v.z-u.z);
		}

	public static vec operator/(vec v, double u){double n = 1d/u;
		return v*n;
		}

	//printing
	public void testwrite(string s){
		Write($"{s} = ({x}, {y}, {z})\n");
		}

	public void testwrite(){
		Write($"Test Write:\n");
		Write($"\n");
		}

	//dot product, vector product and norm
	public double dot(vec other){
		return this.x*other.x+this.y*other.y+this.z*other.z;
		}

	public static double dot(vec v,vec w){
		return v.x*w.x+v.y*w.y+v.z*w.z;
		}

	public double norm(){
		return x*x + y*y + z*z;
		}

	//comparing the vectors
	public bool approx(double a,double b,double acc=1e-9,double eps=1e-9){
		if(Abs(a-b) < acc)return true;
		if(Abs(a-b) < (Abs(a) + Abs(b)) * eps)return true;
		return false;
		}

	public bool approx(vec other){
		if(!approx(this.x, other.x)) return false;
		if(!approx(this.y, other.y)) return false;
		if(!approx(this.z, other.z)) return false;
		return true;
		}

	public static bool approx(vec v, vec u){
		return v.approx(u);
		}

	public override string ToString(){
		return $"{x} {y} {z}";
		}

}//vec
