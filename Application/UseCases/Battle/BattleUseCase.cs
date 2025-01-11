using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Domain.DataObjects;
using Application.IPresenters;
using Application.Repositories;
using System.ComponentModel.Design;

namespace Application.UseCases.Battle
{
    public class BattleUseCase : IBattleUseCase
    {

        private BattleField _field;

        private IBattlePresenter _presenter;

        private int _frameCounter;

        public BattleUseCase(IBattlePresenter presenter, BattleField field)
        {
            _presenter = presenter;
            _field = field;
            _frameCounter = 0;
        }


        public void NextTurn()
        {
            switch (_field.State)
            {
                case BattleState.BeforeBattle:
                    _field.State = BattleState.PlayerDiceRoll;
                    break;
                case BattleState.PlayerDiceRoll:
                    CalcDamage(_field.Player, _field.Enemy);
                    _field.State = BattleState.PlayerRollResult;
                    break;
                case BattleState.PlayerRollResult:
                    _field.State = BattleState.EnemyDiceRoll;
                    break;
                case BattleState.EnemyDiceRoll:
                    CalcDamage(_field.Enemy, _field.Player);
                    _field.State = BattleState.EnemyRollResult;
                    break;
                case BattleState.EnemyRollResult:
                    _field.State = BattleState.PlayerDiceRoll;
                    break;
            }
        }

        public void ScreenUpdate()
        {
            _frameCounter++;
            if (_frameCounter > 10)
            {
                switch (_field.State)
                {
                    case BattleState.PlayerDiceRoll:
                        _field.RollResult = (_field.RollResult + _field.Dice.Size + 1) % _field.Dice.Size;
                        break;
                    case BattleState.EnemyDiceRoll:
                        _field.RollResult = (_field.RollResult + _field.Dice.Size + 1) % _field.Dice.Size;
                        break;
                    default:
                        break;
                }
                _frameCounter = 0;
            }

            _presenter.UpdateScreen(_field);
        }

        private void CalcDamage(Unit attacker, Unit defender)
        {
            int rollResult = _field.Dice.Roll();
            _field.RollResult = rollResult;
            int damage = attacker.Attacks[rollResult];
            defender.Hp -= damage;
        }


    }
}
