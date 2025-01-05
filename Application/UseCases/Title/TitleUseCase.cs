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

        public TitleUseCase(ITitlePresenter presenter) 
        {
            List<string> menu = new List<string>();
            menu.Add(Constants.Menu.FIRST_MENU);
            menu.Add(Constants.Menu.SECOND_MENU);
            Menu = new TitleMenu(menu);
            _presenter = presenter;
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
            _presenter.UpdateScreen(this.Menu);
        }

    }
}
