/* Advent of Code 2015
 * 
 * Programmer: Andrew Stobart
 * Date: December 18,2020 
 * 
 * Day 1 Part 2
 *
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Part_2
{
    class Program
    {
        static void Main(string[] args)
        {
            var lines = File.ReadLines(@"C:\Users\astobart\OneDrive\Work\Code\Advent of Code\2015\Day 1\Part 1\input.txt");

            string input = "";

            //this will only be run once because there's only one line in the file
            foreach (var line in lines)
            {
                input = line.ToString();
            }

            int floor = 0;
            int instructionCount = 1;
            foreach (char character in input)
            {
                if (character == '(')
                {
                    floor++;
                }
                if (character == ')')
                {
                    floor--;
                }

                if (floor == -1)
                {
                    //break out of the Foreach loop
                    break;
                }


                instructionCount++;
            }

            Console.WriteLine("Instruction number " + instructionCount + " will cause Santa to first enter the basement.");

            Console.WriteLine("");
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }
    }
}
