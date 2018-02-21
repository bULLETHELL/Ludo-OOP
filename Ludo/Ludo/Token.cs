using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ludo
{
    public enum Color //    Enumeration for the Color of the Token
    {
        Yellow,
        Red,
        Green,
        Blue,
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

        public void Move(string squares, Board board)   // Function Move from IMove
        {
            List<Square> gameboardList = board.BoardList;

            switch (this.state)
            {
                case TokenState.Home:
                    if (squares == "Globe" || squares == "6")
                    {
                        for (int i = 0; i < gameboardList.Count; i++)
                        {
                            Square tempSquare = gameboardList[i];
                            if (tempSquare.SqType == SquareType.Globe && tempSquare.SqClr == this.color)
                            {
                                this.state = TokenState.InPlay;
                                gameboardList[i].SqState = SquareState.occupied;
                                this.position = tempSquare.SqId;
                                break;
                            }
                        }
                    }
                    break;
                case TokenState.InPlay:
                    if (squares == "Globe")
                    {
                        for (int i = 0; i < gameboardList.Count; i++)
                        {
                            int tempIndex = ((i + position + 1) % gameboardList.Count);
                            Square tempSquare = gameboardList[tempIndex + 1];

                            if (tempSquare.SqType == SquareType.Globe)
                            {
                                gameboardList[tempIndex].SqState = SquareState.safe;
                                this.position = tempIndex;
                                break;
                            }
                        }
                    }
                    else if (squares == "Star")
                    {
                        for (int i = 0; i < gameboardList.Count; i++)
                        {
                            int tempIndex = ((i + position + 1) % gameboardList.Count);
                            Square tempSquare = gameboardList[tempIndex + 1];

                            if (tempSquare.SqType == SquareType.Star)
                            {
                                gameboardList[tempIndex].SqState = SquareState.occupied;
                                this.position = tempIndex;
                                break;
                            }
                        }
                    }
                    else
                    {
                        int nextPos = this.position + int.Parse(squares);
                        Square tempSquare = gameboardList[nextPos + 1];
                        Square nextSquare;
                        if (tempSquare.SqType == SquareType.Star)
                        {
                            for (int i = 0; i < gameboardList.Count; i++)
                            {
                                nextSquare = gameboardList[i];
                                if (nextSquare.SqType == SquareType.Star)
                                {
                                    this.position = nextSquare.SqId;
                                    nextSquare.SqState = SquareState.occupied;
                                    nextSquare.
                                    break;
                                }
                            }
                        }
                        else if (tempSquare.SqType == SquareType.Globe)
                        {
                            for (int i = 0; i < gameboardList.Count; i++)
                            {
                                nextSquare = gameboardList[i];
                                if (nextSquare.SqType == SquareType.Globe && nextSquare.SqState == SquareState.empty)
                                {
                                    this.position = nextSquare.SqId;
                                    nextSquare.SqState = SquareState.occupied;
                                    break;
                                }
                            }
                        }
                        else
                        {
                            this.position += int.Parse(squares);
                        }
                    }
                    break;
                case TokenState.Finished:
                    break;
                     
            }
        }
    }
}
