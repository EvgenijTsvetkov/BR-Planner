using _Project.Scripts.Point;
using UniRx;
using UnityEngine;
using Zenject;

namespace _Project.SkillPoint
{
    public class PointPresenter : MonoBehaviour
    {
        [SerializeField] private SkillPointView skillPointScholarView;
        [SerializeField] private SkillPointView skillPointAdeptView;
        [SerializeField] private SkillPointView skillPointMasterView;

        private SkillPointManager _skillPointManager;
        
        [Inject]
        private void Construct(SkillPointManager skillPointManager) =>
            _skillPointManager = skillPointManager;

        private void Start()
        {
            _skillPointManager.ScholarPoints
                .ObserveEveryValueChanged(x => x.Value)
                .Subscribe(xs => { skillPointScholarView.UpdateValue(xs); }).AddTo(this);

            _skillPointManager.AdeptPoints
                .ObserveEveryValueChanged(x => x.Value)
                .Subscribe(xs => { skillPointAdeptView.UpdateValue(xs); }).AddTo(this);

            _skillPointManager.MasterPoints
                .ObserveEveryValueChanged(x => x.Value)
                .Subscribe(xs => { skillPointMasterView.UpdateValue(xs); }).AddTo(this);
        }
    }
}