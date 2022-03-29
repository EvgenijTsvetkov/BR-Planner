using System.Collections.Generic;
using _Project.Skill.ScriptableObjects;
using UnityEngine;

namespace _Project.Class.ScriptableObjects
{
    [CreateAssetMenu(fileName = "Class Data", menuName = "_Project/Static Data/Class Data", order = 1)]
    public class ClassStaticData : ScriptableObject
    {
        public ClassTypeId ClassTypeId;
        public List<SkillTypeId> SkillTypeIds;
    }
}
