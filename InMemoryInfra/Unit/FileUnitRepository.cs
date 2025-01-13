﻿using Application.Repositories;
using Domain.DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;

namespace InMemoryInfra.UnitRepository
{
    public class FileUnitRepository : IUnitRepository
    {

        private IUnitRepository _repository;

        private string _filePath;

        public FileUnitRepository(string filePath)
        {
            _repository = new InMemoryUnitRepository();
            _filePath = filePath;
            Initialize();
        }

        private void Initialize()
        {
            using (FileStream fs = new FileStream(_filePath, FileMode.Open))
            {
                IEnumerable<Unit> list = JsonSerializer.Deserialize<IEnumerable<Unit>>(fs);
                foreach (Unit unit in list)
                {
                    _repository.Save(unit, unit.UnitId);
                }
            }
        }

        public Dictionary<int, Unit> GetAllUnits()
        {
            return _repository.GetAllUnits();
        }

        public Unit GetUnitById(int id)
        {
            return _repository.GetUnitById(id);
        }

        public void Save(Unit unit, int id)
        {
            _repository.Save(unit, id);
            using (FileStream fs = new FileStream(_filePath, FileMode.Append))
            {
                JsonSerializer.Serialize<IEnumerable<Unit>>(fs, _repository.GetAllUnits().Values);
            }
        }
    }
}
