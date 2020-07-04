using System;
using System.Collections;
using System.Collections.Generic;

namespace Prework_CodeChallenges
{
    class Program
    {
        static void Main(string[] args)
        {
            //Problem 1: Array Max Result
            GetScore(BuildUserArray());
        }

        //Problem 1: Array Max Result
        //Method 1
        static int[] BuildUserArray()
        {
            List<int> fiveInts = new List<int>();
            Console.WriteLine("Please enter 5 digits, all between 1 and 10 (not inclusive).");
            while (fiveInts.Count < 5)
            {
                string currEntry = null;
                switch (fiveInts.Count)
                {
                    case 0:
                        Console.WriteLine("Enter the first digit (between 1 and 10, not inclusive):");
                        currEntry = Console.ReadLine();
                        break;
                    case 1:
                        Console.WriteLine("Enter the second digit (between 1 and 10, not inclusive):");
                        currEntry = Console.ReadLine();
                        break;
                    case 2:
                        Console.WriteLine("Enter the third digit (between 1 and 10, not inclusive):");
                        currEntry = Console.ReadLine();
                        break;
                    case 3:
                        Console.WriteLine("Enter the fourth digit (between 1 and 10, not inclusive):");
                        currEntry = Console.ReadLine();
                        break;
                    case 4:
                        Console.WriteLine("Enter the fifth digit (between 1 and 10, not inclusive):");
                        currEntry = Console.ReadLine();
                        break;
                    default:
                        Console.WriteLine("Something went wrong!");
                        break;
                }
                if (Int32.TryParse(currEntry, out int intValue))
                {
                    if (intValue > 1 && intValue < 10)
                    {
                        fiveInts.Add(intValue);
                    }
                    else
                    {
                        Console.WriteLine("Your number was not between 1 and 10, please try again.");
                    }
                }
                else
                {
                    Console.WriteLine("Your entry is not an integer, please try again");
                }
            }
            return fiveInts.ToArray();
        }

        //Problem 1: Array Max Result
        //Method 2
        static void GetScore(int[] intArray)
        {
            PrintIntArray(intArray);
            Console.WriteLine("Please choose a number from the array:");
            Console.WriteLine("The score of your number is {0}", ComputeScore(intArray, GetUserInt()));
        }

        //Problem 1: Array Max Result
        //Helper Method
        static void PrintIntArray(int[] intArray)
        {
            Console.WriteLine("The entered numbers are:");
            for (int i = 0; i < intArray.Length; i++)
            {
                if (i >= intArray.Length - 1)
                {
                    Console.Write("{0}", intArray[i]);
                }
                else
                {
                    Console.Write("{0}, ", intArray[i]);
                }
            }
            Console.WriteLine();
        }

        //Problem 1: Array Max Result
        //Helper Method
        static int GetUserInt()
        {
            int? userInt = null;
            while (userInt == null)
            {
                String userEntry = Console.ReadLine();
                if (Int32.TryParse(userEntry, out int intValue))
                {
                    userInt = intValue;
                }
                else
                {
                    Console.WriteLine("Your entry is not a number, please try again.");
                }
            }
            return userInt.Value;
        }

        //Problem 1: Array Max Result
        //Helper Method
        static int ComputeScore(int[] intArray, int value)
        {
            int score = 0;
            foreach (int oneValue in intArray)
            {
                score += oneValue == value ? 1 : 0;
            }
            return score;
        }
    }
}
