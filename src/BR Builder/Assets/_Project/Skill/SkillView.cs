using System.Collections.Generic;
using _Project.BuildPlanner;
using _Project.Skill.ScriptableObjects;
using _Project.StaticData;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace _Project.Skill
{
    public class SkillView : MonoBehaviour
    {
        [SerializeField] private Image _icon;
        [SerializeField] private TMP_Text _name;
        [SerializeField] private TMP_Text _value;

        [Header("Buttons")]
        public Button SelectorButton;

        [Header("Colors")]
        [SerializeField] private Color _scholarColor;
        [SerializeField] private Color _adeptColor;
        [SerializeField] private Color _masterColor;

        private IStaticDataService _staticDataService;
   
        private GameObject _gameObject;
        private Dictionary<PointTypeId, Color> _colorMap;

        [Inject]
        private void Construct(IStaticDataService staticDataService) => 
            _staticDataService = staticDataService;

        private void Awake()
        {
            _gameObject = gameObject;
            
            _colorMap = new Dictionary<PointTypeId, Color>
            {
                {PointTypeId.Scholar, _scholarColor},
                {PointTypeId.Adept, _adeptColor},
                {PointTypeId.Master, _masterColor}
            };
        }

        public void SetActive(bool active) => 
            _gameObject.SetActive(active);

        public void ChangeSkill(SkillTypeId skillTypeId)
        {
            var skillStaticData = _staticDataService.FromSkill(skillTypeId);
            if (skillStaticData == null)
                return;
            
            _icon.sprite = skillStaticData.Icon;
            _name.text = skillStaticData.Name;
        }

        public void UpdateValue(PointTypeId type, int value)
        {
            _value.text = value.ToString();
            _value.color = _colorMap[type];
        }
    }
}
