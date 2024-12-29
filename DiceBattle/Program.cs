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
                BattleView view = new BattleView(updater);
                IBattlePresenter presenter = new BattlePresenter(updater);
                IBattleUseCase useCase = new BattleUseCase(presenter);
                IController controller = new BattleController(useCase);

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
