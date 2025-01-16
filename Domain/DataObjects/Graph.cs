
namespace Domain.DataObjects
{
    public class Graph
    {

        public int GraphicHandle;

        public int X;

        public int Y;

        public int Width;

        public int Height;

        public bool IsTranslucent;

        public byte Transparency;

        public Graph(int handle)
        {
            this.GraphicHandle = handle;
        }

        public Graph(int handle, int x, int y, int width, int height, bool isTranslucent = false, byte transparency = 128)
        {
            this.GraphicHandle = handle;
            this.X = x;
            this.Y = y;
            this.Width = width;
            this.Height = height;
            this.IsTranslucent = isTranslucent;
            this.Transparency = transparency;
        }

    }
}
