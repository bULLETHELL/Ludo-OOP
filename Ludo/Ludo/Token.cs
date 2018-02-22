using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ludo
{
    /// <summary>
    /// Enumeration with Colors for each Token and Player
    /// </summary>
    public enum Color
    {
        Yellow,
        Red,
        Green,
        Blue,
        White,
    };


    /// <summary>
    /// Enumeration for the State of the Token
    /// </summary>
    public enum TokenState
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

        /// <summary>
        /// Public Constructor for creation of a Token
        /// </summary>
        /// <param name="id">Id of the Token</param>
        /// <param name="pos">Position of the Token on the board. 0 = Not in Play</param>
        /// <param name="clr">Color of the Token</param>
        /// <param name="tState">State of the Token</param>
        public Token(int id, int pos, Color clr, TokenState tState) //  Constructor
        {
            this._id = id;
            this._position = pos;
            this.color = clr;
            this.state = tState;
        }

        public int Position //  Getter and setter for position from IPosition
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

        public int Id
        {
            get
            {
                return this._id;
            }
        }

        /// <summary>
        /// Function to Move Tokens all over the board.
        /// </summary>
        /// <param name="squares">Number of squares to move the Token</param>
        /// <param name="board">What board is being worked on</param>
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
                                this.Position = tempSquare.SqId;
                                break;
                            }
                        }
                    }
                    break;
                case TokenState.InPlay:
                    if (squares == "Globe")
                    {
                        this.Position = board.GetPosOfNextOfType(SquareType.Globe, this.Position + 1);
                    }
                    else if (squares == "Star")
                    {
                        this.Position = board.GetPosOfNextOfType(SquareType.Star, this.Position + 1);
                    }
                    else
                    {
                        int nextPos = (this.Position + int.Parse(squares)) % gameboardList.Count;
                        Square nextSquare = gameboardList[nextPos - 1];
                        if (nextSquare.SqType == SquareType.Star)
                        {
                            this.Position = nextPos;
                            if (this.Position == board.GetPosOfNextOfType(SquareType.Star, this.Position))
                            {
                                this.Position = board.GetPosOfNextOfType(SquareType.Star, this.Position + 1);
                            }
                        }
                        else if (nextSquare.SqType == SquareType.Globe)
                        {
                            this.Position = nextSquare.SqId;
                        }
                        else
                        {
                            int.TryParse(squares, out nextPos);
                            Position += nextPos;
                        }
                    }
                    break;
                case TokenState.Finished:
                    //TODO: Move the player to the 73rd spot on the board.
                    break;

            }

        }
    }
}
