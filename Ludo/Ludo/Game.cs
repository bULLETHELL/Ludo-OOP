using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ludo
{
    class Game
    {
        enum GameState { NotStarted, InProgress, Finished};
        public Game(int players)
        {
            Console.WriteLine("Welcome to LudoTM by Morten and Andreas");
        }
        private void AmountOfPlayers()
        {
            Console.Clear();
            Console.WriteLine("Please enter the amount of players");
        }
        private void PlayerNames()
        {

        }
        private void TurnCounter()
        {

        }
        private void Start(int Players)
        {

        }
        private void End()
        {

        }
    }
}
