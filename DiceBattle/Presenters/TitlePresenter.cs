using Domain.DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiceBattle.Views;
using static DxLibDLL.DX;
using Application.IPresenters;

namespace DiceBattle.Presenters
{
    internal class TitlePresenter : ITitlePresenter
    {
        private ViewUpdater _updater;

        public TitlePresenter(ViewUpdater updater)
        {
            _updater = updater;
        }


        public void UpdateScreen(TitleMenu menu)
        {
            ViewModel viewModel = new ViewModel();
            int count = 1;

            foreach (string menuText in menu.GetMenu())
            {
                if (count == menu.CurrentIndex + 1)
                {
                    viewModel.texts.Add(new Text("▶", 50, 100 * count, GetColor(255, 255, 255)));
                }

                viewModel.texts.Add(new Text(menuText, 100, 100 * count, GetColor(255, 255, 255)));

                count += 1;
            }

            _updater.CreateViewModel = viewModel;
        }


    }
}
