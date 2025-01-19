using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Repositories;
using Domain.DataObjects;

namespace InMemoryInfra.SkillRepository
{
    public class InMemorySkillRepository : ISkillRepository
    {

        public Dictionary<int, Skill> Skills = new Dictionary<int, Skill>();

        public void Add(int id, Skill skill)
        {
            Skills.Add(id, skill);
        }

        public Skill Get(int id)
        {
            return Skills[id];
        }

        public Dictionary<int, Skill> GetAllSkills()
        {
            return Skills;
        }
    }
}
