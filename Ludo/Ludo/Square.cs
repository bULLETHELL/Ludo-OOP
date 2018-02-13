﻿using System;
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
    }
}
