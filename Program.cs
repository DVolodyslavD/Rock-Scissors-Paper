/*
 * "Rock, Scissors, Paper" by Volodyslav D.
 * Version 2.0
 * Creted 15/04/2024. Last update: 16/04/2024.
 */
using System;

namespace Rock_Scissors_Paper
{
    internal class Program
    {
        static void Main()
        {
            Console.WriteLine("\tWelcome to \"Rock, Scissors, Paper\" game");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");

            //An array of game items that can be selected by the user and the computer. The entire game logic is based on it.
            //IMPORTANT: Each element must beat the next one. For the last one, it is the first.
            string[] choices = { "rock", "scissors", "paper" };
            var computer = new Computer(choices);
            string userChoice;
            char wСontinue;

            do
            {
                Console.WriteLine("\nMake a choice: Rock/Scissors/Paper");

                userChoice = Console.ReadLine().ToLower();

                Console.WriteLine("----------------------");
                Console.WriteLine($"You play {userChoice}");
                Console.WriteLine($"Computer play {choices[computer.GetCompChoice()]}");

                Console.WriteLine(
                    WhoWin(computer.GetCompChoice(), Array.IndexOf(choices, userChoice), choices.Length, computer)
                    );

                Console.WriteLine("\nWant to continue (y/n)?:");
                wСontinue = (Console.ReadLine().ToLower()).ToCharArray()[0];

            } while (wСontinue == 'y');

        }

        /// <summary>
        /// Determines the winner
        /// </summary>
        /// <param name="compIndex">Index of the item selected by the computer</param>
        /// <param name="userIndex">Index of the item selected by the user</param>
        /// <param name="choicesNumber">Number of items that can be selected</param>
        /// <param name="comp">An instance of the class Computer</param>
        /// <returns>A string indicating who won the game</returns>
        static string WhoWin(int compIndex, int userIndex, int choicesNumber, Computer comp) 
        {
            if ((compIndex + 1) % choicesNumber == userIndex)
            {
                comp.SetCompShoice(compIndex, choicesNumber, false);
                //If you want the computer to choose randomly (and reduce difficulty), write this -> comp.setCompShoice();
                return "----Computer wins!----";
                
            }
            else if ((userIndex + 1) % choicesNumber == compIndex)
            {
                comp.SetCompShoice(userIndex, choicesNumber, true);
                return "------User wins!------";
            }
            else
            {
                comp.SetPaperIndex();
                //If you want the computer to choose randomly (and reduce difficulty), write this -> comp.setCompShoice();
                return "------It's a tie------";
            }
        }
    }
}