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

        public void AddTokenToSquare(Token tokenToAdd)
        {
            if (!this.occupiedBy.Contains(tokenToAdd))
            {
                this.occupiedBy.Add(tokenToAdd);
            }
        }

        public void RemoveTokenFromSquare(Token tokenToRemove)
        {
            if (this.occupiedBy.Contains(tokenToRemove))
            {
                this.occupiedBy.Remove(tokenToRemove);
            }
        }

        //TODO: Get this to work
        public void DetermineifTokenShouldBeSendHomeTokenOnSquare(Token tokenToSendHome)
        {
            bool allTokensOnSquareEqualColor = this.occupiedBy.All(token => token.color.Equals(tokenToSendHome.color));

            if (this.SqState == SquareState.Safe && !allTokensOnSquareEqualColor)
            {
                tokenToSendHome.SendHome(tokenToSendHome);
                RemoveTokenFromSquare(tokenToSendHome);
                //  Debug cw
                Console.WriteLine(String.Format("You send home token {0} of color {1} on Square {2}", tokenToSendHome.Id, tokenToSendHome.color, this.SqId));

            }
            else if (this.SqState == SquareState.Occupied && !allTokensOnSquareEqualColor)
            {
                Console.WriteLine(String.Format("You send home token {0} of color {1} on Square {2}", this.occupiedBy[0].Id, this.occupiedBy[0].color, this.SqId));
                tokenToSendHome.SendHome(this.occupiedBy[0]);
                RemoveTokenFromSquare(this.occupiedBy[0]);
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
