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
    public class Token //: ITokenPosition
    {
        public string id;
        private int _x;
        private int _y;
        public Color color;


        public Token(int x, int y, Color clr)
        {
            this._x = x;
            this._y = y;
            this.color = clr;
        }

        public int x
        {
            get
            {
                return this._x;
            }

            set
            {
                this._x = value;
            }
        }

        public int y
        {
            get
            {
                return this._y;
            }

            set
            {
                this._y = value;
            }
        }
    }
}
