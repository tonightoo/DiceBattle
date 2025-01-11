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

        public Dice Dice;

        public int RollResult;

        public bool IsPlayerTurn;

        public BattleField(Unit player, Unit enemy, Dice dice)
        {
            Player = player;
            Enemy = enemy;
            IsPlayerTurn = true;
            RollResult = -1;
            Dice = dice;
        }


    }
}
