/* Advent of Code 2015
 * 
 * Programmer: Andrew Stobart
 * Date: January 6, 2021
 * 
 * Day 7 Part 1
 *
 */


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.CompilerServices;

namespace Part_1
{
    class Program
    {
        struct instructionStruct
        {
            public string operation;
            public string targetWire;
            public string inputWire1;
            public string inputWire2;
        }
        static void Main(string[] args)
        {
            var lines = File.ReadLines(@"C:\Users\astobart\OneDrive\Work\Code\Advent of Code\2015\Day 7\Part 1\input.txt");

            string[] stringSeparators = new string[] { " ", "->"};
            Dictionary<string, ushort> myDic = new Dictionary<string, ushort>();
            List<instructionStruct> inputList = new List<instructionStruct>();

            //fill up our List with all of the instructions from the Input file
            foreach (var line in lines)
            {
                string[] subStrings = line.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
                instructionStruct currentInstruction = new instructionStruct();

                if (subStrings.Length == 4)
                {
                    currentInstruction.inputWire1 = subStrings[0];
                    currentInstruction.operation = subStrings[1];
                    currentInstruction.inputWire2 = subStrings[2];
                    currentInstruction.targetWire = subStrings[3];

                    inputList.Add(currentInstruction);
                }
                else if (subStrings.Length == 3) //Length must be 3 and this must be a NOT operation
                {
                    currentInstruction.operation = subStrings[0];
                    currentInstruction.inputWire1 = subStrings[1];
                    currentInstruction.targetWire = subStrings[2];
                    currentInstruction.inputWire2 = "NotUsed";

                    inputList.Add(currentInstruction);
                }
                else if (subStrings.Length == 2) //we have a direct assignment here
                {
                    currentInstruction.inputWire1 = subStrings[0];
                    currentInstruction.targetWire = subStrings[1];
                    currentInstruction.operation = "DirectAssignment";
                    currentInstruction.inputWire2 = "NotUsed";

                    inputList.Add(currentInstruction);
                }
                else
                {
                    Console.WriteLine(line + " was not processed.");
                }
            }

            int loopCount = 1;
            while (!myDic.ContainsKey("a"))  //keep looping and filling in the values we can on each loop. Do this until we have a value for wire A
            {
                Console.SetCursorPosition(0, 0);
                Console.Write("Entered loop " + loopCount);
                loopCount++;

                //keep looping and fill in the values we can on each loop
                for (int x = 0; x < inputList.Count; x++)
                {

                    switch (inputList[x].operation)
                    {
                        case "AND":
                            //in this IF statement I'm checking to see if Wire1 is either a value for a wire we know, or a direct number. Also ensuring we have a value for Wire2, 
                            //and ensuring we don't already have a value for the TargetWire in the dictionary
                            if ((myDic.ContainsKey(inputList[x].inputWire1) || inputList[x].inputWire1.All(char.IsDigit)) && myDic.ContainsKey(inputList[x].inputWire2) && !myDic.ContainsKey(inputList[x].targetWire))
                            {
                                ushort wire1;
                                if (inputList[x].inputWire1.All(char.IsDigit))  //accounts for if Wire1 is a direct value and not a referense to a wire
                                {
                                    wire1 = Convert.ToUInt16(inputList[x].inputWire1);
                                }
                                else
                                {
                                    wire1 = myDic[inputList[x].inputWire1];
                                }

                                ushort wire2 = myDic[inputList[x].inputWire2];

                                ushort result = (ushort)(Convert.ToInt32(wire1) & Convert.ToInt32(wire2)); //bitwise can only be done on Int32. I then cast back to ushort.

                                myDic.Add(inputList[x].targetWire, result);
                            }
                            break;

                        case "OR":
                            if ((myDic.ContainsKey(inputList[x].inputWire1) || inputList[x].inputWire1.All(char.IsDigit)) && myDic.ContainsKey(inputList[x].inputWire2) && !myDic.ContainsKey(inputList[x].targetWire))
                            {
                                ushort wire1;
                                if (inputList[x].inputWire1.All(char.IsDigit))  //accounts for if Wire1 is a direct value and not a referense to a wire
                                {
                                    wire1 = Convert.ToUInt16(inputList[x].inputWire1);
                                }
                                else
                                {
                                    wire1 = myDic[inputList[x].inputWire1];
                                }

                                ushort wire2 = myDic[inputList[x].inputWire2];

                                ushort result = (ushort)(Convert.ToInt32(wire1) | Convert.ToInt32(wire2)); //bitwise can only be done on Int32. I then cast back to ushort.

                                myDic.Add(inputList[x].targetWire, result);
                            }
                            break;

                        case "NOT":
                            if (myDic.ContainsKey(inputList[x].inputWire1) && !myDic.ContainsKey(inputList[x].targetWire))
                            {
                                ushort result = (ushort)~(Convert.ToInt32(myDic[inputList[x].inputWire1]));
                                myDic.Add(inputList[x].targetWire, result);
                            }
                            break;

                        case "LSHIFT":
                            if (myDic.ContainsKey(inputList[x].inputWire1) && !myDic.ContainsKey(inputList[x].targetWire))
                            {
                                ushort wire1 = myDic[inputList[x].inputWire1];
                                //ushort result = myDic(inputList[x].inputWire1) << inputList[x].inputWire2;

                                ushort result = (ushort)(Convert.ToInt32(wire1) << Convert.ToInt32(inputList[x].inputWire2));

                                myDic.Add(inputList[x].targetWire, result);
                            }
                            break;

                        case "RSHIFT":
                            if (myDic.ContainsKey(inputList[x].inputWire1) && !myDic.ContainsKey(inputList[x].targetWire))
                            {
                                ushort wire1 = myDic[inputList[x].inputWire1];
                                ushort result = (ushort)(Convert.ToInt32(wire1) >> Convert.ToInt32(inputList[x].inputWire2));

                                myDic.Add(inputList[x].targetWire, result);
                            }
                            break;

                        case "DirectAssignment":
                            if (myDic.ContainsKey(inputList[x].inputWire1) && !myDic.ContainsKey(inputList[x].targetWire))
                            {
                                myDic.Add(inputList[x].targetWire, myDic[inputList[x].inputWire1]);
                            }
                            else if (inputList[x].inputWire1.All(char.IsDigit) && !myDic.ContainsKey(inputList[x].targetWire))
                            {
                                myDic.Add(inputList[x].targetWire, Convert.ToUInt16(inputList[x].inputWire1));
                            }
                            break;

                        default:
                            Console.WriteLine("An entry was not processed");
                            break;
                    }

                }
            }
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("Wire A has a value of " + myDic["a"] + ".");

            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }
    }
}
