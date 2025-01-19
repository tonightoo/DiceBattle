using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DataObjects
{
    public class Skill
    {

        public string Name
        {
            get; set;
        }

        public int Id {
            get; set; 
        }


        public string Description
        {
            get; set;
        }

        public int Value
        {
            get; set;
        }

        public Target Target
        {
            get; set;
        }

        public SkillType Type
        {
            get; set;
        }

    }

    public enum Target
    {
        None = 0,
        Own = 1,
        Enemy = 2,
    }

    public enum SkillType
    {
        Damage = 0,
        Heal = 1,
    }


}
