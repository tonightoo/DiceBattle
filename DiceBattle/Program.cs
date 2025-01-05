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

                IBattlePresenter battlePresenter = new BattlePresenter(updater);
                ITitlePresenter titlePresenter = new TitlePresenter(updater);
                IBattleUseCase battleUseCase = new BattleUseCase(battlePresenter);
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

    }
}
