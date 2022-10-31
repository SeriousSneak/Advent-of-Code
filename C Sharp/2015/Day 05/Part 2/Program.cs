/* Advent of Code 2015
 * 
 * Programmer: Andrew Stobart
 * Date: January 4, 2021
 * 
 * Day 5 Part 2
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
            var lines = File.ReadLines(@"C:\Users\astobart\OneDrive\Work\Code\Advent of Code\2015\Day 5\Part 2\input.txt");
            int niceStrings = 0;

            foreach (var line in lines)
            {
                if (checkPairRepeat(line) == true && checkSingleRepeat(line) == true)
                {
                    niceStrings++;
                }
            }

            Console.WriteLine("There are " + niceStrings + " nice strings");

            Console.WriteLine("");
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();

        }

        public static bool checkPairRepeat(string child)
        {
            char[] childArray = child.ToCharArray();

            for (int x = 0; x < (childArray.Length - 3); x++)
            {
                string firstPair = childArray[x].ToString() + childArray[x + 1].ToString();

                for (int y = (x+2); y < (childArray.Length - 1); y++)
                {
                    string secondPair = childArray[y].ToString() + childArray[y + 1].ToString();

                    if (firstPair == secondPair)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public static bool checkSingleRepeat(string child)
        {
            char[] childArray = child.ToCharArray();
            
            for (int x = 0; x < (childArray.Length - 2); x++)
            {
                if (childArray[x] == childArray[x + 2])
                {
                    return true;
                }
            }

            return false;
        }

    }
}
