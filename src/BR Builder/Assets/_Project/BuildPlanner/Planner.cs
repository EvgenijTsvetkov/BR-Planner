using System;
using System.Collections.Generic;
using _Project.Class;
using _Project.Skill;
using _Project.Skill.ScriptableObjects;
using _Project.SkillPoint;
using _Project.StaticData;
using UniRx;
using UnityEngine;
using Zenject;

namespace _Project.BuildPlanner
{
    public class Planner : MonoBehaviour
    {
        [SerializeField] private SkillTreeView _skillTreeView;
        [SerializeField] private ClassTypeId _selectedClass = ClassTypeId.Sheed;
     
        [SerializeField] private int _countSkills = 9;
       
        private IStaticDataService _staticDataService;
        
        private List<SkillModel> _skills = new List<SkillModel>();
        private List<SkillPresenter> _skillPresenters;
        private SkillTypeId _selectedSkill;

        [Inject]
        private void Construct(IStaticDataService staticDataService) => 
            _staticDataService = staticDataService;

        private void Start()
        {
            _skillTreeView.CreateSkillViews(_countSkills);

            InitializeSkillPresenters();
            InitializeClass();
        }

        private void InitializeSkillPresenters()
        {
            _skillPresenters = new List<SkillPresenter>(_countSkills);

            for (var i = 0; i < _countSkills; i++)
            {
                var skillModel = new SkillModel();

                _skills.Add(skillModel);
                _skillPresenters.Add(new SkillPresenter(_skillTreeView.SkillViews[i], skillModel));
            }
        }

        private void InitializeClass()
        {
            var classData = _staticDataService.FromClass(_selectedClass);

            // LoadSkillTree();

            var skillTypeIds = classData.SkillTypeIds;
            var skillViews = _skillTreeView.SkillViews;

            for (var i = 0; i < skillTypeIds.Count; i++)
            {
                _skillPresenters[i].Enable();

                var skillTypeId = skillTypeIds[i];
                var skillModel = _skills[i];
                var skillView = skillViews[i];
                
                skillView.SelectorButton
                    .OnClickAsObservable()
                    .Subscribe(_=> OnSelectSkill(skillTypeId))
                    .AddTo (this);
                
                skillModel.SetSkill(skillTypeId);
                skillModel.SetLevelValue(new SkillLevel());
            }
        }

        private void OnSelectSkill(SkillTypeId skillTypeId)
        {
            _selectedSkill = skillTypeId;
            Debug.LogWarning($"Selected skill: {skillTypeId}");
        }
    }

    [Serializable]
    public class SkillLevel
    {
        public PointTypeId PointTypeId;
        public int Value;
    }
}
