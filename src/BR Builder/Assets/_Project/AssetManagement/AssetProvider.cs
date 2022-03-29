using UnityEngine;
using Zenject;

namespace _Project.AssetManagement
{
    public class AssetProvider : IAssetProvider
    {
        private DiContainer _diContainer;

        [Inject]
        private void Construct(DiContainer diContainer) => 
            _diContainer = diContainer;

        public GameObject Instantiate(string path, Transform parent)
        {
            var prefab = Resources.Load<GameObject>(path);
            return _diContainer.InstantiatePrefab(prefab, parent);
        }

        public GameObject Instantiate(string path)
        {
            var prefab = Resources.Load<GameObject>(path);
            return _diContainer.InstantiatePrefab(prefab);
        }
    }
}
