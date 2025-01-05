﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DxLibDLL.DX;
using Domain.DataObjects;

namespace DiceBattle
{
    internal class Constants
    {

        internal class Color
        {
            internal static readonly uint WHITE = GetColor(255, 255, 255);
        }

        internal class Title
        {
            internal static readonly int MENU_MARGIN = 50;

            internal static readonly int FIRST_MENU_Y = 350;

            internal static readonly int MENU_ARROW_X = 300;

            internal static readonly int MENU_X = 350;

            internal static readonly string ARROW = "▶";
        }

        internal class Battle
        {
            internal static readonly int PLAYER_X = 30;

            internal static readonly int ENEMY_X = 700; 

            internal static readonly Point WIN_POSITION = new Point(300, 400);

            internal static readonly int NAME_TEXT_Y = 50;

            internal static readonly int HP_TEXT_Y = 80;

            internal static readonly int FIRST_ATTACK_TEXT_Y = 150;

            internal static readonly int ATTACK_TEXT_MARGIN = 30;

        }


    }
}