using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ludo
{
    public enum SquareType { Normal, Star, Globe, Home, FinishRoad, safe};

    public class Square// : ITokenPosition
    {
        public int SqId;
        private int _x;
        private int _y;
        public SquareType SqType;
        public Color SqClr;

        public Square(SquareType Type, int id, Color clr)
        {
            this.SqType = Type;
            this.SqId = id;
            this.SqClr = clr;
        }
        public string Info()
        {
            return (String.Format("Square colour: {0}\nSquare ID:     {1}\nSquare Type:   {2} \n \n", this.SqClr, this.SqId, this.SqType));
        }
    }
}
