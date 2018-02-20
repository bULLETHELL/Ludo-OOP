﻿using System;
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
        public Board board;

        public Game()
        {
            board = new Board();
            dice = new Dice(6);

            Console.WriteLine("Welcome to LudoTM by Morten and Andreas");
            players1 = MakePlayers(AmountOfPlayers());
            Turn();          
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
            string diceResult = "";
            Player currentPlayer = players1[TurnCounter % players1.Count];

            SetColour(currentPlayer);
            Console.WriteLine(string.Format("Current player is the {0} player", currentPlayer.color));
            writeCurrentPosition(currentPlayer);
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
                    currentPlayer.tokens[0].Move(diceResult);
                    break;
                case '2':
                    currentPlayer.tokens[1].Move(diceResult);
                    break;
                case '3':
                    currentPlayer.tokens[2].Move(diceResult);
                    break;
                case '4':
                    currentPlayer.tokens[3].Move(diceResult,);
                    break;
            }
            writeCurrentPosition(currentPlayer);
            Console.WriteLine(currentPlayer.tokens[0].position);
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
            for (int i = 0; i < currentPlayer.tokens.Count; i++)
            {
                Console.WriteLine(string.Format("   token: {0} with the position: {1} and state: {2} \n", currentPlayer.tokens[i].id + 1, currentPlayer.tokens[i].position, currentPlayer.tokens[i].state));
            }
        }
    }
}
