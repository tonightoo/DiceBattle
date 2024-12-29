using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.UseCases.Battle;

namespace DiceBattle.Controllers
{
    internal class BattleController : IController
    {

        private readonly IBattleUseCase _useCase;

        internal BattleController(IBattleUseCase useCase)
        {
            _useCase = useCase;
        }

        public void Decision()
        {
            _useCase.NextTurn();
        }

        public void Cancel()
        {
        }

        public void Up()
        {
        }

        public void Down()
        {
        }

        public void Left()
        {
        }

        public void Right()
        {
        }

        public void ScreenUpdate() { 
            _useCase.ScreenUpdate();
        }
    }
}
