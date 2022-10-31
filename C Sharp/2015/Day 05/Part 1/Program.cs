/* Advent of Code 2015
 * 
 * Programmer: Andrew Stobart
 * Date: January 1, 2021
 * 
 * Day 5 Part 1
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
            var lines = File.ReadLines(@"D:\Advent of Code 2015\Advent-of-Code-2015\Day 5\Part 1\input.txt");
            int niceStrings = 0;

            foreach (var line in lines)
            {
                //bool vowelValidation = checkVowels
                if (checkVowels(line) == true && checkDoubleLetter(line) == true && checkBadStrings(line) == true)
                {
                    niceStrings++;
                }
            }

            Console.WriteLine("There are " + niceStrings + " nice strings");

            Console.WriteLine("");
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }

        public static bool checkVowels(string child)
        {
            char[] childArray = child.ToCharArray();
            int vowelCount = 0;

            foreach (char character in childArray)
            {
                if (character == 'a' || character == 'e' || character == 'i' || character == 'o' || character == 'u')
                {
                    vowelCount++;
                }
                if (vowelCount == 3)
                {
                    break;
                }
            }

            if (vowelCount == 3)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool checkDoubleLetter(string child)
        {
            char[] childArray = child.ToCharArray();
            bool check = false;

            for (int x = 0; x < (childArray.Length - 1); x++)
            {
                if (childArray[x] == childArray[x+1])
                {
                    check = true;
                    break;
                }
            }
            return check;
        }

        public static bool checkBadStrings(string child)
        {
            char[] childArray = child.ToCharArray();

            for (int x = 0; x < (childArray.Length - 1); x++)
            {
                string twoLetters = (childArray[x].ToString()) + (childArray[x + 1].ToString());
                
                if (twoLetters == "ab" || twoLetters == "cd" || twoLetters == "pq" || twoLetters == "xy")
                {
                    return false;
                }
            }

            return true;
        }
    }
}
