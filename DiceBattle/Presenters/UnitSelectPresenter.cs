using Application.IPresenters;
using Application.Repositories;
using DiceBattle.Views;
using Domain.DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceBattle.Presenters
{
    internal class UnitSelectPresenter : IUnitSelectPresenter
    {
        private ViewUpdater _updater;

        private IImageRepository _imageRepository;

        public UnitSelectPresenter(ViewUpdater updater, IImageRepository imageRepository)
        {
            _updater = updater;
            _imageRepository = imageRepository;
        }

        public void UpdateScreen(UnitSelection unitSelection)
        {
            ViewModel viewModel = new ViewModel();

            int yNum = unitSelection.YNum;
            int xNum = unitSelection.XNum;
            const int X_ORIGIN = 50;
            const int Y_ORIGIN = 50;
            const int INTERVAL = 100;
            const int WIDTH = 75;
            const int HEIGHT = 75;

            for (int i = 0; i < yNum; i++)
            {
                for (int j = 0; j < xNum; j++)
                {
                    int x = X_ORIGIN + INTERVAL * j;
                    int y = Y_ORIGIN + INTERVAL * i;
                    Unit unit = unitSelection.Units[i, j];
                    if (unit != null)
                    {
                        int handle = _imageRepository.Get(unit.GraphId).GraphicHandles[0];
                        Graph g = new Graph(handle, x, y, WIDTH, HEIGHT);
                        viewModel.graphs.Add(g);

                        //Left Unit
                        if (unitSelection.LeftUnitSelection != null &&
                            unitSelection.LeftUnitSelection.X == j && 
                            unitSelection.LeftUnitSelection.Y == i)
                        {
                            Box b = new Box(x, y, x + WIDTH, y + HEIGHT, Constants.Color.WHITE, 0);
                            viewModel.boxes.Add(b);
                            Text t = new Text("1P", x, y - 10, Constants.Color.WHITE);
                            viewModel.texts.Add(t);
                        }

                        //Right Unit
                        if (unitSelection.RightUnitSelection != null &&
                            unitSelection.RightUnitSelection.X == j &&
                            unitSelection.RightUnitSelection.Y == i)
                        {
                            Box b = new Box(x, y, x + WIDTH, y + HEIGHT, Constants.Color.WHITE, 0);
                            viewModel.boxes.Add(b);

                            if (unitSelection.LeftUnitSelection.X == unitSelection.RightUnitSelection.X &&
                                unitSelection.LeftUnitSelection.Y == unitSelection.RightUnitSelection.Y)
                            {
                                Text t = new Text("1P  2P", x, y - 10, Constants.Color.WHITE);
                                viewModel.texts.Add(t);
                            }
                            else
                            {
                                Text t = new Text("2P", x, y - 10, Constants.Color.WHITE);
                                viewModel.texts.Add(t);
                            }
                        }

                        //CurrentSelectedUnit
                        if (unitSelection.CurrentSelection != null &&
                            unitSelection.CurrentSelection.X == j &&
                            unitSelection.CurrentSelection.Y == i)
                        {
                            Box b = new Box(x, y, x + WIDTH, y + HEIGHT, Constants.Color.RED, 0);
                            viewModel.boxes.Add(b);
                        }

                    }


                }
            }

            _updater.CreateViewModel = viewModel;
            
        }
    }
}
