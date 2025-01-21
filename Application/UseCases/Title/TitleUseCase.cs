using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.IPresenters;
using Domain.DataObjects;

namespace Application.UseCases.Title
{
    public class TitleUseCase : ITitleUseCase
    {

        public TitleMenu Menu;

        private ITitlePresenter _presenter;

        private int _frameCounter;

        public TitleUseCase(ITitlePresenter presenter) 
        {
            List<string> menu = new List<string>();
            menu.Add(Constants.Menu.FIRST_MENU);
            menu.Add(Constants.Menu.SECOND_MENU);
            Menu = new TitleMenu(menu);
            _presenter = presenter;
            _frameCounter = 0;
        }   

        public void Next()
        {
            Menu.Next();
        }

        public void Previous()
        {
            Menu.Previous();
        }

        public string Decision()
        {
            return Menu.Get();
        }


        public void ScreenUpdate()
        {
            _frameCounter++;
            if (_frameCounter <= 60)
            {
                Menu.IsLargerArrow = true;
            }
            else if (_frameCounter <= 120)
            {
                Menu.IsLargerArrow = false;
            }
            else
            {
                _frameCounter = 0;
            }
            _presenter.UpdateScreen(this.Menu);
        }

    }
}
