using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceBattle.Controllers
{
    internal interface IController
    {

        void Decision();

        void Cancel();

        void Up();

        void Down();

        void Left();

        void Right();

        void ScreenUpdate();

    }
}
