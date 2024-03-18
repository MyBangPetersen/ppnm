class main2{
public static int Main2(){
	double dx=1.0/64;
	for(double x=-4+dx/2; x<=6+dx/2; x+=dx){
		System.Console.WriteLine($"{x} {sfuns.gamma(x)}");
	}

return 0;

}//Main2
}//main2
