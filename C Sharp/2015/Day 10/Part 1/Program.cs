/* Advent of Code 2015
 * 
 * Programmer: Andrew Stobart
 * Date: February 17, 2021
 * 
 * Day 10 Part 1
 *
 * Part 1 has us looping 40 times. This program took 3 minutes to loop 40 times.
 *   The total length is 492982.
 *   Start: 2021-02-18 12:56:28 UTC.
 *   Finish: 2021-02-18 12:59:04 UTC.
 *
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Part_1
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = "1321131112";  //my puzzle input

            int loopNumber = 40;
            
            string newString = "";
            DateTime start = DateTime.Now.ToUniversalTime();

            for (int x = 0; x<loopNumber; x++)
            {
                Console.WriteLine("Working on loop " + (x + 1) +".");

                for (int y = 0; y < input.Length; y++)
                {
                    int counter = y + 1;
                    int numberOfDigits = 1;
                    while (counter < input.Length)
                    {
                        //does the current character match the next character?
                        if (input[y] == input[counter])
                        {
                            numberOfDigits++;
                            counter++;
                        }
                        else
                        {
                            break;
                        }
                    }
                    
                    newString += (numberOfDigits.ToString() + input[y]);

                    //adjust y so the next loop starts at the character after the repeating characters (if there were repeating characters)
                    y = counter - 1;
                }

                input = newString;
                //only clear newString if we will be looping again
                if ((x + 1) != loopNumber)
                {
                    newString = "";
                }
            }

            //Console.WriteLine("The string is " + newString + ".");
            Console.WriteLine("The total length is " + newString.Length + ".");
            
            Console.WriteLine("Start: " + start + " UTC.");
            Console.WriteLine("Finish: " + DateTime.Now.ToUniversalTime() + " UTC.");

            Console.WriteLine("");
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }
    }
}
