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

        public BattleState State;

        public BattleField(Unit player, Unit enemy, Dice dice)
        {
            Player = player;
            Enemy = enemy;
            State = BattleState.BeforeBattle;
            RollResult = -1;
            Dice = dice;
        }

        public BattleField Initialize()
        {
            return new BattleField(Player.Initialize(), Enemy.Initialize(), Dice);
        }


    }
}
