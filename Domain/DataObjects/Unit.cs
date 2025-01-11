using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DataObjects
{
    public class Unit
    {

        public readonly int MaxHp;

        private int _hp;

        public readonly string FilePath;

        public int GraphId;

        public int GraphicHandle;

        public int Hp
        {
            get => _hp;
            set
            {
                if (value > MaxHp)
                {
                    _hp = MaxHp;
                }
                else if (value < 0)
                {
                    _hp = 0;
                }
                else
                {
                    _hp = value;
                }
            }
        }

        public readonly string Name;

        public readonly int[] Attacks;

        public Unit(string name, int[] attacks, int maxHp, int graphId, string filePath = "")
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException();
            }

            if (maxHp < 0)
            {
                throw new ArgumentException();
            }

            if (attacks.Length <= 0)
            {
                throw new ArgumentException();
            }
            Name = name;
            Attacks = attacks;
            MaxHp = maxHp;
            Hp = maxHp;
            GraphId = graphId;
            FilePath = filePath;
        }
    }
}
