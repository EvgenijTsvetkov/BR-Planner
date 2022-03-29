using System.Collections.Generic;
using System.Linq;
using _Project.Class;
using _Project.Class.ScriptableObjects;
using _Project.Skill.ScriptableObjects;
using UnityEngine;

namespace _Project.StaticData
{
    public class StaticDataService : IStaticDataService
    {
        private Dictionary<ClassTypeId, ClassStaticData> _classes;
        private Dictionary<SkillTypeId, SkillStaticData> _skills;

        private const string ClassDataPath = "Static Data/Class";
        private const string SkillDataPath = "Static Data/Skill";
        public void LoadAll()
        {
            _classes = Resources
                .LoadAll<ClassStaticData>(ClassDataPath)
                .ToDictionary(x => x.ClassTypeId, x => x);
         
            _skills = Resources
                .LoadAll<SkillStaticData>(SkillDataPath)
                .ToDictionary(x => x.SkillTypeId, x => x);
        }

        public ClassStaticData FromClass(ClassTypeId typeId) =>
            _classes.TryGetValue(typeId, out ClassStaticData staticData)
                ? staticData
                : null;
        
        public SkillStaticData FromSkill(SkillTypeId typeId) =>
            _skills.TryGetValue(typeId, out SkillStaticData staticData)
                ? staticData
                : null;
    }
}