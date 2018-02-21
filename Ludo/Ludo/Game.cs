using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ludo
{
    public class Game
    {
        enum GameState { NotStarted, InProgress, Finished};
        List<Player> players = new List<Player>();
        Dice dice;
        public Board board;
        bool gameEnded = false;

        public Game()
        {
            board = new Board();
            dice = new Dice(6);
            Console.WriteLine(board.Info());
            Console.WriteLine("Welcome to LudoTM by Morten and Andreas");
            players = MakePlayers(AmountOfPlayers());
            while (!gameEnded)
            {
                Turn();
            }
                      
            Console.ReadKey();
        }
        private int AmountOfPlayers()
        {
            char entry;
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
            Color playerColor;
            for (int i = 0; i < amountOfPlayers; i++)
            {
                Console.WriteLine(string.Format("Please enter the desired colour for player {0}", i+1));
                while (!Enum.TryParse(Console.ReadLine(), out playerColor))
                {
                    Console.WriteLine("Entry needs to be either Red, Green, Blue or Yellow, try again");
                }
                players.Add(new Player(playerColor));
            }
            Console.Clear();
            return (players);            
        }

        public int TurnCounter;


        private void Start(int Players)
        {

        }

        private void Turn()
        {
            int throwCounter = 0;
            string diceResult = "";
            int tokensInPlay = 0;
            Player currentPlayer = players[TurnCounter % players.Count];

            SetColour(currentPlayer);
            Console.WriteLine(string.Format("Current player is the {0} player", currentPlayer.color));
            writeCurrentPosition(currentPlayer);

            do
            {
                //TokensInPlay(currentPlayer);
                Console.WriteLine("Press 'e' to throw the dice");
                char chrInput = Console.ReadKey(true).KeyChar;
                if (chrInput == 'e')
                {
                    diceResult = dice.Roll();
                }
                Console.WriteLine(string.Format("you rolled a '{0}' ", diceResult));
                Console.WriteLine("Which token would you like to move(use the 1, 2, 3 or 4 key)");
                switch (Console.ReadKey(true).KeyChar)
                {
                    case '1':
                        currentPlayer.tokens[0].Move(diceResult, board);
                        break;
                    case '2':
                        currentPlayer.tokens[1].Move(diceResult, board);
                        break;
                    case '3':
                        currentPlayer.tokens[2].Move(diceResult, board);
                        break;
                    case '4':
                        currentPlayer.tokens[3].Move(diceResult, board);
                        break;
                }
                throwCounter++;
                if (diceResult == "6" || diceResult == "Globe")
                {
                    //throwCounter = 0;
                }
                writeCurrentPosition(currentPlayer);
            }
            while (tokensInPlay < 1 && throwCounter < 3 && diceResult != "Globe" && diceResult != "6" || tokensInPlay <= 1 && throwCounter < 1);
            TurnCounter++;
            Console.ForegroundColor = ConsoleColor.White;
        }
        private void End()
        {

        }

        private void SetColour(Player currentPlayer)
        {
            switch (currentPlayer.color)
            {
                case Color.Red:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case Color.Yellow:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                case Color.Blue:
                    Console.ForegroundColor = ConsoleColor.Blue;
                    break;
                case Color.Green:
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
            }
        }
        private void writeCurrentPosition(Player currentPlayer)
        {
            Console.WriteLine("your tokens:");
            foreach(Token tk in currentPlayer.tokens)
            {
                Console.WriteLine(string.Format("   token: {0} with the position: {1} and state: {2} \n", tk.Id + 1, tk.Position, tk.state));
            }
        }
        /*private int TokensInPlay(Player currentPlayer)
        {
            int tokensInPlay = 0;
            foreach (Token tk in currentPlayer.tokens)
            {
                if (tk.state == TokenState.InPlay)
                {
                    tokensInPlay++;
                }
            }
            return (tokensInPlay);
        }*/
    }
}
