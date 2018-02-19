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
        Dice dice;


        public Game()
        {
            Console.WriteLine("Welcome to LudoTM by Morten and Andreas");
            players1 = MakePlayers(AmountOfPlayers());
            Board board = new Board();
            dice = new Dice(6);
            Turn();
            Console.WriteLine(board.Info());
            Console.Read();
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
                for(int j = 0; j<4; j++)
                {
                    tokens.Add(new Token(j, 0, playerColor, TokenState.Home));
                }
                players.Add(new Player(playerColor, tokens));
            }
            return (players);
        }

        public int TurnCounter;


        private void Start(int Players)
        {

        }

        private void Turn()
        {
            string diceResult;
            Player currentPlayer = players1[TurnCounter % players1.Count];
            while (true)
            {
                Console.WriteLine("Press 'e' to throw the dice");
                char chrInput = Console.ReadKey(true).KeyChar;
                if (chrInput == 'e')
                {
                    diceResult = dice.Roll();
                    Console.WriteLine(string.Format("You have the following tokens: \n {0} \n {1} \n {2} \n {3}",currentPlayer.tokens[0], currentPlayer.tokens[1], currentPlayer.tokens[2], currentPlayer.tokens[3]));
                }

            }
            TurnCounter++;
        }

        private void End()
        {

        }
    }
}
