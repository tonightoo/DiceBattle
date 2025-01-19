using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Repositories;
using Domain.DataObjects;
using System.IO;
using System.Text.Json;

namespace InMemoryInfra.SkillRepository
{
    public class FileSkillRepository : ISkillRepository
    {

        private readonly string _filePath;

        private ISkillRepository _repository;

        public FileSkillRepository(string filePath)
        {
            _filePath = filePath;
            _repository = new InMemorySkillRepository();
            Initialize();
        }

        private void Initialize()
        {
            using (FileStream fs = new FileStream(_filePath, FileMode.Open))
            {
                IEnumerable<Skill> list = JsonSerializer.Deserialize<IEnumerable<Skill>>(fs);
                foreach (Skill skill in list)
                {
                    _repository.Add(skill.Id, skill);
                }
            }

        }

        public Skill Get(int id)
        {
            return _repository.Get(id);
        }

        public Dictionary<int, Skill> GetAllSkills()
        {
            return _repository.GetAllSkills();
        }

        public void Add(int id, Skill skill)
        {
            _repository.Add(id, skill);
            IEnumerable<Skill> list = _repository.GetAllSkills().Values;

            using (FileStream fs = new FileStream(_filePath, FileMode.Append))
            {
                JsonSerializer.Serialize<IEnumerable<Skill>>(fs, list);
            }
        }
    }
}
