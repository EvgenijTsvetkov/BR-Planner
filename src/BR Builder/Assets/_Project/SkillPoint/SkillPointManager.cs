using System;
using UniRx;
using UnityEngine;

namespace _Project.Scripts.Point
{
    public class SkillPointManager : MonoBehaviour
    {
        public int TotalPoints = 9744;

        private const int ConversionValue = 14;

        private void Awake()
        {
            ScholarPoints = new ReactiveProperty<int>();
            AdeptPoints = new ReactiveProperty<int>();
            MasterPoints = new ReactiveProperty<int>();
        }

        public ReactiveProperty<int> ScholarPoints { get; private set; }
        public ReactiveProperty<int> AdeptPoints { get; private set; }
        public ReactiveProperty<int> MasterPoints { get; private set; }

        private void Start() => 
            ConvertPoints();

        public void ConvertPoints()
        {
            int adeptPoint = TotalPoints % ConversionValue;
            int tempScholarPoints = (TotalPoints - adeptPoint) / ConversionValue;
            int scholarPoints = tempScholarPoints % ConversionValue;
            int masterPoints = (tempScholarPoints - scholarPoints) / ConversionValue;
            
            AdeptPoints.Value = adeptPoint;
            ScholarPoints.Value = scholarPoints;
            MasterPoints.Value = masterPoints;
        }

        private void ConvertToAdept()
        {

        }
        
    }
}  
