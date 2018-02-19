using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ludo
{
    class Player : IPlayer
    {
        private Color pColor;
        private List<Token> pTokens = new List<Token>();
        private bool pIsWinner;

        public Player(Color clr)
        {
            this.pColor = clr;
            for (int i = 0; i < 4; i++)
            {
                this.pTokens.Add(new Token(i, 0, this.pColor, TokenState.Home));
            }
            this.pIsWinner = false;
        }

        public Color color
        {
            get { return this.pColor; }
            set { this.pColor = value; }
        }

        public List<Token> tokens
        {
            get { return this.pTokens; }
            set { this.pTokens = value; }
        }

        public bool isWinner
        {
            get { return this.pIsWinner; }
            set { this.pIsWinner = value; }
        }
    }
}
