using Application.UseCases.UnitSelect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.DataObjects;
using Application.UseCases.Battle;
using Application.IPresenters;
using Application.Repositories;

namespace Application.Scenes
{
    public class UnitSelectScene : IScene
    {

        private readonly IUnitSelectUseCase _useCase;

        private readonly IBattleUseCase _battleUseCase;

        public UnitSelectScene(IUnitSelectUseCase useCase, IBattleUseCase battleUseCase)
        {
            _useCase = useCase;
            _battleUseCase = battleUseCase;
        }


        public IScene Cancel()
        {
            UnitSelection selection = _useCase.Cancel();
            if (selection.IsExit)
            {
                return null;
            } 

            return this;
        }

        public IScene Decision()
        {
            UnitSelection selection = _useCase.Decide();
            if (selection.IsSelected) 
            {
                Dice dice = new Dice(6);
                Unit leftUnit = selection.LeftUnit.Initialize();
                Unit rightUnit = selection.RightUnit.Initialize();

                BattleField field = new BattleField(leftUnit, rightUnit, dice);
                return new BattleScene(_battleUseCase.Initialize(field));
            }

            return this;
        }

        public IScene Down()
        {
            _useCase.Down();
            return this;
        }

        public IScene Initialize()
        {
            return new UnitSelectScene(_useCase.Initialize(), _battleUseCase);
        }

        public IScene Left()
        {
            _useCase.Left();
            return this;
        }

        public IScene Right()
        {
            _useCase.Right();
            return this;
        }

        public IScene ScreenUpdate()
        {
            _useCase.ScreenUpdate();
            return this;
        }

        public IScene Up()
        {
            _useCase.Up();
            return this;
        }
    }
}
