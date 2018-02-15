using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ludo
{
    public enum Color
    {
        Red,
        Yellow,
        Blue,
        Green,
        White
    };

    public enum State
    {
        Home,
        Finished,
        InPlay
    };

    public class Token : IMove, IPosition
    {
        private string _id;
        private int _position;
        public Color color;


        public Token(string id, int pos, Color clr)
        {
            this._id = id;
            this._position = pos;
            this.color = clr;
        }

        public int position
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

        public void Move(int squares)
        {
            position += squares;
        }
    }
}
