
using System;
public class Program
{
    public static void Main()
    {
        //before starting Ex01_03 please build Ex01_02 and add reference to the file Ex01_02.exe
        
        
        int height = ReadHeight();

        
        Ex01_02.Program.RecDiamond(height);
        
        Console.ReadKey();  
    }

    public static int ReadHeight()
    {
        Console.WriteLine("please enter an integer number:");
        bool isNumber = int.TryParse(Console.ReadLine(), out int height);
        bool isPositive = height > 0;
       
        // in case the user wrote invalid input the validation steps will be execute until a valid input
        while (!(isNumber && isPositive))
        {
            Console.WriteLine("you entered invalid input , please enter a valid input!");
            isNumber = int.TryParse(System.Console.ReadLine(), out height);
            isPositive = height > 0;
        }

        ChangeEvenToOdd(ref height);

        return height;
    }

    public static void ChangeEvenToOdd(ref int i_Number)
    {
        bool isEven = i_Number % 2 == 0;
        if(isEven)
        {
            i_Number += 1;
        }
    }

}

