using System;
using _Project.BuildPlanner;
using _Project.Skill.ScriptableObjects;

namespace _Project.Skill
{
    public class SkillModel
    {
        private SkillTypeId _skillTypeId;
        private SkillLevel _skillLevel;
        
        public event Action<SkillTypeId> ChangeSkill;
        public event Action<SkillLevel> ChangeSkillLevel;
        
        public SkillModel() => 
            _skillLevel = new SkillLevel();

        public void SetSkill(SkillTypeId skillTypeId)
        {
            _skillTypeId = skillTypeId;

    
            ChangeSkill?.Invoke(_skillTypeId);
        }

        public void SetLevelValue(SkillLevel skillLevel)
        {
            _skillLevel = skillLevel;

            ChangeSkillLevel?.Invoke(_skillLevel);
        }
    }
}