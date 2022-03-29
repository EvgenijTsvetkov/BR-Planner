using _Project.BuildPlanner;
using _Project.Skill.ScriptableObjects;

namespace _Project.Skill
{
    public class SkillPresenter
    {
        private SkillView _skillView;
        private SkillModel _skillModel;

        public SkillPresenter(SkillView view, SkillModel model)
        {
            _skillView = view;
            _skillModel = model;
        }

        public void Enable()
        {
            _skillView.SetActive(true);
            _skillModel.ChangeSkill += OnChangeSkill;
            _skillModel.ChangeSkillLevel += OnChangeSkillLevel;
        }

        public void Disable()
        {
            _skillView.SetActive(false);
            _skillModel.ChangeSkill -= OnChangeSkill;
        }

        private void OnChangeSkill(SkillTypeId skillTypeId) => 
            _skillView.ChangeSkill(skillTypeId);

        private void OnChangeSkillLevel(SkillLevel skillLevel) => 
            _skillView.UpdateValue(skillLevel.PointTypeId, skillLevel.Value);
    }
}
