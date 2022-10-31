/* Advent of Code 2015
 * 
 * Programmer: Andrew Stobart
 * Date: December 18,2020 
 * 
 * Day 1 Part 1
 *
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Part_1
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
            int count = 0;
            foreach (char character in input)
            {
                if (character == '(')
                {
                    count++;
                }
                if (character == ')')
                {
                    count--;
                }
            }

            Console.WriteLine("Santa will end up on floor " + count + ".");

            Console.WriteLine("");
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }
    }
}
