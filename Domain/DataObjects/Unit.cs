using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace Domain.DataObjects
{
    public class Unit
    {

        public int UnitId
        {
            get; set;
        }

        public int MaxHp
        {
            get; set;
        }

        private int _hp;

        public int GraphId
        {
            get; set;
        }

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

        public string Name
        {
            get; set;
        }


        public int[] AttackIds
        {
            get; set;
        }

        [JsonIgnore]
        public Skill[] Attacks
        {
            get; set;
        }

        public Unit Initialize()
        {

            int[] attackIds = new int[AttackIds.Length];

            for (int i = 0; i < attackIds.Length; i++)
            {
                attackIds[i] = AttackIds[i];
            }

            Skill[] attacks = new Skill[Attacks.Length];
            for (int i = 0; i < attacks.Length; i++)
            {
                attacks[i] = Attacks[i];
            }

            return new Unit(Name, attackIds,attacks, MaxHp, GraphId);
        }

        [method: JsonConstructor]
        public Unit(string name, int[] attackIds, int maxHp, int graphId)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException();
            }

            if (maxHp < 0)
            {
                throw new ArgumentException();
            }

            if (attackIds.Length <= 0)
            {
                throw new ArgumentException();
            }
            Name = name;
            AttackIds = attackIds;
            Attacks = new Skill[AttackIds.Length];
            MaxHp = maxHp;
            Hp = maxHp;
            GraphId = graphId;
        }

        public Unit(string name, int[] attackIds,Skill[] attacks, int maxHp, int graphId) : this(name, attackIds, maxHp, graphId)
        {
            Attacks = attacks;
        }


    }
}
