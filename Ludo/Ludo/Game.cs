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
        List<Player> players1 = new List<Player>();

        public Game()
        {
            Console.WriteLine("Welcome to LudoTM by Morten and Andreas");
            players1 = MakePlayers(AmountOfPlayers());
            Console.WriteLine(players1[0].color);
            Console.ReadKey();
        }
        private int AmountOfPlayers()
        {
            char entry;
            //Console.Clear();
            Console.WriteLine("Please enter the amount of players with one key press");
            entry = Console.ReadKey().KeyChar;
            if(entry == '2'  ||entry == '3' || entry == '4')
            {
                Console.Clear();
                Console.WriteLine(string.Format("starting game with {0} players", entry));
                return (int)Char.GetNumericValue(entry);
            }
            else
            {
                Console.WriteLine("Faulty entry, try again");
            }
            return 0;
        }
        private List<Player> MakePlayers(int amountOfPlayers)
        {
            List<Player> players = new List<Player>();
            List<Token> tokens = new List<Token>();
            Color playerColor;
            for (int i = 0; i < amountOfPlayers; i++)
            {
                Console.WriteLine(string.Format("Please enter the desired colour for player {0}", i+1));
                while (!Enum.TryParse(Console.ReadLine(), out playerColor))
                {
                    Console.WriteLine("Entry needs to be either Red, Green, Blue or Yellow, try again");
                }

                tokens.Add(new Token(i + 1, 0, playerColor, TokenState.Home));
                players.Add(new Player(playerColor, tokens));
            }
            return (players);
        }

        /*private string PlayerNames(int amountOfPlayers)
        {
            string playerName = "";
            for (int i = 0; i < amountOfPlayers; i++)
            {
                Console.WriteLine(string.Format("Please enter the name of player {0}", i + 1));
                playerName = Console.ReadLine();
            }
            return playerName;
        }*/

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
