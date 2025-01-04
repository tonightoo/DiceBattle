using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Facade
{
    public interface IUseCaseFacade
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
