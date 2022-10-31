using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

//Advent of Code Day 4
//https://stackoverflow.com/questions/1222117/multidimensional-lists-in-c-sharp
//https://stackoverflow.com/questions/665299/are-2-dimensional-lists-possible-in-c - Make note of examples on this page

/* --> Do this instead of trying to do a 2D list. It is much more straight forward and easy to code
public class Track {
public int TrackID { get; set; }
public string Name { get; set; }
public string Artist { get; set; }
public string Album { get; set; }
public int PlayCount { get; set; }
public int SkipCount { get; set; }
}
And to create a track list as a List<Track> you simply do this:

var trackList = new List<Track>();
Adding tracks can be as simple as this:

trackList.add( new Track {
TrackID = 1234,
Name = "I'm Gonna Be (500 Miles)",
Artist = "The Proclaimers",
Album = "Finest",
PlayCount = 10,
SkipCount = 1
});
Accessing tracks can be done with the indexing operator:

Track firstTrack = trackList[0];
*/


namespace Day_4
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = File.ReadAllLines(@"C:\Users\astobart\OneDrive\Work\Code\Advent of Code\2018\Day 4\input_sorted2.txt");
            var inputList = new List<string>(input);
            var sleepLog = new List<guardSleepData>();
            int numberOfGuards = 0;




            //variables to use
            int GuardID = 0;
            int fallsAsleep = 0;
            //int wakesUp = 0;
            int timeAsleep = 0;

            for (int loop = 0; loop < inputList.Count; loop++)
            {
                string currentGuardInfo = inputList[loop];
                string[] subStrings = currentGuardInfo.Split(' ');

                if (subStrings[2] == "Guard")
                {
                    GuardID = Convert.ToInt32(subStrings[3]);
                }            

                if (subStrings[2] == "falls")
                {
                    fallsAsleep = Convert.ToInt32(subStrings[1]);
                }

                if (subStrings[2] == "wakes")
                {
                    timeAsleep = Convert.ToInt32(subStrings[1]) - fallsAsleep;

                    //if sleepLog is currently empty
                    if (sleepLog.Count == 0)
                    {
                        sleepLog.Add(new guardSleepData
                        {
                            ID = GuardID,
                            timeSleeping = timeAsleep
                        });
                        numberOfGuards++;
                    }
                    else
                    {
                        //I need to do this because when I add a new entry, this will loop one more time because the size is now one more
                        int currentSize = sleepLog.Count;
                        for (int x = 0; x < currentSize; x++)
                        {
                            if (sleepLog[x].ID == GuardID)
                            {
                                sleepLog[x].timeSleeping += timeAsleep;
                                //timeAsleep = 0;
                                x = currentSize; //we want to break out of the loop if we have matched an existing guard
                            }
                            else if (x == (currentSize - 1))
                            {
                                //add a new log entry for this guard as we are on the last entry
                                sleepLog.Add(new guardSleepData
                                {
                                    ID = GuardID,
                                    timeSleeping = timeAsleep
                                });
                                numberOfGuards++;
                            }
                        }
                    }

                }
            }

            //find guard that sleeps the most

            int topSleepyGuard = 0;
            int topSleepyGuardTime = 0;

            for (int loopy = 0; loopy < sleepLog.Count; loopy++)
            {
                //topSleepyGuard = sleepLog[loopy].ID;

                if (sleepLog[loopy].timeSleeping > topSleepyGuardTime)
                {
                    topSleepyGuard = sleepLog[loopy].ID;
                    topSleepyGuardTime = sleepLog[loopy].timeSleeping;
                }
            }




            //I manually entered "3209" below as that is the guard that was returned from the above code run for topSleepyGuard
            int[] minuteSleepTracking = new int[60];
            for (int z=0; z < 60; z++)
            {
                minuteSleepTracking[z] = 0;
            }

            int guardFound = 0;
            for (int loop = 0; loop < inputList.Count; loop++)
            {
                string currentGuardInfo = inputList[loop];
                string[] subStrings = currentGuardInfo.Split(' ');

                if (subStrings[2] == "Guard" && subStrings[3] == "3209")
                {
                    GuardID = Convert.ToInt32(subStrings[3]);
                    guardFound = 1;
                }
                if (subStrings[2] == "Guard" && subStrings[3] != "3209")
                {
                    guardFound = 0;
                }

                if (subStrings[2] == "falls" & guardFound == 1)
                {
                    fallsAsleep = Convert.ToInt32(subStrings[1]);
                }

                if (subStrings[2] == "wakes" & guardFound == 1)
                {
                    for (int mickey = fallsAsleep; mickey < Convert.ToInt32(subStrings[1]); mickey++)
                    {
                        minuteSleepTracking[mickey] += 1;
                    }

                }
            }

            //find most minute asleep
            int mostSleepingMinute = 0;
            int sleepsAtThisMinute = 0;

            for (int z = 0; z < 60; z++)
            {
                if (minuteSleepTracking[z] > sleepsAtThisMinute)
                {
                    mostSleepingMinute = z;
                    sleepsAtThisMinute = minuteSleepTracking[z];
                }
            }

            int answer = topSleepyGuard * mostSleepingMinute;
            Console.WriteLine("The guard that sleeps the most is " + topSleepyGuard);
            Console.WriteLine("The answer for part 1 is " + answer + ".");








            /************************************
            * Part 2                            *
            *************************************/


            int[,] AllGuardSleepTracking = new int[61, numberOfGuards];
            //zero all entries
            for (int xs = 0; xs < 61; xs++)
            {
                for (int xr = 0; xr < numberOfGuards; xr++)
                {
                    AllGuardSleepTracking[xs, xr] = 0;
                }
            }


            int guardRow = 0;
            for (int loop = 0; loop < inputList.Count; loop++)
            {
                string currentGuardInfo = inputList[loop];
                string[] subStrings = currentGuardInfo.Split(' ');

                if (subStrings[2] == "Guard")
                {
                    GuardID = Convert.ToInt32(subStrings[3]);
                    guardFound = 1;
                }

                if (subStrings[2] == "falls")
                {
                    fallsAsleep = Convert.ToInt32(subStrings[1]);
                }

                if (subStrings[2] == "wakes")
                {

                    //does this guard already have a row? If yes, find it. If no, add a new one.
                    for (int goofy = 0; goofy < numberOfGuards; goofy++)
                    {
                        if (AllGuardSleepTracking[60, goofy] == GuardID)
                        {
                            guardRow = goofy;
                            goofy = numberOfGuards; //break out of loop as we have found the row
                        }
                        else if (AllGuardSleepTracking[60,goofy] == 0)
                        {
                            guardRow = goofy;
                            AllGuardSleepTracking[60, goofy] = GuardID;
                            goofy = numberOfGuards; //break out of loop as we have found the row
                        }
                    }

                    for (int mickey = fallsAsleep; mickey < Convert.ToInt32(subStrings[1]); mickey++)
                    {
                        AllGuardSleepTracking[mickey,guardRow] += 1;
                    }

                }
            }

            int zzzTime = 0;
            int zzzGuard = 0;
            int zzzMinute = 0;

            //loop through new 2d array to find the guard that was asleep the most during any given minute
            for (int minute = 0; minute < 60; minute++)
            {
                for (int y = 0; y < numberOfGuards; y++)
                {
                    if (AllGuardSleepTracking[minute,y] > zzzTime)
                    {
                        zzzTime = AllGuardSleepTracking[minute,y];
                        zzzGuard = AllGuardSleepTracking[60, y];
                        zzzMinute = minute;
                    }
                }
            }


            Console.WriteLine("");
            Console.WriteLine("Part 2 answer is " + zzzGuard * zzzMinute);
            Console.WriteLine("");
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();


        }
    }
    public class guardSleepData
    {
        public int ID { get; set; }
        public int timeSleeping { get; set; }
    }
}
