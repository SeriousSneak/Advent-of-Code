using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

/*
 * https://social.msdn.microsoft.com/Forums/en-US/0ab65b76-a914-4029-b18e-4a09e0b47477/how-remove-specific-character-from-string-in-c
 * https://stackoverflow.com/questions/18285566/how-extract-a-specific-character-in-a-string-in-c-sharp-by-index
 * https://docs.microsoft.com/en-us/dotnet/standard/io/how-to-read-characters-from-a-string
 * 
 * 
 */

namespace Day_5
{
    class Program
    {
        static void Main(string[] args)
        {
            var readFile = File.ReadAllLines(@"C:\Users\astobart\OneDrive\Work\Code\Advent of Code\2018\Day 5\input.txt");
            string myInput = readFile[0].ToString();
            string original = myInput;

            Console.WriteLine("The initial string contains " + myInput.Length + " characters.");
            
            // Part 1
            for (int x = 0; x < (myInput.Length - 1); x++)
            {

                if (char.ToLower(myInput[x]) == char.ToLower(myInput[x+1]))
                {
                    //this IF isn't working properly. It will accept "hh" as being true and then remove them from the string
                    if(((char.IsUpper(myInput[x]) == true) && (char.IsLower(myInput[x+1])) == true) || ((char.IsLower(myInput[x]) == true) && (char.IsUpper(myInput[x + 1]) == true)))
                    {
                        myInput = myInput.Remove(x, 2);
                        x = -1;
                    }
                }

            }

            //10762 was the correct answer
            Console.WriteLine("The final string contains " + myInput.Length + " characters.");
            Console.WriteLine("");


            //Part 2

            char testCharacter = 'a';
            int shortestPolymer = 1000000;
            
            for (int alphabetLoop = 0; alphabetLoop < 26; alphabetLoop++)
            {
                //reset the input back to the original to test the next letter
                myInput = original;

                if (alphabetLoop == 0)
                {

                }
                else
                {
                    testCharacter++;
                }

                Console.Write("Now testing " + testCharacter + " - ");

                //loop to delete character pairs
                for (int c = 0; c < (myInput.Length) - 1; c++)
                {
                    if (char.ToLower(myInput[c]) == testCharacter)
                    {
                        myInput = myInput.Remove(c, 1);
                        c = -1;
                    }
                }

                //loop to colapse the polymer
                for (int x = 0; x < (myInput.Length - 1); x++)
                {

                    if (char.ToLower(myInput[x]) == char.ToLower(myInput[x + 1]))
                    {
                        //this IF isn't working properly. It will accept "hh" as being true and then remove them from the string
                        if (((char.IsUpper(myInput[x]) == true) && (char.IsLower(myInput[x + 1])) == true) || ((char.IsLower(myInput[x]) == true) && (char.IsUpper(myInput[x + 1]) == true)))
                        {
                            myInput = myInput.Remove(x, 2);
                            x = -1;
                        }
                    }

                }
                
                if (shortestPolymer > myInput.Length)
                {
                    shortestPolymer = myInput.Length;
                }
                Console.Write("Shortest polymer is " + myInput.Length + ".");
                Console.WriteLine("");
            }


            Console.WriteLine("");
            Console.WriteLine("The shortest possible polymer is " + shortestPolymer);

            Console.WriteLine("");
            Console.WriteLine("Press Enter to continue.");
            Console.ReadKey();
        }
    }
}
