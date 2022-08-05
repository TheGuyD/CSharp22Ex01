using System;

namespace Ex01_01
{
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("please enter 3 base 2 numbers with 7 digits:");

            Console.WriteLine("please enter number 1:");
            string sevenBitNumber1 = BinaryReader();

            Console.WriteLine("please enter number 2:");
            string sevenBitNumber2 = BinaryReader();

            Console.WriteLine("please enter number 3:");
            string sevenBitNumber3 = BinaryReader();

            int decimalNumber1 = ConvertBinaryToDecimal(sevenBitNumber1);
            int decimalNumber2 = ConvertBinaryToDecimal(sevenBitNumber2);
            int decimalNumber3 = ConvertBinaryToDecimal(sevenBitNumber3);

            Sort(ref decimalNumber1, ref decimalNumber2, ref decimalNumber3);

            float averageZeros = AverageZeroAndOnesCalculator(out float averageOnce, sevenBitNumber1, sevenBitNumber2, sevenBitNumber3);

            int howManyDenominateByThree = CountDividedByThree(out int countNotDividedByThree, decimalNumber1, decimalNumber2, decimalNumber3);

            int howManyPalindrome = CountHowManyPalindrome(decimalNumber1.ToString(), decimalNumber2.ToString(), decimalNumber3.ToString());

            string toPrint = string.Format(
@"
the strings you entered {0}, {1} ,{2}.
after converting the  Binary numbers to Decimal numbers and sorting them: {3}, {4}, {5}.
the average zeros appears in all 3 inputs : {6}.
the average ones appears in all 3 inputs : {7}.
how many divided by three: {8}.
how many not divided by three: {9}.
number of palindrome: {10}.", sevenBitNumber1, sevenBitNumber2, sevenBitNumber3, decimalNumber1, decimalNumber2, decimalNumber3, averageZeros, averageOnce, howManyDenominateByThree, countNotDividedByThree, howManyPalindrome);

            Console.WriteLine(toPrint);

            Console.ReadKey();
        }

        public static int CountHowManyPalindrome(params string[] i_NumbersArgs)
        {
            int palindromeCounter = 0;
            foreach (string number in i_NumbersArgs)
            {
                if (number.Length == 1)
                {
                    palindromeCounter++;
                }
                else
                {
                    int leftIndex = 0;
                    int rightIndex = number.Length - 1;
                    while (leftIndex <= rightIndex && number[leftIndex] == number[rightIndex])
                    {
                        leftIndex++;
                        rightIndex--;
                    }

                    if (number[leftIndex] == number[rightIndex])
                    {
                        palindromeCounter++;
                    }
                }
            }

            return palindromeCounter;
        }

        public static int CountDividedByThree(out int io_CountNotDivideByThree, params int[] i_Numbers)
        {
            int countDivideByThree = 0;
            io_CountNotDivideByThree = 0;
            foreach (int number in i_Numbers)
            {
                bool isDivisibleByThree = number % 3 == 0;
                if (isDivisibleByThree)
                {
                    countDivideByThree++;
                }
                else
                {
                    io_CountNotDivideByThree++;
                }
            }

            return countDivideByThree;
        }

        public static float AverageZeroAndOnesCalculator(out float io_AverageOnce, params string[] i_NumberStrings)
        {
            int zeroesCounter = 0;
            int onesCounter = 0;
            foreach (string binaryNumber in i_NumberStrings)
            {
                foreach (char digit in binaryNumber)
                {
                    bool isZero = digit.Equals('0');
                    if (isZero)
                    {
                        zeroesCounter++;
                    }
                    else
                    {
                        onesCounter++;
                    }
                }
            }

            io_AverageOnce = (float)onesCounter / i_NumberStrings.Length;
            float averageZeroes = (float)zeroesCounter / i_NumberStrings.Length;
            return averageZeroes;
        }

        public static string BinaryReader()
        {
            string userInput = Console.ReadLine();

            while (!IsUserInputValid(userInput))
            {
                Console.WriteLine("the input is invalid , please enter a valid input!");
                userInput = Console.ReadLine();
            }

            return userInput;
        }

        // input validation
        public static bool IsUserInputValid(string i_StrToValidate)
        {
            bool is7Bits = i_StrToValidate.Length == 7;
            bool isOnlyZerosAndOnes = true;
            foreach (char c in i_StrToValidate)
            {
                bool isNotZeroOrOne = !(c.Equals('0') || c.Equals('1'));
                if(isNotZeroOrOne)
                {
                    isOnlyZerosAndOnes = false;
                    break;
                }
            }

            return isOnlyZerosAndOnes && is7Bits;
        }

        public static int ConvertBinaryToDecimal(string i_StrSevenBitNumber)
        {
            int binaryNumber = int.Parse(i_StrSevenBitNumber);
            int exponent = 0;
            int decimalNumber = 0;

            while (binaryNumber > 0)
            {
                float fraction = (float)binaryNumber / 10;
                int numerator = (int)fraction;
                double denominator = Math.Round(fraction - numerator, 1);
                int digit = (int)(denominator * 10);
                binaryNumber /= 10;
                if (digit == 1)
                {
                    decimalNumber += (int)Math.Pow(2, exponent);
                }

                exponent++;
            }

            return decimalNumber;
        }

        // this sort method is basicallly a astate machine , there are only 3 number so there are small number of combinationa
        public static void Sort(ref int io_Num1, ref int io_Num2, ref int io_Num3)
        {
            if (io_Num1 >= io_Num2 && io_Num1 > io_Num3 && io_Num2 >= io_Num3)
            {
                swap(ref io_Num1, ref io_Num3);
            }
            else if (io_Num1 > io_Num2 && io_Num1 > io_Num3 && io_Num2 < io_Num3)
            {
                swap(ref io_Num1, ref io_Num2);
                swap(ref io_Num2, ref io_Num3);
            }
            else if (io_Num1 < io_Num2 && io_Num1 > io_Num3 && io_Num2 > io_Num3)
            {
                swap(ref io_Num2, ref io_Num3);
                swap(ref io_Num1, ref io_Num2);
            }
            else if (io_Num1 >= io_Num2 && io_Num1 <= io_Num3 && io_Num2 < io_Num3)
            {
                swap(ref io_Num1, ref io_Num2);
            }
            else if (io_Num1 < io_Num2 && io_Num1 <= io_Num3 && io_Num2 > io_Num3)
            {
                swap(ref io_Num2, ref io_Num3);
            }
        }

        private static void swap(ref int io_Num1, ref int io_Num2)
        {

            int temp = io_Num1;
            io_Num1 = io_Num2;
            io_Num2 = temp;

        }
    }
}