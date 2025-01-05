using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Title
{
    public interface ITitleUseCase
    {

        void Next();

        void Previous();

        string Decision();

        void ScreenUpdate();
    }
}
