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
        private int amountOfPlayers;
        public Game(int players)
        {
            this.amountOfPlayers = players;
            Start(this.amountOfPlayers);
        } 
        private void Start(int Players)
        {

        }
        private void End()
        {

        }
    }
}
