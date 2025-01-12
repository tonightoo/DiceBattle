using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.UseCases.Title;
using Application;
using Domain.DataObjects;
using System.Xml.Schema;

namespace Application.Scenes
{
    public class TitleScene : IScene
    {

        private ITitleUseCase _useCase;

        private IScene _battleScene;

        public TitleScene(ITitleUseCase useCase, IScene scene) 
        {
            _useCase = useCase;
            _battleScene = scene;
        }

        public IScene Initialize()
        {
            return new TitleScene(_useCase, _battleScene.Initialize());
        }

        public IScene Cancel()
        {
            return this;
        }

        public IScene Decision()
        {
            if (_useCase.Decision() == Constants.Menu.FIRST_MENU)
            {
                return _battleScene.Initialize();
            }
            else if (_useCase.Decision() == Constants.Menu.SECOND_MENU)
            {
                return new EndScene();
            }
            else
            {
                throw new Exception();
            }
        }

        public IScene Down()
        {
            _useCase.Next();
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
            _useCase.Previous();
            return this;
        }

    }
}
