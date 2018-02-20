using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ludo
{
    public enum Color //    Enumeration for the Color of the Token
    {
        Red,
        Yellow,
        Blue,
        Green,
        White,
    };

    public enum TokenState //    Enumeration for the State of the Token
    {
        Home,
        Finished,
        InPlay
    };

    public class Token : IMove, IPosition //    Class is public and inherits from the interfaces IMove, IPosition
    {
        private int _id; //  private string _id
        private int _position; //   private integer _position
        public Color color; //  public Color color
        public TokenState state;


        public Token(int id, int pos, Color clr, TokenState tState) //  Constructor
        {
            this._id = id;
            this._position = pos;
            this.color = clr;
            this.state = tState;
        }


        public int position //  Getter and setter for position from IPosition
        {
            get
            {
                return this._position;
            }

            set
            {
                this._position = value;
            }
        }

        public int id
        {
            get
            {
                return this._id;
            }
        }

        public void Move(string squares)   // Function Move from IMove
        {
            switch (this.state)
            {
                case TokenState.Home:
                    if (squares == "Globe" || squares == "6")
                    {
                        this.state = TokenState.InPlay;
                    }
                    break;
                case TokenState.InPlay:
                    if (squares == "Globe")
                    {
                        Board board = Program.game.board;
                        List <Square> gameboardList = board.BoardList;
                        for (int i = 0; i < gameboardList.Count; i++)
                        {
                            int tempIndex = ((i + position + 1) % gameboardList.Count);
                            Square tempSquare = gameboardList[tempIndex];

                            if (tempSquare.SqType == SquareType.Globe)
                            {
                                gameboardList[tempIndex].SqState = SquareState.safe;
                                position = tempIndex;
                                break;
                            }
                        }
                    }
                    else if (squares == "Star")
                    {

                    }
                    else
                    {
                        position += int.Parse(squares);
                    }
                    break;
                case TokenState.Finished:
                    break;
                     
            }
        }
    }
}
