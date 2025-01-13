using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DataObjects
{
    public class Image
    {

        public int ImageId
        {
            get; set;
        }

        public string FilePath
        {
            get; set;
        }

        public int AllNum
        {
            get; set;
        }

        public int XNum
        {
            get; set;
        }

        public int YNum
        {
            get; set;
        }

        public int Width
        {
            get; set;
        }

        public int Height
        {
            get; set;
        }

        public int[] GraphicHandles
        {
            get; set;
        }

    }
}
