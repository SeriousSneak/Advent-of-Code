/* Advent of Code 2015
 * 
 * Programmer: Andrew Stobart
 * Date: December 23,2020 
 * 
 * Day 2 Part 2
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

        struct dimStruct
        {
            public int length;
            public int width;
            public int height;
        }

        static void Main(string[] args)
        {
            var lines = File.ReadLines(@"C:\Users\astobart\OneDrive\Work\Code\Advent of Code\2015\Day 2\Part 1\input.txt");

            List<dimStruct> presentsList = new List<dimStruct>();
            string[] stringSeparators = new string[] { " ", "+" };


            foreach (var line in lines)
            {
                string[] subStrings = line.Split('x');
                dimStruct currentSize;

                currentSize.length = int.Parse(subStrings[0]);
                currentSize.width = int.Parse(subStrings[1]);
                currentSize.height = int.Parse(subStrings[2]);

                presentsList.Add(currentSize);
            }

            int totalPaperNeeded = 0;
            int totalRibbonNeeded = 0;

            for (int x = 0; x < presentsList.Count; x++)
            {
                dimStruct currentPresent = presentsList[x];
                totalPaperNeeded += CalcSurfaceArea(currentPresent);
                totalRibbonNeeded += CalcRibbonLength(currentPresent);
            }

            Console.WriteLine("The total amount of paper needed is " + totalPaperNeeded + ".");
            Console.WriteLine("The total amount of ribbon needed is " + totalRibbonNeeded + ".");


            Console.WriteLine("");
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }

        static int CalcSurfaceArea(dimStruct dimensions)
        {
            int length = dimensions.length;
            int width = dimensions.width;
            int height = dimensions.height;

            //calculate area
            int needed = ((2 * length * width) + (2 * width * height) + (2 * height * length));

            //add the area of the smallest side
            needed += Math.Min(Math.Min((length * width), (width * height)), (height * length));

            return needed;
        }

        static int CalcRibbonLength(dimStruct dimensions)
        {
            int length = dimensions.length;
            int width = dimensions.width;
            int height = dimensions.height;

            var val = new int[] { length, width, height };

            /*
             * The following is from https://www.tutorialspoint.com/Chash-program-to-find-Largest-Smallest-Second-Largest-Second-Smallest-in-a-List
            Largest number: val.Max(z => z);
            Smallest number: val.Min(z => z);
            Second largest number: val.OrderByDescending(z => z).Skip(1).First();
            Second smallest number: val.OrderBy(z => z).Skip(1).First();
            */

            int needed = (2 * val.Min(z => z)) + (2 * val.OrderBy(z => z).Skip(1).First());  //ribbon for present
            needed += (length * width * height);  //ribbon for bow

            return needed;
        }
    }
}
