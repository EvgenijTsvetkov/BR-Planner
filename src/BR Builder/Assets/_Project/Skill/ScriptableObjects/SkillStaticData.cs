using _Project.Class;
using UnityEngine;

namespace _Project.Skill.ScriptableObjects
{
    [CreateAssetMenu(fileName = "Skill Data", menuName = "_Project/Static Data/Skill Data", order = 2)]
    public class SkillStaticData : ScriptableObject
    {
        public SkillTypeId SkillTypeId;
        public ClassTypeId ClassTypeId;
        public string Name;
        public LevelData LevelData;
        public Sprite Icon;
    }
}
