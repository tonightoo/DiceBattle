using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Scenes
{
    public class EndScene : IScene
    {
        public IScene Initialize()
        {
            return this;
        }

        public IScene Cancel()
        {
            return this;
        }

        public IScene Decision()
        {
            return this;
        }

        public IScene Down()
        {
            return this;
        }

        public IScene Left()
        {
            return this;
        }

        public IScene Right()
        {
            return this;
        }

        public IScene ScreenUpdate()
        {
            return this;
        }

        public IScene Up()
        {
            return this;
        }
    }
}
