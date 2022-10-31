/* Advent of Code 2015
 * 
 * Programmer: Andrew Stobart
 * Date: January 14, 2021
 * 
 * Day 8 Part 2
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
            var lines = File.ReadLines(@"C:\Users\astobart\OneDrive\Work\Code\Advent of Code\2015\Day 8\Part 2\input.txt");

            int totalCharactersCount = 0;
            int totalStringLength = 0;
            

            foreach (var line in lines)
            {
                int singleStringCharacterCount = 2;

                char[] charArr = line.ToCharArray();

                totalStringLength += charArr.Length;
                totalCharactersCount += 2;

                for (int x = 0; x < charArr.Length; x++)
                {
                    switch (charArr[x])
                    {

                        case '\\':
                            totalCharactersCount += 2;
                            singleStringCharacterCount += 2;
                            break;

                        case '"':
                            totalCharactersCount += 2;
                            singleStringCharacterCount += 2;        
                            break;

                        default:
                            totalCharactersCount++;
                            singleStringCharacterCount++;
                            break;
                    }
                }

                Console.WriteLine(line + " contains " + singleStringCharacterCount + " characters.");
            }

            int difference = totalCharactersCount - totalStringLength;

            Console.WriteLine("We have a total string length of " + totalStringLength + " with a total character count of " + totalCharactersCount + ".");
            Console.WriteLine("The difference between the two is " + difference);

            Console.WriteLine("");
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }
    }
}
