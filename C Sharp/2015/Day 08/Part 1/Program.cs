/* Advent of Code 2015
 * 
 * Programmer: Andrew Stobart
 * Date: January 12, 2021
 * 
 * Day 8 Part 1
 *
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography.X509Certificates;

namespace Part_1
{
    class Program
    {
        static void Main(string[] args)
        {

            var lines = File.ReadLines(@"C:\Users\astobart\OneDrive\Work\Code\Advent of Code\2015\Day 8\Part 1\input.txt");

            int totalCharactersCount = 0;
            int totalStringLength = 0;

            foreach (var line in lines)
            {
                char[] charArr = line.ToCharArray();

                totalStringLength += charArr.Length;

                for (int x = 0; x < charArr.Length; x++)
                {
                    switch (charArr[x])
                    {

                        case '\\':
                            
                            if (charArr[x + 1] == 'x')
                            {
                                //this means that after the x we will have two hexadecimal charactres. This represents one character. We will skip to the character after
                                //this character by increaseing x
                                x += 3;
                                totalCharactersCount++;
                            }
                            else
                            {
                                //we are only escaping a single character
                                x++;
                                totalCharactersCount++;
                            }

                            break;

                        case '"':
                        {
                            //we don't want to count quotes
                            break;
                        }

                        default:
                            totalCharactersCount++;
                            break;
                    }
                }

            }

            int difference = totalStringLength - totalCharactersCount;
            Console.WriteLine("We have a total string length of " + totalStringLength + " with a total character count of " + totalCharactersCount + ".");
            Console.WriteLine("The difference between the two is " + difference);

            Console.WriteLine("");
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }
    }
}
