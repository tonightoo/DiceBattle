using System;
using DiceBattle.Views;

namespace DiceBattle
{
    public class ViewUpdater
    {
        private ViewModel viewModel;

        internal event Action<ViewModel> Update;

        internal ViewModel CreateViewModel
        {
            get { return viewModel; }
            set { 
                viewModel = value;

                if (Update != null)
                {
                    Update(viewModel);
                }
            }
        }

    }
}
