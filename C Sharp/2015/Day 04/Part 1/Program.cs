/* Advent of Code 2015
 * 
 * Programmer: Andrew Stobart
 * Date: December 27,  2020
 * 
 * Day 4 Part 1
 *
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Part_1
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = "ckczppom";
            int answer = 0;
            bool answerFound = false;

            while (answerFound == false)
            {
                Console.SetCursorPosition(0, 0);
                Console.Write("Currently testing " + answer);
                string resultingHash = CreateMD5(input + answer.ToString());

                if (resultingHash.Substring(0,5) == "00000")
                {
                    //answer has been found
                    answerFound = true;
                }
                else
                {
                    answer++;
                }

            }
            //string hash = CreateMD5(input);
            Console.WriteLine("");
            Console.WriteLine("The answer is: " + answer + ".");

            Console.WriteLine("");
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }


        public static string CreateMD5(string input)
        {
            //the following is from https://stackoverflow.com/questions/11454004/calculate-a-md5-hash-from-a-string
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                // Convert the byte array to hexadecimal string
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }
    }
}
