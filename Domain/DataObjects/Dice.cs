using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DataObjects
{
    public class Dice
    {

        public readonly int Size;

        public Random Random = new Random();

        public Dice(int size) 
        {
            Size = size;
        }

        public int Roll()
        {
            return Random.Next(Size);
        }

    }
}
