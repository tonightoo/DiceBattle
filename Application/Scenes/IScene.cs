using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Scenes
{
    public interface IScene
    {

        IScene Initialize();

        IScene Decision();

        IScene Cancel();

        IScene Up();

        IScene Down();

        IScene Left();

        IScene Right();

        IScene ScreenUpdate();

    }
}
