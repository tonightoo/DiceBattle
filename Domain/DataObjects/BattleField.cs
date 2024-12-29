using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DataObjects
{
    public class BattleField
    {

        public Unit Player;

        public Unit Enemy;

        public BattleField(Unit player, Unit enemy) {
            Player = player;
            Enemy = enemy;
        }


    }
}
