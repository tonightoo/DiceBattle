﻿using System;
using Domain.DataObjects;
using static DxLibDLL.DX;

namespace DiceBattle.Views
{
    internal class View
        : IDisposable
    {

        private readonly ViewUpdater _viewUpdater;

        internal View(ViewUpdater viewUpdater)
        {
            viewUpdater.Update += Update;
            _viewUpdater = viewUpdater;
        }

        public void Dispose()
        {
            _viewUpdater.Update -= Update;
        }


        private void Update(ViewModel viewModel)
        {
            foreach (Graph graph in viewModel.graphs)
            {
                //半透明設定なら半透明で描画
                if (graph.IsTranslucent)
                {
                    SetDrawBlendMode(DX_BLENDMODE_ALPHA, 122);
                }

                DrawExtendGraph(graph.X, graph.Y, graph.X + graph.Width, graph.Y + graph.Height, graph.GraphicHandle, 1);

                //半透明設定ならもとの設定に戻す
                if (graph.IsTranslucent)
                {
                    SetDrawBlendMode(DX_BLENDMODE_NOBLEND, 0);
                }
            }

            int fontSize = 0;
            foreach (Text text in viewModel.texts)
            {
                if (fontSize != text.fontSize)
                {
                    SetFontSize(text.fontSize);
                }
                DrawString(text.x, text.y, text.content, text.color);
            }

            foreach (Box box in viewModel.boxes)
            {
                DrawBox(box.X1, box.Y1, box.X2, box.Y2, box.Color, box.FillFlag);
            }

        }

    }
}
