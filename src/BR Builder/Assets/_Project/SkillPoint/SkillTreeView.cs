using System.Collections.Generic;
using _Project.Factory;
using _Project.Skill;
using UnityEngine;
using Zenject;

namespace _Project.SkillPoint
{
    public class SkillTreeView : MonoBehaviour
    {
        [SerializeField] private Transform _parentFolder;

        private List<SkillView> _skillViews;
        private IProjectFactory _projectFactory;

        public List<SkillView> SkillViews => _skillViews;

        [Inject]
        private void Construct(IProjectFactory projectFactory) => 
            _projectFactory = projectFactory;

        public void CreateSkillViews(int count)
        {
            ClearParentFolder();

            _skillViews = new List<SkillView>(count);
            
            for (var i = 0; i < count; i++)
            {
                var instance = _projectFactory.CreateSkillView();
                instance.transform.SetParent(_parentFolder);
                
                var skillView = instance.GetComponent<SkillView>();

                instance.SetActive(false);

                _skillViews.Add(skillView);
            }
        }

        private void ClearParentFolder()
        {
            foreach (Transform child in _parentFolder)
                Destroy(child.gameObject);
        }
    }
}