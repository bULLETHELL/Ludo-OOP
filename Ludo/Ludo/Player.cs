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
        private string pName;
        private List<Token> pTokens;
        private bool pIsWinner;

        public Player(Color clr, List<Token> tokens)
        {
            this.pColor = clr;
            this.pTokens = tokens;
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
