﻿
namespace Domain.DataObjects
{
    public class Graph
    {

        public int graphId;

        public int x;

        public int y;

        public int width;

        public int height;

        public bool isTranslucent;

        public byte transparency;

        public Graph(int graphId)
        {
            this.graphId = graphId;
        }

        public Graph(int graphId, int x, int y, int width, int height, bool isTranslucent = false, byte transparency = 128)
        {
            this.graphId = graphId;
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
            this.isTranslucent = isTranslucent;
            this.transparency = transparency;
        }

    }
}
