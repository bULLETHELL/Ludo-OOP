using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ludo
{
    public enum SquareType { Normal, Star, Globe, Finish, FinishRoad};
    public enum SquareState { Safe, Occupied, Empty}

    public class Square
    {
        public int SqId;
        public SquareType SqType;
        public Color SqClr;
        public SquareState SqState;
        public List<Token> occupiedBy;

        public Square(SquareType Type, int id, Color clr, SquareState State)   
        {
            this.SqState = State;
            this.SqType = Type;
            this.SqId = id;
            this.SqClr = clr;
            this.occupiedBy = new List<Token>();
        }
        public string Info()
        {
            return (String.Format("Square colour: {0}\nSquare ID:     {1}\nSquare Type:   {2} \n \n", this.SqClr, this.SqId, this.SqType));

        }


        //TODO: Get this to work
        public void DetermineIfTokenShouldBeSendHome(Token token)
        {
            if (this.SqState == SquareState.Safe)
            {
                token.SendHome(token);
            }
        }


        public SquareState FindOutWhatStateCurrentSquareShouldBe(Token curToken)
        {
            bool allTokensEqualColor = this.occupiedBy.All(token => token.color.Equals(curToken.color));

            if (this.occupiedBy.Count > 1 && allTokensEqualColor || this.SqType == SquareType.Globe)
            {
                return SquareState.Safe;
            }
            else if (this.occupiedBy.Count == 0)
            {
                return SquareState.Empty;
            }
            else if (this.occupiedBy.Count == 1)
            {
                return SquareState.Occupied;
            }
            return SquareState.Empty;
        }
    }
}
