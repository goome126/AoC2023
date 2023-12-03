using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2023
{
    internal class Day2
    {
        //The constructor for the class should run the program to solve the problem
        public Day2()
        {
            // problem at https://adventofcode.com/2023/day/2
            //data at https://adventofcode.com/2023/day/2/input

            /* 
             * --- Day 2: Cube Conundrum ---

             * You're launched high into the atmosphere! The apex of your trajectory just barely reaches the surface of a large island floating in the sky. You gently land in a fluffy pile of leaves. It's quite cold, but you don't see much snow. An Elf runs over to greet you.
    
             * The Elf explains that you've arrived at Snow Island and apologizes for the lack of snow. He'll be happy to explain the situation, but it's a bit of a walk, so you have some time. They don't get many visitors up here; would you like to play a game in the meantime?

             * As you walk, the Elf shows you a small bag and some cubes which are either red, green, or blue. Each time you play this game, he will hide a secret number of cubes of each color in the bag, and your goal is to figure out information about the number of cubes.

             * To get information, once a bag has been loaded with cubes, the Elf will reach into the bag, grab a handful of random cubes, show them to you, and then put them back in the bag. He'll do this a few times per game.

             * You play several games and record the information from each game (your puzzle input). Each game is listed with its ID number (like the 11 in Game 11: ...) followed by a semicolon-separated list of subsets of cubes that were revealed from the bag (like 3 red, 5 green, 4 blue).

             * For example, the record of a few games might look like this:
             * Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green
             * Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue
             * Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red
             * Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red
             * Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green
             * In game 1, three sets of cubes are revealed from the bag (and then put back again). The first set is 3 blue cubes and 4 red cubes; the second set is 1 red cube, 2 green cubes, and 6 blue cubes; the third set is only 2 green cubes.

             * The Elf would first like to know which games would have been possible if the bag contained only 12 red cubes, 13 green cubes, and 14 blue cubes?

             * In the example above, games 1, 2, and 5 would have been possible if the bag had been loaded with that configuration. However, game 3 would have been impossible because at one point the Elf showed you 20 red cubes at once; similarly, game 4 would also have been impossible because the Elf showed you 15 blue cubes at once. If you add up the IDs of the games that would have been possible, you get 8.

             * Determine which games would have been possible if the bag had been loaded with only 12 red cubes, 13 green cubes, and 14 blue cubes. What is the sum of the IDs of those games?
             * 
             * 
             * 
             * 
             */

            //Grab the list of games from the input file
            string[] games = System.IO.File.ReadAllLines("day2.txt");

            //Day2Part1(games);
            Day2Part2(games);
        }

        public void Day2Part1(string[] games)
        {
            //Initiliaze a sum variable to hold the sum of the gameIDs
            int sumOfGameIDs = 0;

            // for each game we need to check it's possible given the number of cubes
            // we need to split the game into the number of cubes and the number of each colour
            // then we need to check if the number of cubes is less than the number of each colour
            // if it is then the game is possible and we should add the GameID to a running sum
            // if it isn't then the game is not possible and we should move on to the next game
            foreach (string game in games)
            {
                // split the game into the gameID and the list of cubes
                string[] gameSplit = game.Split(':');
                // get the gameID
                int gameID = int.Parse(gameSplit[0].Split(' ')[1]);
                // get the list of cubes
                string[] cubePulls = gameSplit[1].Split(';');
                // get the number of each colour
                bool gamePossible = true;
                foreach (string cubePull in cubePulls)
                {
                    // split the cubepull into the cubes via ,
                    string[] cubes = cubePull.Split(',');
                    foreach (string cube in cubes)
                    {
                        int numberOfCubes;
                        string colourOfCubes;
                        // split the cube into the number and the colour
                        string[] cubeSplit = cube.Split(' ');
                        try
                        {
                            // get the number of cubes
                            numberOfCubes = int.Parse(cubeSplit[0]);
                            colourOfCubes = cubeSplit[1];
                        }
                        catch (Exception)
                        {
                            // if the number of cubes is not a number then it is an empty space and we should parse the next number in cubeSplit
                            numberOfCubes = int.Parse(cubeSplit[1]);
                            colourOfCubes = cubeSplit[2];
                        }
                        // get the number of cubes
                        //int numberOfCubes = int.Parse(cubeSplit[0]);
                        // get the colour of the cubes

                        // add the number of cubes to the running total
                        if (colourOfCubes == "red")
                        {
                            if (numberOfCubes > 12)
                            {
                                //game not possible
                                gamePossible = false;
                            }
                        }
                        else if (colourOfCubes == "green")
                        {
                            if (numberOfCubes > 13)
                            {
                                //game not possible
                                gamePossible = false;
                            }
                        }
                        else if (colourOfCubes == "blue")
                        {
                            if (numberOfCubes > 14)
                            {
                                //game not possible
                                gamePossible = false;
                            }
                        }
                    }
                }
                // check if the game is possible, if it wasn't set to false then it is possible
                if (gamePossible)
                {

                    // if it is then add the gameID to the running sum
                    Console.WriteLine("Game " + gameID + " is possible");
                    sumOfGameIDs += gameID;
                }
                else
                {
                    // if it isn't then move on to the next game
                    Console.WriteLine("Game " + gameID + " is not possible");
                }
            }
            Console.WriteLine("The sum of the possible gameIDs is " + sumOfGameIDs);

        }


        //Day2 Part 2 Problem
        /*
         * 
         * 
         --- Part Two ---
The Elf says they've stopped producing snow because they aren't getting any water! He isn't sure why the water stopped; however, he can show you how to get to the water source to check it out for yourself. It's just up ahead!

As you continue your walk, the Elf poses a second question: in each game you played, what is the fewest number of cubes of each color that could have been in the bag to make the game possible?

Again consider the example games from earlier:

Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green
Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue
Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red
Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red
Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green
In game 1, the game could have been played with as few as 4 red, 2 green, and 6 blue cubes. If any color had even one fewer cube, the game would have been impossible.
Game 2 could have been played with a minimum of 1 red, 3 green, and 4 blue cubes.
Game 3 must have been played with at least 20 red, 13 green, and 6 blue cubes.
Game 4 required at least 14 red, 3 green, and 15 blue cubes.
Game 5 needed no fewer than 6 red, 3 green, and 2 blue cubes in the bag.
The power of a set of cubes is equal to the numbers of red, green, and blue cubes multiplied together. The power of the minimum set of cubes in game 1 is 48. In games 2-5 it was 12, 1560, 630, and 36, respectively. Adding up these five powers produces the sum 2286.

For each game, find the minimum set of cubes that must have been present. What is the sum of the power of these sets?
         
         
         */


        public void Day2Part2(string[] games)
        {

            // create a running total of the sum of the power of the games
            int sumOfPowerOfGames = 0;
            // for each game
           foreach(string game in games)
            {
                string[] gameSplit = game.Split(':');
                // Split the game into the cubePulls, and find the highest number of each colour each time it appears
                // then multiply the highest number of each colour together to get the power of the game
                // then add the power of the game to a running total

                string gameID = gameSplit[0].Split(' ')[1];
                // split the game into the list of cubePulls
                string[] cubePulls = gameSplit[1].Split(';');
                // create a list of the highest number of each colour
                int[] highestNumberOfEachColour = new int[3];
                // for each cubePull
                foreach(string cubePull in cubePulls)
                {
                    // split the cubePull into the cubes
                    string[] cubes = cubePull.Split(',');
                    // for each cube
                    foreach(string cube in cubes)
                    {
                        // split the cube into the number and the colour
                        string[] cubeSplit = cube.Split(' ');
                        // get the number of cubes
                        int numberOfCubes;
                        // get the colour of the cubes
                        string colourOfCubes;
                        try
                        {
                            // get the number of cubes
                            numberOfCubes = int.Parse(cubeSplit[0]);
                            colourOfCubes = cubeSplit[1];
                        }
                        catch (Exception)
                        {
                            // if the number of cubes is not a number then it is an empty space and we should parse the next number in cubeSplit
                            numberOfCubes = int.Parse(cubeSplit[1]);
                            colourOfCubes = cubeSplit[2];
                        }
                        // check if the number of cubes is higher than the highest number of cubes of that colour
                        if (colourOfCubes == "red")
                        {
       
                            if (numberOfCubes > highestNumberOfEachColour[0])
                            {
                                // if it is then set the highest number of cubes of that colour to the number of cubes
                                highestNumberOfEachColour[0] = numberOfCubes;
                            }
                        }
                        else if (colourOfCubes == "green")
                        {
                            if (numberOfCubes > highestNumberOfEachColour[1])
                            {
                                // if it is then set the highest number of cubes of that colour to the number of cubes
                                highestNumberOfEachColour[1] = numberOfCubes;
                            }
                        }
                        else if (colourOfCubes == "blue")
                        {
                            if (numberOfCubes > highestNumberOfEachColour[2])
                            {
                                // if it is then set the highest number of cubes of that colour to the number of cubes
                                highestNumberOfEachColour[2] = numberOfCubes;
                            }
                        }
                    }
                }
                Console.WriteLine("The highest number of red cubes is " + highestNumberOfEachColour[0]);
                Console.WriteLine("The highest number of green cubes is " + highestNumberOfEachColour[1]);
                Console.WriteLine("The highest number of blue cubes is " + highestNumberOfEachColour[2]);
                //Calculate the power of the game
                int powerOfGame = highestNumberOfEachColour[0] * highestNumberOfEachColour[1] * highestNumberOfEachColour[2];
                // add the power of the game to the running total
                sumOfPowerOfGames += powerOfGame;
                Console.WriteLine("The power of the game is " + powerOfGame);
            }


           Console.WriteLine("The sum of the power of the games is " + sumOfPowerOfGames);

        }



    }


}
