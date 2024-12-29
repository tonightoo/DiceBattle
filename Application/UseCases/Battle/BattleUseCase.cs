using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Domain.DataObjects;
using Application.IPresenters;

namespace Application.UseCases.Battle
{
    public class BattleUseCase : IBattleUseCase
    {

        private BattleField _field;

        private bool _isPlayerTurn;

        private Random _dice;

        private IBattlePresenter _presenter;

        public BattleUseCase(IBattlePresenter presenter)
        {
            _presenter = presenter;
            Initialize();
        }


        public void NextTurn()
        {
            if (_isPlayerTurn)
            {
                CalcDamage(_field.Player, _field.Enemy);
                _isPlayerTurn = false;
            }
            else
            {
                CalcDamage(_field.Enemy, _field.Player);
                _isPlayerTurn = true;
            }
        }

        public void Initialize()
        {
            int[] playerAttack = { 1, 2, 3, 4, 5, 6 };
            int[] enemyAttack = { 1, 1, 1, 1, 1, 10 };
            Unit player = new Unit("Player", playerAttack, 20);
            Unit enemy = new Unit("Enemy", enemyAttack, 20);
            _dice = new Random();
            _field = new BattleField(player, enemy);
        }

        public void ScreenUpdate()
        {
            _presenter.UpdateScreen(_field);
        }

        private void CalcDamage(Unit attacker, Unit defender)
        {
            int rollResult = _dice.Next(attacker.Attacks.Length - 1);
            int damage = attacker.Attacks[rollResult];
            defender.Hp -= damage;
        }


    }
}
