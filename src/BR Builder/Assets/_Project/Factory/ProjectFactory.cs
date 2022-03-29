using _Project.AssetManagement;
using UnityEngine;
using Zenject;

namespace _Project.Factory
{
    public class ProjectFactory : IProjectFactory
    {
        private IAssetProvider _assetProvider;

        [Inject]
        public ProjectFactory(IAssetProvider assetProvider) => 
            _assetProvider = assetProvider;

        public GameObject CreateSkillView() => 
            _assetProvider.Instantiate(AssetPath.SkillViewPath);
    }
}