using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.DataObjects;

namespace Application.UseCases.UnitSelect
{
    public interface IUnitSelectUseCase
    {
        IUnitSelectUseCase Initialize();

        UnitSelection Decide();

        UnitSelection Cancel();

        void ScreenUpdate();

        void Right();

        void Left();

        void Up();

        void Down();

    }
}
