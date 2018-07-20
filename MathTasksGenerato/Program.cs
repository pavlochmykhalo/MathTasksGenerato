using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathTasksGenerato
{
    class Program
    {
        static Random randomNumber = new Random();
        static void Main(string[] args)
        {
            Console.Write("Please enter for how many sets of tasks do you need:");
            int days = int.Parse(Console.ReadLine());
            for (int x = 1; x <= days; x++)
            {
                Generator(x);
            }

        }


        private static void Generator(int dayNumber)
        {
            int[] firstArray = new int[200];
            int[] secondArray = new int[200];
            int[] resultArray = new int[200];
            string[] taskArray = new string[200];
            string[] solvedArray = new string[200];
            for (int i = 0; i <= 199; i++)
            {
                firstArray[i] = randomNumber.Next(1, 100);
                secondArray[i] = randomNumber.Next(1, 100);
                //  Here we generate task for add numbers 
                if (i <= 49)
                {
                    resultArray[i] = firstArray[i] + secondArray[i];
                    taskArray[i] = $"{i + 1}) {firstArray[i]} + {secondArray[i]} = ";
                    solvedArray[i] = i + 1 + ") " + firstArray[i] + " + " + secondArray[i] + " = " + resultArray[i];
                }
                // Here we generate task for minus
                if (i >= 50 && i <= 99)
                {
                    if (firstArray[i] >= secondArray[i])
                    {
                        resultArray[i] = firstArray[i] - secondArray[i];
                    }
                    else
                    {

                        int[] ResultOfFloipOver = FlipOver(firstArray[i], secondArray[i]);
                        secondArray[i] = ResultOfFloipOver[1];
                        firstArray[i] = ResultOfFloipOver[0];
                        resultArray[i] = firstArray[i] - secondArray[i];
                    }
                    taskArray[i] = i + 1 + ") " + firstArray[i] + " - " + secondArray[i] + " =";
                    solvedArray[i] = i + 1 + ") " + firstArray[i] + " - " + secondArray[i] + " = " + resultArray[i];
                }
                //Here we generate task for multiplication
                if (i >= 100 && i <= 149)
                {
                    firstArray[i] = randomNumber.Next(2, 12);
                    secondArray[i] = randomNumber.Next(2, 12);
                    resultArray[i] = firstArray[i] * secondArray[i];
                    taskArray[i] = i + 1 + ") " + firstArray[i] + " X " + secondArray[i] + " =";
                    solvedArray[i] = i + 1 + ") " + firstArray[i] + " X " + secondArray[i] + " = " + resultArray[i];
                }
                if (i >= 150 && i <= 199)
                {
                    firstArray[i] = randomNumber.Next(2, 12);
                    secondArray[i] = randomNumber.Next(2, 12);
                    resultArray[i] = firstArray[i] * secondArray[i];
                    int[] ResultOfFloipOver = FlipOver(resultArray[i], firstArray[i]);
                    resultArray[i] = ResultOfFloipOver[0];
                    firstArray[i] = ResultOfFloipOver[1];
                    resultArray[i] = firstArray[i] / secondArray[i];
                    taskArray[i] = i + 1 + ") " + firstArray[i] + " / " + secondArray[i] + " =";
                    solvedArray[i] = i + 1 + ") " + firstArray[i] + " / " + secondArray[i] + " = " + resultArray[i];
                }

            }

            string pathTasks = @"C:\Ddrive\zzzzzPersonal_projects\Task_generator\tasks" + dayNumber + ".txt";
            string pathSolved = @"C:\Ddrive\zzzzzPersonal_projects\Task_generator\solved" + dayNumber + ".txt";
            File.WriteAllLines(pathTasks, taskArray);
            File.WriteAllLines(pathSolved, solvedArray);

        }

        private static int[] FlipOver(int number1, int number2)
        {
            int[] flipedArray = new int[2];
            flipedArray[0] = number2;
            flipedArray[1] = number1;
            return (flipedArray);

        }

    }
}
