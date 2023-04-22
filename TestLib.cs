//  Test dll


// public class TestDLL
// {
//     public static void main(string[] args)
//     {
//         MyLib.Hello.Greet();
//     }
// }

using MyPackage;

public class TestDLL
{
    public static void Main(string[] args)
    {
    	Hello.Addition(970, 523);
    }
}