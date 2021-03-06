﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Prework_CodeChallenges
{
    class Program
    {
        static void Main(string[] args)
        {
            //Problem 1: Array Max Result
            //GetScore(BuildUserArray());

            //Problem 2: Leap Year Calculator
            //LeapYearCalc(1900);
            //LeapYearCalc(2000);
            //LeapYearCalc(1996);
            //LeapYearCalc(1953);
            //LeapYearCalc(2100);
            //LeapYearCalc(2400);
            //LeapYearCalc(1700);
            //LeapYearCalc(1624);
            //LeapYearCalc(0);

            //Problem 3: Perfect Sequence
            //PerfectSequencePrint(new int[] { 2, 2 });
            //PerfectSequencePrint(new int[] { 1, 3, 2 });
            //PerfectSequencePrint(new int[] { 0, 0, 0, 0 });
            //PerfectSequencePrint(new int[] { 4, 5, 6 });
            //PerfectSequencePrint(new int[] { 0, 2, -2 });

            //Problem 4: Sum of Rows
            int[][] randIntMatrix = Generate2dIntMatrix();
            Console.WriteLine("Our randomly generated integer matrix is:");
            Console.WriteLine(Stringify2dIntMatrix(randIntMatrix));
            Console.WriteLine("The sum of the matrix's rows is:");
            Console.WriteLine(StringifyIntArray(Sum2dIntMatrixRows(randIntMatrix)));
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
            Console.WriteLine("The entered numbers are: {0}", StringifyIntArray(intArray));
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

        //Problem 2: Leap Year Calculator
        //Method 1
        static void LeapYearCalc(int year)
        {
            if (year % 4 != 0 || (year % 100 == 0 && year % 400 != 0))
            {
                Console.WriteLine("{0} is NOT a leap year.", year);
            }
            else
            {
                Console.WriteLine("{0} is a leap year.", year);
            }
        }

        //Problem 3
        //Method 1
        static void PerfectSequencePrint(int [] intArray)
        {
            int sum = 0;
            int product = 1;
            foreach (int oneInt in intArray)
            {
                if (oneInt < 0)
                {
                    product = -1;
                    break;
                }
                sum += oneInt;
                product *= oneInt;
            }
            String arrayAsString = StringifyIntArray(intArray);
            if (sum == product)
            {
                Console.WriteLine("Yes, the sequence {0} is perfect.", arrayAsString);
            }
            else
            {
                Console.WriteLine("No, the sequence {0} not is perfect.", arrayAsString);
            }
        }

        //Problem 4
        //Method 1
        static int[] Sum2dIntMatrixRows(int[][] intMatrix)
        {
            List<int> sumList = new List<int>();
            foreach (int[] innerIntArray in intMatrix)
            {
                int rowSum = 0;
                Array.ForEach(innerIntArray, oneInt => rowSum += oneInt);
                sumList.Add(rowSum);
            }
            return sumList.ToArray();
        }

        //Problem 4
        //Method 2
        static int[][] Generate2dIntMatrix()
        {
            Random rand = new Random();
            //number or rows will be 3 - 10, inclusive
            int numOfRows = rand.Next(3, 11);
            int[][] matrix = new int[numOfRows][];
            for (int i = 0; i < matrix.Length; i++)
            {
                //number of elements in each row will be 3 - 20, inclusive
                int thisRowEls = rand.Next(3, 21);
                int[] newRow = new int[thisRowEls];
                for (int j = 0; j < newRow.Length; j++)
                {
                    //each element will be an int -1000 - 1000, inclusive
                    int newEl = rand.Next(-1000, 1001);
                    newRow[j] = newEl;
                }
                matrix[i] = newRow;
            }
            return matrix;
        }

        //General Helper Methods
        static String StringifyIntArray(int[] intArray)
        {
            StringBuilder arrayString = new StringBuilder();
            for (int i = 0; i < intArray.Length; i++)
            {
                if (i >= intArray.Length - 1)
                {
                    arrayString.Append(intArray[i]);   
                }
                else
                {
                    arrayString.Append($"{intArray[i]}, ");
                }
            }
            return arrayString.ToString();
        }

        static String Stringify2dIntMatrix(int[][] intMatrix)
        {
            StringBuilder stringMatrix = new StringBuilder();
            foreach (int[] innerArray in intMatrix)
            {
                stringMatrix.AppendLine(StringifyIntArray(innerArray));
            }
            return stringMatrix.ToString();
        }

    }
}
