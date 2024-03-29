﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ludo
{
    interface IPlayer
    {
        Color color
        {
            get;
            set;
        }

        List<Token> tokens
        {
            get;
            set;
        }

        bool isWinner
        {
            get;
            set;
        }
    }
}
