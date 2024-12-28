using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Unit
    {

        public readonly int MaxHp;

        public int Hp;

        public readonly string Name;

        public readonly int[] Attacks;

        public Unit(string name, int[] attacks, int maxHp)
        {
            Name = name;
            Attacks = attacks;
            MaxHp = maxHp;
            Hp = maxHp;
        }
    }
}
