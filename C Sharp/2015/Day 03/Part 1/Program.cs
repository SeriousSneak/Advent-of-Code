/* Advent of Code 2015
 * 
 * Programmer: Andrew Stobart
 * Date: December 23,2020 
 * 
 * Day 3 Part 1
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
        struct locStruct
        {
            public int row;
            public int col;
        }
        static void Main(string[] args)
        {
            var lines = File.ReadLines(@"C:\Users\astobart\OneDrive\Work\Code\Advent of Code\2015\Day 3\Part 1\input.txt");
            string input = "";
            int houseCount = 1;
            locStruct currentLocation;
            currentLocation.col = 0;
            currentLocation.row = 0;

            //I'm using a Dictionary with the coordinates visited as the key. This way I just need to see if the current coordinate exists, 
            //and if so, it's a dupliate present, if not, add it.
            Dictionary<locStruct, char> myDic = new Dictionary<locStruct, char>();

            myDic.Add(currentLocation, 'x');

            //this will only be run once beacuse there's only one line in the file
            foreach (var line in lines)
            {
                input = line.ToString();
            }
                
            foreach (char direction in input)
            {
                switch (direction)
                {
                    case '^':
                        currentLocation.row++;
                        break;

                    case '>':
                        currentLocation.col++;
                        break;

                    case 'v':
                        currentLocation.row--;
                        break;

                    case '<':
                        currentLocation.col--;
                        break;

                    default: //this should never be called
                        break;
                }

                if (myDic.ContainsKey(currentLocation) == false)
                {
                    myDic.Add(currentLocation, 'x');
                    houseCount++;
                }

            }

            Console.WriteLine("The number of houses that receive at least one gift: " + houseCount + ".");

            Console.WriteLine("");
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }
    }
}
