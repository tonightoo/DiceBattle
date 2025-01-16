using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DxLibDLL.DX;
using Domain.DataObjects;
using DiceBattle.Controllers;
using Application.UseCases.Battle;
using Application.IPresenters;
using DiceBattle.Presenters;
using DiceBattle.Views;

using Application.UseCases.Facade;
using Application.Scenes;
using Application.UseCases.Title;
using Application.Repositories;
using InMemoryInfra.ImageRepository;
using InMemoryInfra.UnitRepository;
using System.Runtime.CompilerServices;
using Application.UseCases.UnitSelect;

namespace DiceBattle
{
    internal class Program
    {

        static void Main(string[] args)
        {
            try
            {
                // 0:FullScreen, 1:Window
                ChangeWindowMode(1);

                // WindowSize
                SetGraphMode(800, 600, 32);

                // Disable to change screen size
                SetWindowSizeChangeEnableFlag(FALSE, FALSE);

                DxLib_Init();



                int[] keys = new int[256];
                ViewUpdater updater = new ViewUpdater();
                View view = new View(updater);
                //IBattlePresenter presenter = new BattlePresenter(updater);
                //IBattleUseCase useCase = new BattleUseCase(presenter);
                //IController controller = new BattleController(useCase);

                IImageRepository fileImageRepository = new FileImageRepository(".\\Assets\\ImageRepository.json");
                IImageRepository imageRepository = new InMemoryImageRepository();
                LoadGraphs(fileImageRepository,imageRepository);

                IUnitRepository fileUnitRepository = new FileUnitRepository(".\\Assets\\UnitRepository.json");
                //IUnitRepository unitRepository = new InMemoryUnitRepository();
                //LoadUnits(fileUnitRepository, unitRepository, imageRepository);

                IBattlePresenter battlePresenter = new BattlePresenter(updater, imageRepository);
                ITitlePresenter titlePresenter = new TitlePresenter(updater);

                //BattleField battleField = CreateBattleField(unitRepository, imageRepository);
                IBattleUseCase battleUseCase = new BattleUseCase(battlePresenter);

                ITitleUseCase titleUseCase = new TitleUseCase(titlePresenter);
                IScene battleScene = new BattleScene(battleUseCase);
                //IScene firstScene = new TitleScene(titleUseCase, battleScene);

                UnitSelection unitSelection = new UnitSelection(4, 2);
                IUnitSelectPresenter selectPresenter = new UnitSelectPresenter(updater, fileImageRepository);
                IUnitSelectUseCase selectUseCase = new UnitSelectUseCase(fileUnitRepository, selectPresenter, unitSelection);
                IScene selectScene = new UnitSelectScene(selectUseCase, battleUseCase);

                IScene firstScene = new TitleScene(titleUseCase, selectScene);
                IUseCaseFacade useCase = new UseCaseFacade(firstScene);
                IController controller = new Controller(useCase);


                while (ProcessMessage() == 0)
                {
                    ClearDrawScreen();

                    GetHitKeyStateAllEx(keys);

                    if (keys[KEY_INPUT_ESCAPE] == 1)
                    {
                        break;
                    }

                    if (keys[KEY_INPUT_BACK] == 1)
                    {
                        controller.Cancel();
                    }

                    if (keys[KEY_INPUT_RETURN] == 1)
                    {
                        controller.Decision();
                    }

                    if (keys[KEY_INPUT_K] == 1 ||
                        keys[KEY_INPUT_UP] == 1)
                    {
                        controller.Up();
                    }

                    if (keys[KEY_INPUT_J] == 1 ||
                        keys[KEY_INPUT_DOWN] == 1)
                    {
                        controller.Down();
                    }

                    if (keys[KEY_INPUT_H] == 1 ||
                        keys[KEY_INPUT_LEFT] == 1)
                    {
                        controller.Left();
                    }

                    if (keys[KEY_INPUT_L] == 1 ||
                        keys[KEY_INPUT_RIGHT] == 1)
                    {
                        controller.Right();
                    }

                    controller.ScreenUpdate();

                    ScreenFlip();
                }


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                DxLib_End();
            }
        }

        private static void LoadGraphs(IImageRepository src, IImageRepository dst)
        {
            Dictionary<int, Image> images = src.GetAll();

            foreach (int imageId in images.Keys) 
            {
                Image image = images[imageId];
                int[] handles = new int[image.AllNum];

                if (image.AllNum == 1)
                {
                    handles[0] = LoadGraph(image.FilePath);
                }
                else
                {
                    LoadDivGraph(image.FilePath, image.AllNum, image.XNum, image.YNum, image.Width, image.Height, handles);
                }
                image.GraphicHandles = handles;
                dst.Add(image.ImageId, image);
            }

        }

    }


}
