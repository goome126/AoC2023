using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2023
{
    internal class Day1
    {

        public Day1()
        {
            // See https://aka.ms/new-console-template for more information
            Console.WriteLine("Hello, World!");


            //Day 1 of Advent of Code 2023

            // problem at https://adventofcode.com/2023/day/1
            //data at https://adventofcode.com/2023/day/1/input

            //The intro:
            /*--- Day 1: Trebuchet?! ---
            Something is wrong with global snow production, and you've been selected to take a look. The Elves have even given you a map; on it, they've used stars to mark the top fifty locations that are likely to be having problems.

            You've been doing this long enough to know that to restore snow operations, you need to check all fifty stars by December 25th.

            Collect stars by solving puzzles. Two puzzles will be made available on each day in the Advent calendar; the second puzzle is unlocked when you complete the first. Each puzzle grants one star. Good luck!

            You try to ask why they can't just use a weather machine ("not powerful enough") and where they're even sending you ("the sky") and why your map looks mostly blank ("you sure ask a lot of questions") and hang on did you just say the sky ("of course, where do you think snow comes from") when you realize that the Elves are already loading you into a trebuchet ("please hold still, we need to strap you in").

            As they're making the final adjustments, they discover that their calibration document (your puzzle input) has been amended by a very young Elf who was apparently just excited to show off her art skills. Consequently, the Elves are having trouble reading the values on the document.

            The newly-improved calibration document consists of lines of text; each line originally contained a specific calibration value that the Elves now need to recover. On each line, the calibration value can be found by combining the first digit and the last digit (in that order) to form a single two-digit number.

            For example:

            1abc2
            pqr3stu8vwx
            a1b2c3d4e5fM
            treb7uchet
            In this example, the calibration values of these four lines are 12, 38, 15, and 77. Adding these together produces 142.

            Consider your entire calibration document. What is the sum of all of the calibration values?
             * 
             * 
             * 
             * 
             * 
             */

            //First import the data
            var data = File.ReadAllLines("data.txt");

            //First we want to start from the left of the list and grab the first integer encountered
            //Then we should start from the right and grab the first integer encountered
            //Smash them together to make a two digit number then
            //Finally we'll add all of them up
            int sum = 0;
            foreach (string line in data)
            {
                string numString = (line.First(char.IsDigit)).ToString() + (line.Last(char.IsDigit)).ToString();
                Console.WriteLine(line);
                Console.WriteLine(numString);


                //Error handling because why not
                try
                {
                    sum += int.Parse(numString);
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                    //quit the program but say something to the console and leave it open
                    Console.WriteLine("Something went wrong. Press any key to exit.");
                    Environment.Exit(1);
                }
            }

            Console.WriteLine(sum);
        }
    }
}
