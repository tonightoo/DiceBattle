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

namespace Application.UseCases.Battle
{
    public class BattleUseCase : IBattleUseCase
    {

        private BattleField _field;

        private IBattlePresenter _presenter;

        public BattleUseCase(IBattlePresenter presenter, BattleField field)
        {
            _presenter = presenter;
            _field = field;
        }


        public void NextTurn()
        {
            if (_field.IsPlayerTurn)
            {
                CalcDamage(_field.Player, _field.Enemy);
                _field.IsPlayerTurn = false;
            }
            else
            {
                CalcDamage(_field.Enemy, _field.Player);
                _field.IsPlayerTurn = true;
            }
        }

        public void ScreenUpdate()
        {
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
