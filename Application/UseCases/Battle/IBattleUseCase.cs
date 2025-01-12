using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Battle
{
    public interface IBattleUseCase
    {
        void NextTurn();

        void ScreenUpdate();

        bool IsEnd();

        IBattleUseCase Initialize();
    }
}
