using static System.Math;


public class main1{
	public static void Main(string[] args){
		foreach(var arg in args){
			var words = arg.Split(':');
			if(words[0]=="-numbers"){
				var numbers=words[1].Split(',');
				foreach(var number in numbers){
					double x = double.Parse(number);
					System.Console.WriteLine($"{x} {Sin(x)} {Cos(x)}");
			}
		}
	}//Main
}//main1
}
