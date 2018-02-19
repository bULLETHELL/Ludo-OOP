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

        public void Move(int squares)   // Function Move from IMove
        {
            switch (this.state)
            {
                case TokenState.Home:
                    this.state = TokenState.InPlay;
                    break;
                case TokenState.InPlay:
                    position += squares;
                    break;
                case TokenState.Finished:
                    break;
                     
            }
        }
    }
}
