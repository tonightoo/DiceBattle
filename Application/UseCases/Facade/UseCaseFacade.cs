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

        private Stack<IScene> _sceneStack;

        public UseCaseFacade(IScene firstScene) 
        {
            _sceneStack = new Stack<IScene>();
            _sceneStack.Push(firstScene);
        }  

        public void Cancel()
        {
            IScene next = _sceneStack.Peek().Cancel();
            SetNext(next);
        }

        public void Decision()
        {
            IScene next = _sceneStack.Peek().Decision();
            SetNext(next);
        }

        public void Down()
        {
            IScene next = _sceneStack.Peek().Down();
            SetNext(next);
        }

        public void Left()
        {
            IScene next = _sceneStack.Peek().Left();
            SetNext(next);
        }

        public void Right()
        {
            IScene next = _sceneStack.Peek().Right();
            SetNext(next);
        }

        public void ScreenUpdate()
        {
            IScene next = _sceneStack.Peek().ScreenUpdate();
            SetNext(next);
        }

        public void Up()
        {
            IScene next = _sceneStack.Peek().Up();
            SetNext(next);
        }

        private void SetNext(IScene next)
        {
            if (next == null)
            {
                _sceneStack.Pop();
            } 
            else
            {
                if (next != _sceneStack.Peek())
                {
                    _sceneStack.Push(next);
                }
            }

        }

    }
}
