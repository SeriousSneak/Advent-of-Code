using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Day_3
{
    class Program
    {
        static void Main(string[] args)
        {
            //represents the 1000in by 1000in fabric piece
            int[,] fabricLayout = new int[1000, 1000];

            //set all cells in the array to 0
            for (int row = 0; row < 1000; row++)
            {
                for (int col = 0; col < 1000; col++)
                {
                    fabricLayout[row, col] = 0;
                }
            }

            //claimVariables
            int distFromLeft = 0;
            int distFromTop = 0;
            int width = 0;
            int height = 0;



            //var input = File.ReadAllLines(@"C:\Users\astobart\OneDrive\Work\Code\C#\Advent of Code\Day 3\input.txt");
            var input = File.ReadAllLines(@"C:\Users\astobart\OneDrive\Work\Code\Advent of Code\2018\Day 3\input.txt");
            var inputList = new List<string>(input);

            
            for (int loop = 0; loop < inputList.Count; loop++)
            {
                //this will need to be a variable eventually
                string currentClaim = inputList[loop];
                string[] subStrings = currentClaim.Split(' ', ',', ':', 'x');

                distFromLeft = Convert.ToInt32(subStrings[2]);
                distFromTop = Convert.ToInt32(subStrings[3]);
                width = Convert.ToInt32(subStrings[5]);
                height = Convert.ToInt32(subStrings[6]);

                /*
                Console.WriteLine("Dist from left " + distFromLeft);
                Console.WriteLine("Dist from top " + distFromTop);
                Console.WriteLine("Width " + width);
                Console.WriteLine("Height " + height);
                */
                //y is 2, height is 4


                //need two for loops to map the pattern

                for (int y = distFromTop; y < (height + distFromTop); y++)
                {
                    for (int x = distFromLeft; x < (width + distFromLeft); x++)
                    {
                        fabricLayout[x,y]++;
                    }
                }
            }

            //count how many cells have more than 1 in them

            int answer = 0;
            for (int y = 0; y < 1000; y++)
            {
                for (int x = 0; x < 1000; x++)
                {
                    if (fabricLayout[x,y] > 1)
                    {
                        answer++;
                    }
                }
            }

            Console.WriteLine("The answer is " + answer);
            Console.WriteLine("");

            //The answer is 112418

            //find the rectangle with no overlaps
            for (int loop = 0; loop < inputList.Count; loop++)
            {
                //this will need to be a variable eventually
                string currentClaim = inputList[loop];
                string[] subStrings = currentClaim.Split(' ', ',', ':', 'x');

                distFromLeft = Convert.ToInt32(subStrings[2]);
                distFromTop = Convert.ToInt32(subStrings[3]);
                width = Convert.ToInt32(subStrings[5]);
                height = Convert.ToInt32(subStrings[6]);

                /*
                Console.WriteLine("Dist from left " + distFromLeft);
                Console.WriteLine("Dist from top " + distFromTop);
                Console.WriteLine("Width " + width);
                Console.WriteLine("Height " + height);
                */
                //y is 2, height is 4


                //need two for loops to map the pattern

                int reset = 0;
                for (int y = distFromTop; y < (height + distFromTop); y++)
                {
                    for (int x = distFromLeft; x < (width + distFromLeft); x++)
                    {
                        if (fabricLayout[x, y] !=1)
                        {
                            reset = 1;
                        }
                    }
                }
                if (reset == 0)
                {
                    loop = inputList.Count;
                    Console.WriteLine("The claim is " + currentClaim);
                }
            }

            /*
            int topLeftX = 0;
            int topLeftY = 0;
            int botRightX = 0;
            int botRightY= 0;

            int topLeftFound = 0;

            for (int y = 999; y >= 0; y--)
            {
                for (int x = 0; x < 1000; x++)
                {
                    if (fabricLayout[x,y] == 1 && topLeftFound == 0)
                    {
                        topLeftX = x;
                        topLeftY = y;
                        topLeftFound = 1;
                    }
                    if (fabricLayout[x,y] == 1 && topLeftFound == 1)
                    {
                        botRightX = x;
                        botRightY = y;
                    }
                }
            }


            int finalWidth = (botRightX - topLeftX) + 1;
            int finalHeight = (topLeftY - botRightY) + 1;
            Console.WriteLine("The claim is " + topLeftX + "," + topLeftY + ": " + finalWidth + "x" + finalHeight);

            //The claim is 85,998: 834x999
            //The claim is 892,0: -782x999
*/

            /*
            foreach (var word in subStrings)
            {
                Console.WriteLine(word);
            }

            
            #1
            @
            896
            863

            29
            19
            */

            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }
    }
}
