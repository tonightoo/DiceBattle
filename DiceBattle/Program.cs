using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DxLibDLL.DX;
using Domain;
using System.Diagnostics.Eventing.Reader;

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
                int[] playerAttack = { 1, 2, 3, 4, 5, 6 };
                int[] enemyAttack = { 1, 1, 1, 1, 1, 10 };
                Unit player = new Unit("Player", playerAttack, 20);
                Unit enemy = new Unit("Enemy", enemyAttack, 20);
                bool playerTurn = true;
                Random dice = new Random();

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

                        if (playerTurn)
                        {
                            int rollResult = dice.Next(5);
                            int damage = player.Attacks[rollResult];
                            enemy.Hp -= damage;
                            playerTurn = false;
                        }
                        else
                        {
                            int rollResult = dice.Next(5);
                            int damage = enemy.Attacks[rollResult];
                            player.Hp -= damage;
                            playerTurn = true;
                        }


                    }

                    if (player.Hp <= 0)
                    {
                        DrawString(300, 400, "enemy win", GetColor(255, 255, 255));
                    }
                    else if (enemy.Hp <= 0)
                    {
                        DrawString(300, 400, "player win", GetColor(255, 255, 255));
                    }
                    else
                    {
                        DrawString(400, 400, $"{player.Name}:{player.Hp}", GetColor(255, 255, 255));
                        DrawString(100, 400, $"{enemy.Name}:{enemy.Hp}", GetColor(255, 255, 255));
                    }

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
