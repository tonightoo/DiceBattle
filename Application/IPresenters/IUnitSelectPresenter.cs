using Domain.DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IPresenters
{
    public interface IUnitSelectPresenter
    {
        void UpdateScreen(UnitSelection unitSelection);
    }
}
