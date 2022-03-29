using UnityEngine;

namespace _Project.AssetManagement
{
    public interface IAssetProvider
    {
        GameObject Instantiate(string path, Transform parent);
        GameObject Instantiate(string path);
    }
}