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

        public BattlePresenter(ViewUpdater updater)
        {
            _updater= updater;
        }


        public void UpdateScreen(BattleField field)
        {
            ViewModel viewModel = new ViewModel();

            if (field.Player.Hp <= 0)
            {
                viewModel.texts.Add(new Text("enemy win", 300, 400, GetColor(255, 255, 255)));
            }
            else if (field.Enemy.Hp <= 0)
            {
                viewModel.texts.Add(new Text("player win", 300, 400, GetColor(255, 255, 255)));
            }
            else
            {
                viewModel.texts.Add(new Text($"{field.Player.Name}:{field.Player.Hp}", 400, 400, GetColor(255, 255, 255)));
                viewModel.texts.Add(new Text($"{field.Enemy.Name}:{field.Enemy.Hp}", 100, 400, GetColor(255, 255, 255)));
            }

            _updater.CreateViewModel = viewModel;
        }

    }
}
