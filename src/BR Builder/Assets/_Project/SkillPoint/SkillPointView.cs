using TMPro;
using UnityEngine;

namespace _Project.SkillPoint
{
    public class SkillPointView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _valueText;

        public void UpdateValue(int count) => 
            _valueText.text = count.ToString();
    }
}
