using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DiceBattle.Views
{
    internal class Box
    {

        public int X1;

        public int Y1;

        public int X2;

        public int Y2;

        public uint Color;

        public int FillFlag;

        public Box(int x1, int y1, int x2, int y2, uint color, int fillFlag) 
        {
            this.X1 = x1;
            this.Y1 = y1;
            this.X2= x2; 
            this.Y2 = y2;
            this.Color = color;
            FillFlag = fillFlag;
        }

    }
}
