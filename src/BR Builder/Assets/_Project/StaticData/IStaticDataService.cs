using _Project.Class;
using _Project.Class.ScriptableObjects;
using _Project.Skill.ScriptableObjects;

namespace _Project.StaticData
{
    public interface IStaticDataService
    {
        void LoadAll();
        ClassStaticData FromClass(ClassTypeId typeId);
        SkillStaticData FromSkill(SkillTypeId typeId);
    }
}