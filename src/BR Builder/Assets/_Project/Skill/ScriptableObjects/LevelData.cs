using System;

namespace _Project.Skill.ScriptableObjects
{
    [Serializable]
    public class LevelData
    {
        public PointTypeId maxPointTypeId = PointTypeId.Master;
        public int MaxValue = 7;
    }
}