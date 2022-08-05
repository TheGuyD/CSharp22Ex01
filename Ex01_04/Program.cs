using System;
using System.Text;

namespace Ex01_04
{
    public class Program
    {
        public static void Main()
        {
            // welcome message
            string welcomingString = @"Hello And Welcome to the 4th task
Please write a string, which contains:
1)only 9 symbols
2)only letters OR numbers";
            StringBuilder finalMessage = new StringBuilder();// stringBuilder which will be filled with information during the program
            string strForAnalysis = null; // string that program will analysis
            int strLengthCondition = 9;// string length given by program conditions
            bool isNumber = false; // variable that contains state of the string, if it number will change to True
            bool isOnlyLetters = false;// variable that contains state of the string, if it only letters will change to True
            bool isValid = false;// variable that will contain expression {isNumber OR isOnlyLetters}. If it True, we are ending the program

            Console.WriteLine(welcomingString);
            // do-while loop that will run {isValid = false} until the user enters the correct input {isValid changes to True}  
            do
            {
                // User enters string
                strForAnalysis = Console.ReadLine();

                // The method will check that the number of entered characters is equal to the number specified by the program conditions.
                // If the condition is not met, you will be prompted to enter a re-entry in the function itself and returns new string with correct length
                ValidateStrLength(ref strForAnalysis, strLengthCondition);

                // if - else statement: {if} checks if entered string is number, if yes, change variable isNumber = True and checks that it divisible by 3 without reminder
                //                      {else} - if entered string contains only english letters, if yes, change variable isOnlyLetters = True calculate quantity of lowerCase 

                bool successIntParse = int.TryParse(strForAnalysis, out int strIsNumber);

                if (successIntParse)
                {
                    //depending on whether the number is divisible by three or not, add the corresponding line finaleMessage {StringBuilder} 
                    finalMessage.AppendLine(
                        strIsNumber % 3 == 0
                            ? "Your entered string is a number and it`s divisible by 3 without reminder"
                            : "Your entered string is a number and it`s NOT divisible by 3 without reminder");
                    // if entered string is number, we are changing isNumber to true
                    isNumber = true;
                }

                else
                {
                    // Check if entered string contains only english letters
                    if (IsAllLetters(strForAnalysis))
                    {
                        //variable that contains quantity of little letters. Calculates in method CountLowerCase
                        int lowerCaseCount = CountLowerCase(strForAnalysis);

                        // Depending on how many small letters are in string, create temporary string with this info
                        // And add the corresponding line finaleMessage {StringBuilder} 
                        string tempString = string.Format("There are only english letters: {0} of them - little", lowerCaseCount);
                        finalMessage.AppendLine(tempString);

                        // if entered string contains only letters, we are changing isOnlyLetters to true
                        isOnlyLetters = true;
                    }

                    //if string is not in correct format, user will receive message
                    else
                    {
                        Console.WriteLine("Your string is NOT on the correct format, Try again");
                    }
                }

                // isValid is False. If string is a number or contains only letters, variable will change to True 
                isValid = isNumber || isOnlyLetters;
            }
            while (!isValid);// Loop will stop if isValid changes statement to True

            // After the string has passed the test, we check if it is a palindrome
            CheckingPalindrome(strForAnalysis, out bool isPalindrome);

            // Depending on the palindrome or not, the corresponding string is added to finaleMessage {StringBuilder}
            finalMessage.AppendLine(
                isPalindrome ? "Your entered string is Palindrome" : "Your entered string is NOT Palindrome");

            // Printing Final String
            finalMessage.AppendLine("Good bye!");
            Console.WriteLine(finalMessage);
            Console.ReadKey();
        }

        // The method will check that the number of entered characters is equal to the number specified by the program conditions.
        // If the condition is not met, you will be prompted to enter a re-entry in the function itself and returns new string with correct length
        public static void ValidateStrLength(ref string io_strForAnalysis, int strLengthCondition)
        {
            while (io_strForAnalysis.Length != strLengthCondition)
            {
                Console.WriteLine("Sorry, but the length of your entered string is not correct, it must be 9 symbols. Try again! ");
                io_strForAnalysis = Console.ReadLine();
            }
        }

        // Check if entered string contains only english letters
        public static bool IsAllLetters(string i_strForAnalysis)
        {
            bool isAllLetters = true;// Variable that contains information if the string contains only letters and will be passed

            // foreach loop will iterate through the characters of the string, if it finds an invalid character,
            // will change isAllLetters to False and stop
            foreach (char c in i_strForAnalysis)
            {
                if (!char.IsLetter(c))
                {
                    isAllLetters = false;
                    break;
                }
            }

            return isAllLetters;
        }


        // Method calculate quantity of small letters 
        public static int CountLowerCase(string i_strForAnalysis)
        {
            int counterSmallLetters = 0;

            foreach (char letter in i_strForAnalysis)
            {
                if (letter >= 'a' && letter <= 'z')
                {
                    counterSmallLetters++;
                }
            }

            return counterSmallLetters;
        }

        // Recursive method for Palindrome checking 
        // program checks first and last symbol of the string, if them are equal, cuts those symbols
        // and will check again until the length of the string will be 1 or 0. 
        public static void CheckingPalindrome(string i_strForAnalysis, out bool io_isPalindrome)
        {
            // if - else statement: {if} program managed to reduce the string to a given value, then the string meets the palindromic condition
            //                      {else} if the length of the string is greater than 1, it checks the extreme characters, and if they are equal,
            //                             it cuts them off and passes the truncated string to a new function. if the extreme characters are not equal,
            //                             the string is not a palindrome
            if (i_strForAnalysis.Length <= 1)
            {
                io_isPalindrome = true;
            }

            else
            {
                if (i_strForAnalysis[0] == i_strForAnalysis[i_strForAnalysis.Length - 1])
                {
                    CheckingPalindrome(i_strForAnalysis.Substring(1, i_strForAnalysis.Length - 2), out io_isPalindrome);
                }

                else
                {
                    io_isPalindrome = false;
                }
            }
        }
    }
}
