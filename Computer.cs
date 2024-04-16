using System;

namespace Rock_Scissors_Paper
{
    /// <summary>
    /// User's opponent
    /// </summary>
    internal class Computer
    {
        private string[] items;
        /// <summary>
        /// Index of the item selected by the computer
        /// </summary>
        private int compChoice;
        /// <summary>
        /// Number of items that can be selected
        /// </summary>
        private int choicesNumber;
        /// <summary>
        /// Stores a random number
        /// </summary>
        private Random randNumber = new Random();

        /// <summary>
        /// Constructor of the class Computer
        /// </summary>
        /// <param name="choicesNumber">Number of items that can be selected</param>
        public Computer(string[] items)
        {
            this.items = items;
            choicesNumber = items.Length;
            SetCompShoice();
        }

        /// <summary>
        /// Randomly sets the choice of computer
        /// </summary>
        public void SetCompShoice()
        {
            compChoice = randNumber.Next(choicesNumber);
        }

        /// <summary>
        /// Sets the choice of computer based on the winner's item.
        /// </summary>
        /// <param name="itemWinner">Index of the winning item</param>
        /// <param name="num">Number of game elements</param>
        /// <param name="userWon">True, if the user wins</param>
        /* The computer chooses the item that wins the user's item.
         * This works due to the fact that in the array of game items, each one is facing the one it wins.*/
        public void SetCompShoice(int itemWinner, int num, bool userWon)
        {
            int step;
            if (userWon == true)
            {
                step = 1;
            }
            else
            {
                step = 2;
            }

            compChoice = itemWinner - step;

            if (compChoice < 0)
            {
                compChoice = num + compChoice;
            }
        }

        /// <summary>
        /// </summary>
        /// <returns>Index of the item selected by the computer</returns>
        public int GetCompChoice()
        {
            return compChoice;
        }

        /// <summary>
        /// Makes paper the computer's choice
        /// </summary>
        public void SetPaperIndex()
        {
            compChoice = Array.IndexOf(items, "paper");
        }           
    }
}
