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
        public Game()
        {
            Console.WriteLine("Welcome to LudoTM by Morten and Andreas");
            AmountOfPlayers();
        }
        private void AmountOfPlayers()
        {
            int entry;
            //Console.Clear();
            Console.WriteLine("Please enter the amount of players with one key press");
            entry = Console.ReadKey().KeyChar;
            if(entry == 2  ||entry == 3 || entry == 4)
            {
                Console.WriteLine(string.Format("starting game with {0} players", entry));
            }
            else
            {
                Console.WriteLine("dick");
            }
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
