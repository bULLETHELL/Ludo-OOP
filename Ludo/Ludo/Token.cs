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
        Green
    };

    public class Token : ITokenPosition
    {
        private int _x;
        private int _y;
        public Color _color;

        public Token(int x, int y, Color color)
        {
            _x = x;
            _y = y;
            _color = color;
        }

        public int x
        {
            get
            {
                return _x;
            }

            set
            {
                _x = value;
            }
        }

        public int y
        {
            get
            {
                return _y;
            }

            set
            {
                _y = value;
            }
        }
    }
}
