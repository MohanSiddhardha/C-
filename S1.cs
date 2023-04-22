
using System;

class Hello
{
	public void Greet()
	{
		Console.WriteLine("Hello");
	}
}

class cMain
{
    static void Main(string[] args)
	{
		Hello oHello = new Hello();
		oHello.Greet();
	}
}