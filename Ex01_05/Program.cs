using System;
using System.Text;

namespace Ex01_05
{
    public class Program
    {
        public static void Main()
        {
            // welcoming message
            string welcomingString = @"Hello And Welcome to the 5th task!
Please enter a nine-digit Integer ";
            int strLengthCondition = 9;// string length given by program conditions
            bool isNumber = false;
            StringBuilder finalMessage = new StringBuilder();// stringBuilder which will be filled with information during the program

            // Print welcoming message
            Console.WriteLine(welcomingString);

            // Loop is working until user receive correct input
            do
            {
                string enteredString = Console.ReadLine();

                // The method will check that the number of entered characters is equal to the number specified by the program conditions.
                // If the condition is not met, you will be prompted to enter a re-entry in the function itself and returns new string with correct length
                ValidateStrLength(ref enteredString, strLengthCondition);

                // in condition that entered string is number we can continue to anylise the number
                if (int.TryParse(enteredString, out int enteredNumber))
                {
                    // as a result of successful, change isNumber to True for ability to leave the loop
                    isNumber = true;

                    // Method founds the last digit of the number. Send string and receive string contains information about the result 
                    finalMessage.AppendLine(DigitOfOnes(enteredNumber, enteredString, out int digitOfOnes));

                    // Method that calculate the quantity of digits less then digitOfOnes and return string with actual information
                    // Depending of quantity of digits less then last digit, the corresponding line adds to finalMessage {stringBuilder}
                    finalMessage.AppendLine(QuantityOfDigitsLessThenOnes(digitOfOnes, enteredString));

                    // Method founds the biggest digit of the number. Send string and receive string contains information about the result 
                    // Depending on which digit is the biggest, the corresponding line adds to finalMessage {stringBuilder}
                    finalMessage.AppendLine(TheBiggestDigit(enteredString));

                    // Method calculates the average sum of digits, Send string and receive string contains information about the result 
                    // Depending of quantity of digits divisible by three, the corresponding line adds to finalMessage {stringBuilder}
                    finalMessage.AppendLine(DivisibleByThreeWithoutReminder(enteredString));

                    // Method calculates the average sum of digits, Send string and receive variable by reference 
                    // Depending of the result, the corresponding line adds to finalMessage {stringBuilder}
                    finalMessage.AppendLine(TheAverageSumOfDigits(enteredString));
                }

                // if entered string is not a number, user will see a message and will be asked to re-enter string
                else
                {
                    Console.WriteLine("Your entered string is NOT an Integer, Try again!");
                }
            }
            //loop will work until isNumber is False
            while (!isNumber);

            // Print finaleMessage
            Console.WriteLine(finalMessage);
            Console.ReadKey();
        }

        // The method will check that the number of entered characters is equal to the number specified by the program conditions.
        // If the condition is not met, you will be prompted to enter a re-entry in the function itself and returns new string with correct length
        public static void ValidateStrLength(ref string io_strForAnalysis, int i_strLengthCondition)
        {
            while (io_strForAnalysis.Length != i_strLengthCondition)
            {
                Console.WriteLine("Sorry, but the length of your entered string is not correct, it must be 9 symbols. Try again! ");
                io_strForAnalysis = Console.ReadLine();
            }
        }

        // Method finds the last number (return it by reference) and return message with actual result 
        public static string DigitOfOnes(int i_enteredNumber, string i_enteredString, out int io_DigitOfOnes)
        {
            io_DigitOfOnes = i_enteredNumber % 10;// the last digit of the enteredNumber
            string tempMessage = string.Format("You entered the number - {0}. The last digit is {1}",
                i_enteredString,
                io_DigitOfOnes);

            return tempMessage;
        }

        // Method finds quantity of numbers that less then last number and return message with actual result 
        public static string QuantityOfDigitsLessThenOnes(int i_DigitOfOnes, string i_EnteredString)
        {
            int counterLessThenOne = 0;
            string tempMessage = null;

            foreach (char c in i_EnteredString)
            {
                int num = c - '0';
                if (num < i_DigitOfOnes)
                {
                    counterLessThenOne++;
                }
            }

            // Depends to counterLessThenOne, program choose which message to create
            if (counterLessThenOne > 1)
            {
                tempMessage = $"There are {counterLessThenOne} digits less then last digit";
            }

            else if (counterLessThenOne == 0)
            {
                tempMessage = "There`re not digits less then last digit";
            }

            else
            {
                tempMessage = "There is only 1{one} digit less then last digit";
            }

            return tempMessage;
        }

        // Method finds the biggest digit of the number and return message with actual result 
        public static string TheBiggestDigit(string i_EnteredString)
        {
            int biggestDigit = 0;
            string tempMessage = null;

            foreach (char c in i_EnteredString)
            {
                int num = c - '0';
                if (num > biggestDigit)
                {
                    biggestDigit = num;
                }
            }
            tempMessage = $"The biggest digit is {biggestDigit}";
            return tempMessage;
        }

        // Method finds thq quantity of number divisible by 3 and return message with actual result 
        public static string DivisibleByThreeWithoutReminder(string i_EnteredString)
        {
            int divisibleByThree = 0;
            string tempMessage = null;

            foreach (char c in i_EnteredString)
            {
                int num = c - '0';
                if (num % 3 == 0)
                {
                    divisibleByThree++;
                }
            }

            // According divisibleByThree, program choose which message to create
            if (divisibleByThree > 1)
            {
                tempMessage = $"There are {divisibleByThree} digits divisible by 3 without reminder";
            }

            else if (divisibleByThree == 0)
            {
                tempMessage = "There`re not digits divisible by 3 without reminder";
            }

            else
            {
                tempMessage = "There is only 1 digit divisible by 3 without reminder";
            }

            return tempMessage;

        }

        // Method finds the average sum of digits and return message with actual result 
        public static string TheAverageSumOfDigits(string i_EnteredString)
        {
            double sumOfDigits = 0;
            double averageOfDigits = 0;
            string tempMessage = null;

            foreach (char c in i_EnteredString)
            {
                int num = c - '0';
                sumOfDigits += num;
            }

            averageOfDigits = sumOfDigits / i_EnteredString.Length;
            tempMessage = $"Average sum of digits is {averageOfDigits}";

            return tempMessage;
        }
    }
}