using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DataObjects
{
    public enum BattleState
    {
        BeforeBattle,
        PlayerDiceRoll,
        PlayerRollResult,
        EnemyDiceRoll,
        EnemyRollResult,
    }
}
