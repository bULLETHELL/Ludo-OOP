using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ludo
{
    public enum SquareType { Normal, Star, Globe, Finish, FinishRoad};
    public enum SquareState { safe, occupied, empty}

    public class Square
    {
        public int SqId;
        public SquareType SqType;
        public Color SqClr;
        public SquareState SqState;
        public List<Token> occupiedBy;
        bool FinishSquare;

        public Square(SquareType Type, int id, Color clr, SquareState State, bool FinishSquare)   
        {
            this.SqState = State;
            this.SqType = Type;
            this.SqId = id;
            this.SqClr = clr;
            this.FinishSquare = FinishSquare;
            this.occupiedBy = new List<Token>();
        }
        public string Info()
        {
            return (String.Format("Square colour: {0}\nSquare ID:     {1}\nSquare Type:   {2} \n \n", this.SqClr, this.SqId, this.SqType));

        }
    }
}
