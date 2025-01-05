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

                int x;
                int y = Constants.Title.FIRST_MENU_Y + Constants.Title.MENU_MARGIN * count;
                if (count == menu.CurrentIndex + 1)
                {
                    x = Constants.Title.MENU_ARROW_X;
                    viewModel.texts.Add(new Text(Constants.Title.ARROW, x, y, Constants.Color.WHITE));
                }

                x = Constants.Title.MENU_X;
                viewModel.texts.Add(new Text(menuText, x, y, Constants.Color.WHITE));

                count += 1;
            }

            _updater.CreateViewModel = viewModel;
        }


    }
}
