using Application.Scenes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Facade
{
    public class UseCaseFacade : IUseCaseFacade
    {

        private IScene _scene;

        public UseCaseFacade(IScene firstScene) 
        {
            _scene = firstScene;
        }  

        public void Cancel()
        {
            _scene = _scene.Cancel();
        }

        public void Decision()
        {
            _scene = _scene.Decision();
        }

        public void Down()
        {
            _scene = _scene.Down();
        }

        public void Left()
        {
            _scene = _scene.Left();
        }

        public void Right()
        {
            _scene = _scene.Right();
        }

        public void ScreenUpdate()
        {
            _scene = _scene.ScreenUpdate();
        }

        public void Up()
        {
            _scene = _scene.Up();
        }
    }
}
