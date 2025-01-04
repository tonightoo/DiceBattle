using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.UseCases.Facade;

namespace DiceBattle.Controllers
{
    internal class Controller : IController
    {

        private IUseCaseFacade _useCase;

        internal Controller(IUseCaseFacade useCase)
        {
            _useCase = useCase;
        }

        public void Cancel()
        {
            _useCase.Cancel();
        }

        public void Decision()
        {
            _useCase.Decision();
        }

        public void Down()
        {
            _useCase.Down();
        }

        public void Left()
        {
            _useCase.Left();
        }

        public void Right()
        {
            _useCase.Right();
        }

        public void ScreenUpdate()
        {
            _useCase.ScreenUpdate();
        }

        public void Up()
        {
            _useCase.Up();
        }
    }
}
