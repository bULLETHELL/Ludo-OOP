using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ludo
{
    interface IPlayer
    {
        string name
        {
            get;
            set;
        }

        Color color
        {
            get;
            set;
        }

        Token[] tokens
        {
            get;
            set;
        }

        bool winner
        {
            get;
            set;
        }
    }
}
