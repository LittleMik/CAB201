using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Advanced_Gold_Lotto_Checker {
    class Program {
        static Random randomGen = new Random();
        static void Main() {
            const int NUMBER_OF_ROWS = 12;
            //Amount of numbers in a game
            const int chosenNumbers = 6;
            //Amount of numbers in a draw
            const int drawnNumbers = 8;

            int[][] lottoNumbers ={ 
                             new int [6],
                             new int [6],
                             new int [6],
                             new int [6],
                             new int [6],
                             new int [6],
                             new int [6],
                             new int [6],
                             new int [6],
                             new int [6],
                             new int [6],
                             new int [6] 
                              };

            int[] drawNumbers = new int[8];

            //Display Header
            OutputHeader();

            //for each game of the 12 games...
            for (int gameNumber = 0; gameNumber < NUMBER_OF_ROWS; gameNumber++){
                //generate numbers that game
                lottoNumbers[gameNumber] = GenerateNumbers(chosenNumbers);
            }
            //Output games
            OutputGames(lottoNumbers);

            //Generate draw numbers
            drawNumbers = GenerateNumbers(drawnNumbers);
            //Output draw numbers
            OutputDraw(drawNumbers);

            //Check numbers
            for (int gameNumber = 0; gameNumber < NUMBER_OF_ROWS; gameNumber++){
                //check winning numbers (first 6) - return number of winning numbers
                int winningNumbers = CheckWinningNumbers(lottoNumbers[gameNumber], drawNumbers);
                //check supplementary numbers (last 2) - return number of supplementary numbers
                int supplementaryNumbers = CheckSupplementaryNumbers(lottoNumbers[gameNumber], drawNumbers);
                //print result for that game
                OutputResult(winningNumbers, supplementaryNumbers, gameNumber);
            }
            
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
        }//end OutputHeader

        static int[] GenerateNumbers(int amount){
            /*
             * Generates a given amount of unique integers in an array
             * 
             * Precondition:
             * amount - the number of integer values to generate and return
             * 
             * Postcondition:
             * Returns an array of randomly generated integer values
             */
            int generatedNumber;
            bool unique = true;
            int[] numbers = new int [amount];
            for (int pos = 0; pos < amount; pos++){
                //generate number, check if unique, repeat if false
                do{
                    //generate number between 1 and 45
                    generatedNumber = randomGen.Next(1, 45);
                    //check generated number is unique (only if list contains numbers)
                    if (numbers.Any()){
                        unique = CheckUnique(numbers, generatedNumber);
                    }else{
                        unique = true;
                    }
                }while(!unique);
                //add number to list
                numbers[pos] = generatedNumber;
            }
            return numbers;
        }//end GenerateNumbers

        static bool CheckUnique(int[] numbers, int generatedNumber){
            /*
             * Checks if generated number is not already in list (is unique)
             * 
             * Preconditions:
             * numbers - the current array of generated integers
             * generatedNumber - the random integer generated to be tested against the numbers array
             * 
             * Postcondition:
             * Returns a bool (unique) returning true if the generatedNumber is not found in the numbers array
             */
            //initialise unique as true
            bool unique = true;
            //linear search for number equal to generated number
            for (int pos = 0; pos < numbers.Length; pos++){
                //if unique found, return unique as false
                if(generatedNumber==numbers[pos]){
                    unique = false;
                    //if false stop and return false
                    return unique;
                }
            }
            return unique;
        }//end CheckUnique

        static void OutputGames(int[][] lottoNumbers){
            /*
             * Outputs the game and the numbers in the game
             * 
             * Precondition:
             * lottoNumbers - array of games which contain sets of 6 random integers
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
             * drawNumbers - the array of randomly generated integers for the draw
             * 
             * Postcondition: n/a
             */
            Console.WriteLine("\n\nLotto Draw Numbers are\n");
            //output each number in drawNumbers array
            foreach (int number in drawNumbers){
                Console.Write("{0}\t", number);
            }
        }//end OutputDraw

        static int CheckWinningNumbers(int[] gameNumbers, int[] drawNumbers){
            /*
             * Retrieves the number of winning numbers for a game
             * 
             * Precondition:
             * gameNumbers - array of unique randomly generated integers for a game
             * drawNumbers - array of unique randomly generated integers for the draw
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
             * gameNumbers - array of unique randomly generated integers for a game
             * drawNumbers - array of unique randomly generated integers for the draw
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
                        //if the number in gameNumbers is equal to the number in drawNumbers, increase the supplementaryNumbers value
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
             * 
             */
            Console.WriteLine("\n\n\n\tfound {0} winning numbers and {1} supplementary numbers in Game {2}", winningNumbers, supplementaryNumbers, gameNumber + 1);
        }//end OutputResult

        static void ExitProgram(){
            /*
             * Prompts the user to exit the program on key press
             * Precondition/Postcondition: n/a
             */
            Console.WriteLine("\n\n\n\tThanks for using Lotto Checker");
            Console.Write("\n\nPress any key to exit program: ");
            Console.ReadKey();
        }//end ExitProgram

    } //end class Program
}
