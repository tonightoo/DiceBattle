using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Repositories;
using Domain.DataObjects;

namespace InMemoryInfra
{
    public class InMemoryUnitRepository : IUnitRepository
    {

        Dictionary<int, Unit> _units;   

        public InMemoryUnitRepository() 
        {
            _units = new Dictionary<int, Unit>();
            int[] playerAttack = { 1, 2, 3, 4, 5, 6 };
            int[] enemyAttack = { 1, 1, 1, 1, 1, 10 };
            Unit player = new Unit("Player", playerAttack, 20, 6);
            Unit enemy = new Unit("Enemy", enemyAttack, 20, 7);

            _units.Add(1, player);
            _units.Add(2, enemy);
        }

        public Dictionary<int, Unit> GetAllUnits()
        {
            return _units;
        }

        public Unit GetUnitById(int id)
        {
            return _units[id];
        }

        public void Save(Unit unit, int id)
        {
            if (_units.Keys.Contains(id))
            {
                _units[id] = unit;
            }
            else
            {
                _units.Add(id, unit);
            }
        }

    }
}
