/* Advent of Code 2015
 * 
 * Programmer: Andrew Stobart
 * Date: December 27,2020 
 * 
 * Day 3 Part 2
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
        struct locStruct
        {
            public int row;
            public int col;
        }
        static void Main(string[] args)
        {
            var lines = File.ReadLines(@"D:\Advent of Code 2015\Advent-of-Code-2015\Day 3\Part 2\input.txt");
            string input = "";
            int houseCount = 1;

            locStruct santaLocation;
            locStruct roboSantaLocation;

            santaLocation.col = 0;
            santaLocation.row = 0;
            roboSantaLocation.col = 0;
            roboSantaLocation.row = 0;

            //I'm using a Dictionary with the coordinates visited as the key. This way I just need to see if the current coordinate exists, 
            //and if so, it's a dupliate present, if not, add it.
            Dictionary<locStruct, char> myDic = new Dictionary<locStruct, char>();

            myDic.Add(santaLocation, 'x');

            //this will only be run once beacuse there's only one line in the file
            foreach (var line in lines)
            {
                input = line.ToString();
            }

            bool santasTurn = true;

            foreach (char direction in input)
            {
                switch (direction)
                {
                    case '^':
                        if (santasTurn == true)
                            santaLocation.row++;
                        else
                            roboSantaLocation.row++;
                        break;

                    case '>':
                        if (santasTurn == true)
                            santaLocation.col++;
                        else
                            roboSantaLocation.col++;
                        break;

                    case 'v':
                        if (santasTurn == true)
                            santaLocation.row--;
                        else
                            roboSantaLocation.row--;
                        break;

                    case '<':
                        if (santasTurn == true)
                            santaLocation.col--;
                        else
                            roboSantaLocation.col--;
                        break;

                    default: //this should never be called
                        break;
                }

                if (santasTurn == true)
                {
                    if (myDic.ContainsKey(santaLocation) == false)
                    {
                        myDic.Add(santaLocation, 'x');
                        houseCount++;
                    }
                    santasTurn = false;
                }
                else
                {
                    if (myDic.ContainsKey(roboSantaLocation) == false)
                    {
                        myDic.Add(roboSantaLocation, 'x');
                        houseCount++;
                    }
                    santasTurn = true;
                }
            }

            Console.WriteLine("The number of houses that receive at least one gift: " + houseCount + ".");

            Console.WriteLine("");
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }
    }
}
