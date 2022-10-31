using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

//The answer is not 13   :(

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int theCount = 0;
            int countOccurances = 0;
            List<int> myIntsList= new List<int>();
            int weDidIt = 0;

            while (weDidIt != 1)
            {
                var lines = File.ReadLines(@"C:\Users\astobart\OneDrive\Work\Code\C#\Advent of Code\Day 1\Problem 1\input.txt");
                foreach (var line in lines)
                {
                    theCount = theCount + Convert.ToInt32(line);
                    myIntsList.Add(theCount);

                    countOccurances = 0;
                    foreach (int pastFrequencies in myIntsList)
                    {
                        if (theCount == pastFrequencies)
                        {
                            countOccurances++;

                            if (countOccurances == 2)
                            {
                                Console.WriteLine("The first duplicate frequency is " + theCount + ". Press any key to continue.");
                                weDidIt = 1;
                                Console.ReadKey();
                            }
                        }
                    }

                }
            }
            Console.WriteLine("The answer is " + theCount + ".");
            Console.WriteLine("");
            Console.WriteLine("Press Enter to continue.");

            Console.ReadKey();
            
            //To only act if Enter is pressed
            //Console.ReadLine();
        }
    }
}
