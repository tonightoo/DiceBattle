using Application.UseCases.Battle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Scenes
{
    public class BattleScene : IScene
    {

        private IBattleUseCase _useCase;

        public BattleScene(IBattleUseCase useCase)
        {
            _useCase = useCase;
        }

        public IScene Initialize()
        {
            return new BattleScene(_useCase.Initialize());
        }

        public IScene Cancel()
        {
            return new EndScene();
        }

        public IScene Decision()
        {
            _useCase.NextTurn();

            if (_useCase.IsEnd())
            {
                return null;
            }

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
            _useCase.ScreenUpdate();
            return this;
        }

        public IScene Up()
        {
            return this;
        }
    }
}
