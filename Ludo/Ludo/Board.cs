﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ludo
{


    public class Board
    {
        public int[] GlobeSquares = new int[] { 1, 9, 14, 22, 27, 35, 40, 48 };
        public int[] StarSquares = new int[] { 6, 12, 19, 25, 32, 38, 45, 51 };
        public int[] StartSquares = new int[] { 1, 14, 27, 40 };
        public int[] FinishSquares = new int[] { 51, 17, 28, 38 };



        public List<Square> BoardList = new List<Square>();
        private List<Square> BoardListRed = new List<Square>();
        private List<Square> BoardListGreen = new List<Square>();
        private List<Square> BoardListBlue = new List<Square>();
        private List<Square> BoardListYellow = new List<Square>();


        private string finalString;

        public Board()
        {
            Draw();            
        }
        private void Draw()
        {
            int j = 0;
            for (int i = 1; i <= 52; i++)
            {
                if (GlobeSquares.Contains(i) && StartSquares.Contains(i))
                {
                    BoardList.Add(new Square(SquareType.Globe, i, (Color)j, SquareState.empty, false));
                    j++;
                }
                else if (GlobeSquares.Contains(i) && FinishSquares.Contains(i))
                {
                    BoardList.Add(new Square(SquareType.Globe, i, (Color)j, SquareState.empty, true));
                }

                else if (GlobeSquares.Contains(i) && !StartSquares.Contains(i))
                {
                    BoardList.Add(new Square(SquareType.Globe, i, Color.White, SquareState.empty, false));
                }

                else if (StarSquares.Contains(i) && !StartSquares.Contains(i))
                {
                    BoardList.Add(new Square(SquareType.Star, i, Color.White, SquareState.empty, false));
                }

                else
                {
                    BoardList.Add(new Square(SquareType.Normal, i, Color.White, SquareState.empty, false));
                }
                
            }
            for (int i = 1; i <= 20; i++)
            {
                if (i <= 1)
                {
                    BoardListYellow.Add(new Square(SquareType.FinishRoad, (i+52), Color.Yellow, SquareState.empty, false));
                }
                else if (i <= 10)
                {
                    BoardListRed.Add(new Square(SquareType.FinishRoad, (i + 52), Color.Red, SquareState.empty, false));
                }
                else if (i <= 15)
                {
                    BoardListGreen.Add(new Square(SquareType.FinishRoad, (i + 52), Color.Green, SquareState.empty, false));
                }
                else if (i <= 20)
                {
                    BoardListBlue.Add(new Square(SquareType.FinishRoad, (i + 52), Color.Blue, SquareState.empty, false));
                }
            }
            BoardList.Add(new Square(SquareType.Finish, 73, Color.White, SquareState.empty, false));
        }
        public string Info()
        {
            foreach(Square square in BoardList)
            {
                finalString += square.Info();
            }
            foreach(Square YellowSquare in BoardListYellow)
            {
                finalString += YellowSquare.Info();
            }

            foreach(Square RedSquare in BoardListRed)
            {
                finalString += RedSquare.Info();
            }
            foreach(Square GreenSquare in BoardListGreen)
            {
                finalString += GreenSquare.Info();
            }
            foreach(Square BlueSquare in BoardListBlue)
            {
                finalString += BlueSquare.Info();
            }
            return finalString;
        }
    }
}
