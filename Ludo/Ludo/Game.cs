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
            Player currentPlayer = players[TurnCounter % players.Count];
            bool extraThrow = false;
            SetColour(currentPlayer);
            Console.WriteLine(string.Format("Current player is the {0} player", currentPlayer.color));
            writeCurrentPosition(currentPlayer);

            /*&& diceResult != "Globe" && diceResult != "6" &&*/
            /*&& diceResult != "Globe" && diceResult != "6" &&*/
            if (TokensInPlay(currentPlayer) < 1)
            {
                while (TokensInPlay(currentPlayer) < 1 && throwCounter < 3) //|| diceResult != "Globe" && diceResult != "6" && throwCounter < 1)
                {
                    Console.WriteLine("Press any button to throw the dice");
                    Console.ReadKey(true);
                    diceResult = dice.Roll();
                    Console.WriteLine(string.Format("you rolled a '{0}' ", diceResult));
                    if (diceResult == "Globe" || diceResult == "6")
                    {
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
                    }
                    else
                    {
                        Console.WriteLine("no possible moves, throw again");
                    }
                    
                    throwCounter++;
                    if(diceResult == "Globe" || diceResult == "6")
                    {
                        writeCurrentPosition(currentPlayer);
                    }                   
                }
            }
            else if (TokensInPlay(currentPlayer) >=1)
            {
                while(throwCounter < 1)
                {
                    Console.WriteLine("Press any button to throw the dice");
                    Console.ReadKey(true);
                    diceResult = dice.Roll();
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
                    if(diceResult == "Globe" || diceResult == "6")
                    {
                        extraThrow = true;
                    }
                    switch (extraThrow)
                    {
                        case true:
                            throwCounter = 0;
                            break;
                        case false:
                            throwCounter++;
                            break;
                    }
                    writeCurrentPosition(currentPlayer);
                }
            }

            TurnCounter++;
            Console.WriteLine("press a key to end your turn");
            Console.ReadKey(true);
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
                Square square = board.BoardList[tk.Position];
                Console.WriteLine(string.Format("   token: {0} with the position: {1} and state: {2} \n", tk.Id + 1, tk.Position, tk.state));
                /*Console.WriteLine(string.Format(@"   token {0}'s square has the following properties, Id {1}, colour {2}, type {3} state{4}\n", tk.Id+1, 
                    square.SqId, 
                    square.SqClr,
                    square.SqType,
                    square.SqState));*/
                IEnumerable<Square> query = board.BoardList.Where(Square => Square.SqId == tk.Position);
                foreach(Square value in query)
                {
                    Console.WriteLine(string.Format("   id:{0}, Colour:{1}, State:{2}, Type:{3}",value.SqId, value.SqClr, value.SqState, value.SqType));
                }
            }
        }
        private int TokensInPlay(Player currentPlayer)
        {
            IEnumerable<Token> query = currentPlayer.tokens.Where(Token => Token.state == TokenState.InPlay);
            return (query.Count());
        }

        private void CheckIfAtFinishRoad(Player cp, string dr)
        {
            int squaresFromFinishRoad;
            int SquaresIntoFinishRoad;

            IEnumerable<Token> query = cp.tokens.Where(Token => Token.state == TokenState.InPlay);
            foreach (Token tk in query)
            {
                Console.WriteLine("dick 0");
                IEnumerable<Square> FinishSquare = board.BoardList.Where(Square =>  Square. == true &&  board.BoardList[tk.Position].SqClr == tk.color);
                foreach (Square value in FinishSquare)
                {
                    squaresFromFinishRoad = (tk.Position - value.SqId);
                    Console.WriteLine(squaresFromFinishRoad + "dick 1" + FinishSquare.Count() + "dick ");
                }
                //squaresFromFinishRoad += (FinishSquare
            }
        }
    }
}
