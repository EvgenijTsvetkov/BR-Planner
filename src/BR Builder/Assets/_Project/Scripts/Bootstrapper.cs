using _Project.Scripts.Point;
using UnityEngine;
using Zenject;

namespace _Project.Scripts
{
    public class Bootstrapper : MonoBehaviour
    {
        private SkillPointManager _skillPointManager;

        [Inject]
        private void Construct(SkillPointManager skillPointManager)
        {
            _skillPointManager = skillPointManager;
        }
        private void Start()
        {
            /*Debug.LogWarning("ConvertPoints");
            
            _skillPointManager.ConvertPoints();*/
        }
    }
}
