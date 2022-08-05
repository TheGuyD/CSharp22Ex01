using System;


namespace Ex01_02
{
    public class Program
    {
        public static void Main()
        {
            RecDiamond();

            Console.ReadKey();
        }

        // s_RowToPrint string will be updated and print in every step of the recursion.
        public static string s_RowToPrint = "*";


        //this reccursive function uses a three possable Rows states
        //1.white space at the beggining and asterisk at the end -----> increase asterisk ,decrese white space
        //2.white space at the beggining and white space at the end --> increase white space ,decreace asterisks
        //3.asterisk at the begginig and at the end-------------------> reached the higest asterisks line , from here
        //                                                              all recursive steps will enter second condition (state 2)
        public static void RecDiamond(int i_Height = 9)
        {

            bool isLastRowToPrint = i_Height == 1;
            if (isLastRowToPrint)
            {
                Console.WriteLine(s_RowToPrint);
                return;
            }

            s_RowToPrint = s_RowToPrint.PadLeft((i_Height / 2) + 1);

            Console.WriteLine(s_RowToPrint);

            //here we concatinate astrerisks and remove a single white space from the beggining 
            bool isAddAstriksFlag = s_RowToPrint.StartsWith(" ") && s_RowToPrint.EndsWith("*");
            if (isAddAstriksFlag)
            {
                s_RowToPrint = s_RowToPrint.Remove(0, 1);
                s_RowToPrint += "**";
            }

            //here we concatonate sigle white space and remove asterisks from the beginning
            //while keeping the white space at the end of the string to insure the next reccursive step
            else if (s_RowToPrint.StartsWith(" ") && s_RowToPrint.EndsWith(" "))
            {
                s_RowToPrint = " " + s_RowToPrint;
                s_RowToPrint = s_RowToPrint.Remove(s_RowToPrint.Length - 3, 2);
            }

            //a line without a space at the begginning nor the end represent the largest asterisks
            // line and that from here the number of asterisks is decreas
            //and the number of white spaces to the left  increacs
            else
            {
                s_RowToPrint = " " + s_RowToPrint;
                s_RowToPrint = s_RowToPrint.Remove(s_RowToPrint.Length - 2, 2);
                s_RowToPrint += " ";
            }



            RecDiamond(--i_Height);
        }


    }

}




