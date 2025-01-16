using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.IPresenters;
using Application.Repositories;
using DiceBattle.Views;
using Domain.DataObjects;
using static DxLibDLL.DX;

namespace DiceBattle.Presenters
{
    internal class BattlePresenter : IBattlePresenter
    {

        private ViewUpdater _updater;

        private ViewModel _viewModel;

        private IImageRepository _imageRepository;

        public BattlePresenter(ViewUpdater updater, IImageRepository imageRepository)
        {
            _updater = updater;
            _imageRepository = imageRepository;
        }


        public void UpdateScreen(BattleField field)
        {
            _viewModel = new ViewModel();

            if (field.RollResult >= 0)
            {
                int[] handles = _imageRepository.Get(Constants.DICE_GRAPH_ID).GraphicHandles;
                int handle = handles[field.RollResult];
                Graph graph = new Graph(handle, Constants.Battle.ROLL_RESULT_X, Constants.Battle.ROLL_RESULT_Y, Constants.Battle.DICE_WIDTH, Constants.Battle.DICE_HEIGHT);
                _viewModel.graphs.Add(graph);
            }

            switch (field.State)
            {
                case BattleState.PlayerRollResult:
                    WriteStatus(field.Player, Constants.Battle.PLAYER_X, field.RollResult);
                    WriteStatus(field.Enemy, Constants.Battle.ENEMY_X, -1, true);
                    break;
                case BattleState.EnemyRollResult:
                    WriteStatus(field.Player, Constants.Battle.PLAYER_X, -1);
                    WriteStatus(field.Enemy, Constants.Battle.ENEMY_X, field.RollResult, true);
                    break;
                default:
                    WriteStatus(field.Player, Constants.Battle.PLAYER_X, -1);
                    WriteStatus(field.Enemy, Constants.Battle.ENEMY_X, -1, true);
                    break;
            }

            DrawUnitImage(field.Player, new Point(200, 400));
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

        private void WriteStatus(Unit unit, int x, int useAttackNo, bool isRight = false)
        {
            int y;
            _viewModel.texts.Add(new Text($"{unit.Name}", x, Constants.Battle.NAME_TEXT_Y, Constants.Color.WHITE));
            _viewModel.texts.Add(new Text($"HP : {unit.Hp}", x, Constants.Battle.HP_TEXT_Y, Constants.Color.WHITE));

            int hpX = x;
            int hpY = Constants.Battle.HP_BAR_Y;
            if (isRight)
            {
                hpX = x - 3 * Constants.Battle.HP_BAR_WIDTH / 4;
            }
            _viewModel.boxes.Add(new Box(hpX, hpY, hpX + Constants.Battle.HP_BAR_WIDTH, hpY + Constants.Battle.HP_BAR_HEIGHT, Constants.Color.WHITE, FALSE));
            float percentage = (float)unit.Hp / (float)unit.MaxHp;
            _viewModel.boxes.Add(new Box(hpX, hpY, hpX + (int)(Constants.Battle.HP_BAR_WIDTH * percentage), hpY + Constants.Battle.HP_BAR_HEIGHT, Constants.Color.WHITE, TRUE));

            for (int i = 0; i < unit.Attacks.Count(); i++)
            {
                uint color;
                if (i == useAttackNo)
                {
                    color = Constants.Color.RED;
                }
                else
                {
                    color = Constants.Color.WHITE;
                }


                y = Constants.Battle.FIRST_ATTACK_TEXT_Y + Constants.Battle.ATTACK_TEXT_MARGIN * i;
                _viewModel.texts.Add(new Text($"{i + 1} : {unit.Attacks[i]}", x, y, color));
            }
        }

        private void DrawUnitImage(Unit unit, Point position)
        {
            int handle = _imageRepository.Get(unit.GraphId).GraphicHandles[0];
            Graph unitGraph = new Graph(handle, position.X, position.Y, 128, 128);
            _viewModel.graphs.Add(unitGraph);
        }

    }
}
