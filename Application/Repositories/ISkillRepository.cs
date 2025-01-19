using Domain.DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repositories
{
    public interface ISkillRepository
    {

        Skill Get(int id);

        Dictionary<int, Skill> GetAllSkills();

        void Add(int id, Skill skill);

    }
}
