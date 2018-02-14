using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ludo
{


    class Board
    {
        private List<Square> BoardList = new List<Square>();
        private string finalString;
        public Board()
        {
            int[] GlobeSquares = new int[] {1, 9, 14, 22, 27, 35, 40, 48};
            int[] StarSquares = new int[] {6, 12, 19, 25, 32, 38, 45, 51 };
            
            for (int i = 1; i <= 52; i++)
            {
                if (GlobeSquares.Contains(i))
                {
                    BoardList.Add(new Square(SquareType.Globe, i, Color.White));
                }
                else if (StarSquares.Contains(i))
                {
                    BoardList.Add(new Square(SquareType.Star, i, Color.White));
                }
                else
                {
                    BoardList.Add(new Square(SquareType.Normal, i, Color.White));
                }
            }
        }
        public string Info()
        {
            foreach(Square square in BoardList)
            {
                finalString += square.Info();
            }
            return finalString;
        }
    }
}
