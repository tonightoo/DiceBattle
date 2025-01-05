using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.DataObjects;

namespace Application.Repositories
{
    public interface IUnitRepository
    {

        Dictionary<int, Unit> GetAllUnits();

        Unit GetUnitById(int id);

        void Save(Unit unit, int id);

    }
}
