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
using InMemoryInfra;
using System.Runtime.CompilerServices;

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

                IGraphRepository graphRepositroy = new InMemoryGraphRepository();
                LoadGraphs(graphRepositroy);

                IUnitRepository srcRepository = new InMemoryUnitRepository();
                IUnitRepository unitRepository = new InMemoryUnitRepository();
                LoadUnits(srcRepository, unitRepository, graphRepositroy);

                IBattlePresenter battlePresenter = new BattlePresenter(updater);
                ITitlePresenter titlePresenter = new TitlePresenter(updater);

                BattleField battleField = CreateBattleField(unitRepository, graphRepositroy);
                IBattleUseCase battleUseCase = new BattleUseCase(battlePresenter, battleField);
                ITitleUseCase titleUseCase = new TitleUseCase(titlePresenter);
                IScene battleScene = new BattleScene(battleUseCase);
                IScene firstScene = new TitleScene(titleUseCase, battleScene);
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

                    if (keys[KEY_INPUT_RETURN] == 1)
                    {
                        controller.Decision();
                    }

                    if (keys[KEY_INPUT_K] == 1)
                    {
                        controller.Up();
                    }

                    if (keys[KEY_INPUT_J] == 1)
                    {
                        controller.Down();
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

        private static void LoadGraphs(IGraphRepository repository)
        {
            int count = 0;
            int[] graphicHandles = new int[6];
            LoadDivGraph(".\\Assets\\Dice.png", 6, 6, 1, 128, 128, graphicHandles);
            foreach (int id in graphicHandles)
            {
                repository.Add(count, id);
                count++;
            }
            repository.Add(count, LoadGraph(".\\Assets\\Test1.png"));
            count++;
            repository.Add(count, LoadGraph(".\\Assets\\Test2.png"));
            count++;

        }

        private static void LoadUnits(IUnitRepository src, IUnitRepository dst, IGraphRepository graphRepository)
        {
            Dictionary<int, Unit> units = src.GetAllUnits();
            foreach (int key in units.Keys)
            {
                Unit unit = units[key];
                unit.GraphicHandle = graphRepository.Get(unit.GraphId);
                dst.Save(unit, key);
            }
        }

        private static BattleField CreateBattleField(IUnitRepository unitRepository, IGraphRepository graphRepository)
        {
            Unit player = unitRepository.GetUnitById(1);
            Unit enemy = unitRepository.GetUnitById(2);
            Dice dice = new Dice(6);
            for (int i = 0; i < 6; i++)
            {
                dice.GraphicHandles[i] = graphRepository.Get(i);
            }

            return new BattleField(player, enemy, dice);
        }


    }


}
