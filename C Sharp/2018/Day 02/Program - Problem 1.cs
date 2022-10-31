using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Day_2
{
    class Program
    {
        static void Main(string[] args)
        {
            var lines = File.ReadLines(@"C:\Users\astobart\OneDrive\Work\Code\C#\Advent of Code\Day 2\input.txt");
            int[] alphabetArray = new int[26];
            zeroArray();
            char letterRead;
            int letterIndex;
            int codeWithTwoMatchingLetters = 0;
            int codeWithThreeMatchingLetters = 0;
            int alreadyCountedAsTwo = 0;
            int alreadyCountedAsThree = 0;
            
            //loop through each word
            foreach (var line in lines)
            {
                //loop through each letter
                for (int i = 0; i < line.Count(); i++)
                {
                    letterRead = line[i];
                    letterIndex = char.ToUpper(letterRead) - 64;

                    alphabetArray[letterIndex - 1]++;
                }

                //loop through array to count occurances
                for (int i = 0; i < 26; i++)
                {
                    if (alphabetArray[i] == 2 && alreadyCountedAsTwo == 0)
                    {
                        codeWithTwoMatchingLetters++;
                        alreadyCountedAsTwo = 1;
                    }
                    if (alphabetArray[i] == 3 && alreadyCountedAsThree == 0)
                    {
                        codeWithThreeMatchingLetters++;
                        alreadyCountedAsThree = 1;
                    }
                }

                alreadyCountedAsTwo = 0;
                alreadyCountedAsThree = 0;
                zeroArray();






            }

            int checkSum = codeWithThreeMatchingLetters * codeWithTwoMatchingLetters;

            Console.WriteLine("The checksum is " + checkSum + ".");
            Console.WriteLine("");
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();

            void zeroArray()
            {
                //set all cells in the array to 0
                for (int i = 0; i < 26; i++)
                {
                    alphabetArray[i] = 0;
                }

            }
        }


    }
}
