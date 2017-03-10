using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gold_Lotto_Checker {
    
    class Program {

        static void Main(){
            const int NUMBER_OF_ROWS = 9;

            int[][] lottoNumbers ={ 
                             new int [] { 4, 7, 19, 23, 28, 36},
                             new int [] { 14, 18, 26, 34, 38, 45},
                             new int [] { 8, 10, 11, 19, 28, 30},
                             new int [] {15, 17, 19, 24, 43, 44},
                             new int [] { 10, 27, 29, 30, 32, 41},
                             new int [] {9, 13, 26, 32, 37,  43},
                             new int [] {1, 3, 25, 27, 35, 41},
                             new int [] {7, 9, 17, 26, 28, 44},
                             new int [] {17, 18, 20, 28, 33, 38}
                              };

            int[] drawNumbers = new int[] { 44, 9, 17, 43, 26, 7, 28, 19 };

            //print header
            OutputHeader();
            //print games
            OutputGames(lottoNumbers);
            //print lotto numbers
            OutputDraw(drawNumbers);

            //repeat for each game in the lottoNumbers array
            for (int gameNumber = 0; gameNumber < NUMBER_OF_ROWS; gameNumber++){
                //check winning numbers (first 6) - return number of winning numbers
                int winningNumbers = CheckWinningNumbers(lottoNumbers[gameNumber], drawNumbers);
                //check supplementary numbers (last 2) - return number of supplementary numbers
                int supplementaryNumbers = CheckSupplementaryNumbers(lottoNumbers[gameNumber], drawNumbers);
                //print result for that game
                OutputResult(winningNumbers, supplementaryNumbers, gameNumber);
            }//end repeat

            //exit program
            ExitProgram();
        }//end Main

        static void OutputHeader(){
            /*
             * Outputs title for console
             * 
             * Precondition/Postcondition: n/a
             */
            Console.WriteLine("\n\t\t\tWelcome to Lotto Checker");
            Console.Write("\n\n\nYour Lotto numbers are");
        }//end OutputHeader

        static void OutputGames(int[][] lottoNumbers){
            /*
             * Outputs the game and the numbers in the game
             * 
             * Precondition:
             * lottoNumbers - array of games which contain sets of 6 integers
             *  
             * Postcondition: n/a 
             */
            //initialize game number counter variable at 1 to remove 0 index for user friendly display
            int gameNumber = 1;
            //for each game in list of games
            foreach (int[] game in lottoNumbers){
                //sort each game into ascending order before display
                Array.Sort(game);
                //output game number
                Console.Write("\n\nGame  {0}:", gameNumber++);
                //output each number in the game
                foreach (int number in game){
                    Console.Write("\t{0}", number);
                }
            }
        }//end OutputGame

        static void OutputDraw(int[] drawNumbers){
            /*
             * Outputs the draw and its numbers
             * 
             * Precondition:
             * drawNumbers - the array of integers for the draw
             * 
             * Postcondition: n/a
             */
            Console.WriteLine("\n\n\nLotto Draw Numbers are\n");
            //output each number in list
            foreach (int number in drawNumbers){
                Console.Write("{0}\t", number);
            }
        }//end OutputDraw

        static int CheckWinningNumbers(int[] gameNumbers, int[] drawNumbers){
            /*
             * Retrieves the number of winning numbers for a game
             * 
             * Precondition:
             * gameNumbers - array of integers for a game
             * drawNumbers - array of integers for the draw
             * 
             * Postcondition:
             * Returns the number of equal values from both arrays in the first 'gameNumbers array length' of numbers
             * 
             */
            //initialise winningNumbers count variable
            int winningNumbers = 0;
            //cycle through the gameNumbers array and the drawNumbers array's first 'gameNumbers length' of numbers
            for (int gameNumber = 0; gameNumber < gameNumbers.Length; gameNumber++){
                for (int drawNumber = 0; drawNumber < (gameNumbers.Length); drawNumber++){
                    //if the number found in gameNumbers and drawNumbers is equal
                    if (gameNumbers[gameNumber] == drawNumbers[drawNumber]){
                        //increase the winningNumbers value
                        winningNumbers++;
                    }
                }
            }
            return winningNumbers;
        }//end CheckWinningNumbers

        static int CheckSupplementaryNumbers(int[] gameNumbers, int[] drawNumbers){
            /*
             * Retrieves the amount of supplementary numbers found in a game
             * 
             * Precondition:
             * gameNumbers - array of integers for a game
             * drawNumbers - array of integers for the draw
             * 
             * Postcondition:
             * Returns the number of equal values from both arrays for the last two numbers of the drawNumbers array
             * 
             */
            //initialise supplementaryNumbers count variable
            int supplementaryNumbers = 0;
            //cycle through each of the integers in gameNumbers comparing them to the last two integers in drawNumbers
            for (int gameNumber = 0; gameNumber < gameNumbers.Length; gameNumber++){
                for (int drawNumber = 6; drawNumber < (drawNumbers.Length); drawNumber++){
                    if (gameNumbers[gameNumber] == drawNumbers[drawNumber]){
                        //if the number in gameNumbers is equal to the number in drawNumbers, increase the supplementaryNumber value
                        supplementaryNumbers++;
                    }
                }
            }
            //return the ammount of supplementary numbers found
            return supplementaryNumbers;
        }//end CheckSupplementaryNumbers

        static void OutputResult(int winningNumbers, int supplementaryNumbers, int gameNumber){
            /*
             * Outputs the number of winning and supplementary numbers in a game 
             * 
             * Precondition
             * winningNumbers - number of values from the game numbers array found in the 'winning' section of the draw numbers array (first 6)
             * supplementary numbers - number of values from the game numbers array found in the last two values of the draw numbers array
             * 
             * Postcondition: n/a
             */
            Console.WriteLine("\n\n\n\tfound {0} winning numbers and {1} supplementary numbers in Game {2}", winningNumbers, supplementaryNumbers, gameNumber + 1); //index displayed game number from 1
        }//end OutputResult

        static void ExitProgram() {
            /*
             * Prompts the user to exit the program on key press
             * Precondition/Postcondition: n/a
             */
            Console.Write("\n\nPress any key to exit program: ");
            Console.ReadKey();
        }//end ExitProgram

    } //end class Program
}
