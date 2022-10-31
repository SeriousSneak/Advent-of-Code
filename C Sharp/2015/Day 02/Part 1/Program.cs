/* Advent of Code 2015
 * 
 * Programmer: Andrew Stobart
 * Date: December 22,2020 
 * 
 * Day 2 Part 1
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

            for (int x = 0; x < presentsList.Count; x++)
            {
                dimStruct currentPresent = presentsList[x];
                totalPaperNeeded += CalcSurfaceArea(currentPresent);
            }

            Console.WriteLine("The total amount of paper needed is " + totalPaperNeeded + ".");


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

    }
}
