using Domain.DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiceBattle.Views;
using static DxLibDLL.DX;
using Application.IPresenters;
using Application.Repositories;

namespace DiceBattle.Presenters
{
    internal class TitlePresenter : ITitlePresenter
    {
        private ViewUpdater _updater;

        private IImageRepository _imageRepository;

        public TitlePresenter(ViewUpdater updater, IImageRepository repository)
        {
            _updater = updater;
            _imageRepository = repository;
        }


        public void UpdateScreen(TitleMenu menu)
        {
            ViewModel viewModel = new ViewModel();
            int count = 1;

            int handle = _imageRepository.Get(Constants.Title.TITLE_IMAGE_ID).GraphicHandles[0];
            viewModel.graphs.Add(new Graph(handle, 
                                           Constants.Title.TITLE_IMAGE_X, 
                                           Constants.Title.TITLE_IMAGE_Y, 
                                           Constants.Title.TITLE_IMAGE_WIDTH, 
                                           Constants.Title.TITLE_IMAGE_HEIGHT));

            foreach (string menuText in menu.GetMenu())
            {

                int x;
                int y = Constants.Title.FIRST_MENU_Y + Constants.Title.MENU_MARGIN * count;
                if (count == menu.CurrentIndex + 1)
                {
                    int fontSize = 18;
                    x = Constants.Title.MENU_ARROW_X;

                    if (menu.IsLargerArrow)
                    {
                        fontSize = 24;
                        x -= 3;
                        y -= 3;
                    }

                    viewModel.texts.Add(new Text(Constants.Title.ARROW, x, y, Constants.Color.WHITE, fontSize));
                    x = Constants.Title.MENU_X;
                    viewModel.texts.Add(new Text(menuText, x, y, Constants.Color.WHITE, fontSize));

                }
                else
                {
                    x = Constants.Title.MENU_X;
                    viewModel.texts.Add(new Text(menuText, x, y, Constants.Color.WHITE));
                }

                count += 1;
            }

            _updater.CreateViewModel = viewModel;
        }


    }
}
