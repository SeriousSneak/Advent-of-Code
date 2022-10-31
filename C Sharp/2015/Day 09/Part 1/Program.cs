/* Advent of Code 2015
 * 
 * Programmer: Andrew Stobart
 * Date: January 18, 2021
 * 
 * Day 9 Part 1
 *
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;


//I used code from https://www.codeproject.com/articles/43767/a-c-list-permutation-iterator to calculate all of the different permutations
namespace Part_1
{
    class Program
    {
        static void Main(string[] args)
        {
            var lines = File.ReadLines(@"C:\Users\astobart\OneDrive\Work\Code\Advent of Code\2015\Day 9\Part 1\input.txt");

            Dictionary<string, int> distanceDic = new Dictionary<string, int>(); //this will store our distances. They key will be two city names put together into one string

            List<string> cityList = new List<string>();

            string[] stringSeparators = new string[] { "to", " ", "=" };

            foreach (var line in lines)
            {
                string[] currentLine = line.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
                /**************************************
                FILL UP OUR CITY LIST
                ***************************************/

                bool city1Found = false;
                bool city2Found = false;

                foreach (string city in cityList)
                {
                    if (city == currentLine[0])
                    {
                        city1Found = true;
                    }

                    if (city == currentLine[1])
                    {
                        city2Found = true;

                    }
                }

                if (city1Found == false)
                {
                    cityList.Add(currentLine[0]);
                }

                if (city2Found == false)
                {
                    cityList.Add(currentLine[1]);
                }


                /**************************************
                POPULATE OUR DICTIONARY
                ***************************************/
                string key = currentLine[0] + currentLine[1];
                int value = Convert.ToInt32(currentLine[2]);
                distanceDic.Add(key, value);
            }




            //List<int> seq = new List<int>() { 1, 2, 3, 4 };
            //List<string> seq = new List<string>() { "Chicago", "Seattle", "Orlando", "Paris" };
            //foreach (var permu in Permutate(seq, seq.Count))

            string[] stopOrder = new string[cityList.Count];
            
            int totalDistance;
            int shortestDistance = 0;
            bool firstRun = true;

            foreach (var permu in Permutate(cityList, cityList.Count))
            {
                int count = 0;
                foreach (var i in permu)
                {
                    stopOrder[count] = i.ToString();
                    count++;
                    //Console.Write(i.ToString() + " ");
                }

                totalDistance = 0;
                for (int x = 0; x <= (cityList.Count - 2); x++)
                {
                    string city1 = stopOrder[x];
                    string city2 = stopOrder[x + 1];

                    string city1city2 = city1 + city2;
                    string city2city1 = city2 + city1;

                    if (distanceDic.ContainsKey(city1city2))
                    {
                        totalDistance += distanceDic[city1city2];
                    }
                    else //must be filed under city2city1
                    {
                        totalDistance += distanceDic[city2city1];
                    }
                }

                if (firstRun == true)
                {
                    shortestDistance = totalDistance;
                    firstRun = false;
                }
                else
                {
                    if (totalDistance < shortestDistance)
                    {
                        shortestDistance = totalDistance;
                    }
                }
                
            }

            Console.WriteLine("The shortest distance is " + shortestDistance + ".");

            Console.WriteLine("");
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }



        public static void RotateRight(IList sequence, int count)
        {
            object tmp = sequence[count - 1];
            sequence.RemoveAt(count - 1);
            sequence.Insert(0, tmp);
        }

        public static IEnumerable<IList> Permutate(IList sequence, int count)
        {
            if (count == 1) 
                yield return sequence;
            else
            {
                for (int i = 0; i < count; i++)
                {
                    foreach (var perm in Permutate(sequence, count - 1))
                        yield return perm;
                    RotateRight(sequence, count);
                }
            }
        }
    }
}
