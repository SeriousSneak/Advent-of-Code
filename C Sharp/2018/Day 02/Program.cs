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
            var input = File.ReadAllLines(@"C:\Users\astobart\OneDrive\Work\Code\Advent of Code\2018\Day 2\input.txt");
            var inputList = new List<string>(input);

            string code1 = "";
            string code2 = "";
            char code1Letter;
            char code2Letter;
            string puzzelAnswer = "";

            code1 = inputList[0];
            code2 = inputList[1];
            int notSame = 0;

            //counts the first code used
            for (int theCount = 0; theCount < inputList.Count; theCount++)
            {
                //loop for second codes
                for (int theSecondCount = theCount + 1; theSecondCount < inputList.Count; theSecondCount++)
                {
                    code1 = inputList[theCount];
                    code2 = inputList[theSecondCount];

                    for (int i = 0; i < code1.Count(); i++)
                    {
                        code1Letter = code1[i];
                        code2Letter = code2[i];

                        if (code1Letter != code2Letter)
                        {
                            notSame++;
                        }
                        else
                        {
                            puzzelAnswer += code1Letter;
                        }

                        if (notSame > 1)
                        {
                            i = code1.Count();
                        }
                    }

                    if (notSame == 1)
                    {
                        Console.WriteLine("The answer is " + puzzelAnswer + ".");
                        Console.WriteLine("");
                        Console.WriteLine("Press any key to continue.");
                        Console.ReadKey();
                    }
                    else
                    {
                        notSame = 0;
                        puzzelAnswer = "";
                    }

                    //The answer is lujnogabetpmsydyfcovzixaw.
                }
            }
        }
    }
}




/*
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
            */