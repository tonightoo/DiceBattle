using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DataObjects
{
    public class TitleMenu
    {

        private List<String> Menu = new List<String>();

        private int _currentIndex = 0;

        public int CurrentIndex
        {
            get
            {
                return _currentIndex;
            }
        }


        public TitleMenu(List<string> menu, int currentIndex = 0)
        {
            Menu = menu;
            _currentIndex = currentIndex;
        }

        public int Previous()
        {
            _currentIndex = (_currentIndex + Menu.Count - 1) % Menu.Count;
            return _currentIndex;
        }

        public int Next()
        {
            _currentIndex = (_currentIndex + 1) % Menu.Count;
            return _currentIndex;
        }

        public string Get()
        {
            return Menu[_currentIndex];
        }

        public string Get(int index) 
        { 
            return Menu[index];
        }

        public int Count()
        {
            return Menu.Count;
        }

        public List<string> GetMenu()
        {
            return Menu;
        }

    }
}
