using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.IPresenters;
using DiceBattle.Views;
using Domain.DataObjects;
using static DxLibDLL.DX;

namespace DiceBattle.Presenters
{
    internal class BattlePresenter : IBattlePresenter
    {

        private ViewUpdater _updater;

        private ViewModel _viewModel;

        public BattlePresenter(ViewUpdater updater)
        {
            _updater = updater;
        }


        public void UpdateScreen(BattleField field)
        {
            _viewModel = new ViewModel();


            //Player
            WriteStatus(field.Player, Constants.Battle.PLAYER_X);
            DrawUnitImage(field.Player, new Point(200, 400));

            //Enemy
            WriteStatus(field.Enemy, Constants.Battle.ENEMY_X);
            DrawUnitImage(field.Enemy, new Point(480, 400));

            //Winner
            WriteWinner(field);

            //
            //_viewModel.texts.Add(new Text($"{field.Player.Name}:{field.Player.Hp}", 400, 400, GetColor(255, 255, 255)));
            //_viewModel.texts.Add(new Text($"{field.Enemy.Name}:{field.Enemy.Hp}", 100, 400, GetColor(255, 255, 255)));

            _updater.CreateViewModel = _viewModel;
        }

        private void WriteWinner(BattleField field)
        {
            if (field.Player.Hp <= 0)
            {
                _viewModel.texts.Add(new Text($"{field.Enemy.Name} win", Constants.Battle.WIN_POSITION.X, Constants.Battle.WIN_POSITION.Y, Constants.Color.WHITE));
            }
            else if (field.Enemy.Hp <= 0)
            {
                _viewModel.texts.Add(new Text($"{field.Player.Name} win", Constants.Battle.WIN_POSITION.X, Constants.Battle.WIN_POSITION.Y, Constants.Color.WHITE));
            }
        }

        private void WriteStatus(Unit unit, int x) 
        {
            int y;
            _viewModel.texts.Add(new Text($"{unit.Name}", x, Constants.Battle.NAME_TEXT_Y, Constants.Color.WHITE));
            _viewModel.texts.Add(new Text($"HP : {unit.Hp}", x, Constants.Battle.HP_TEXT_Y, Constants.Color.WHITE));

            y = Constants.Battle.HP_BAR_Y;
            _viewModel.boxes.Add(new Box(x, y, x + Constants.Battle.HP_BAR_WIDTH, y + Constants.Battle.HP_BAR_HEIGHT, Constants.Color.WHITE, FALSE));
            float percentage = (float)unit.Hp / (float)unit.MaxHp;
            _viewModel.boxes.Add(new Box(x, y, x + (int)(Constants.Battle.HP_BAR_WIDTH * percentage), y + Constants.Battle.HP_BAR_HEIGHT, Constants.Color.WHITE, TRUE));

            for (int i = 0; i < unit.Attacks.Count(); i++)
            {
                y = Constants.Battle.FIRST_ATTACK_TEXT_Y + Constants.Battle.ATTACK_TEXT_MARGIN * i;
                _viewModel.texts.Add(new Text($"{i + 1} : {unit.Attacks[i]}", x, y, Constants.Color.WHITE));
            }
        }

        private void DrawUnitImage(Unit unit, Point position)
        {
            Graph unitGraph = new Graph(unit.GraphicHandle, position.X, position.Y, 128, 128);
            _viewModel.graphs.Add(unitGraph);
        }

    }
}
