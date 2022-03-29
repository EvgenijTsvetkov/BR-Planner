using _Project.AssetManagement;
using _Project.Factory;
using _Project.Scripts.Point;
using _Project.StaticData;
using UnityEngine;
using Zenject;

namespace _Project.Installers
{
    public class SceneInstaller : MonoInstaller, IInitializable
    {
        [SerializeField] private SkillPointManager skillPointManager;

        public override void InstallBindings()
        {
            BindInstallerInterfaces();
            BindStaticDataService();
            BindAssetProvider();
            BindProjectFactory();
            BindPointManager();
        }

        public void Initialize()
        {
            var staticDataService = Container.Resolve<IStaticDataService>();
            staticDataService.LoadAll();
        }
        
        private void BindInstallerInterfaces()
        {
            Container
                .BindInterfacesTo<SceneInstaller>()
                .FromInstance(this)
                .AsSingle();
        }

        private void BindStaticDataService()
        {
            Container.Bind<IStaticDataService>()
                .To<StaticDataService>()
                .AsSingle();
        }
        
        private void BindAssetProvider()
        {
            Container.Bind<IAssetProvider>()
                .To<AssetProvider>()
                .AsSingle();
        }
        
        private void BindProjectFactory()
        {
            Container.Bind<IProjectFactory>()
                .To<ProjectFactory>()
                .AsSingle();
        }

        private void BindPointManager()
        {
            Container
                .Bind<SkillPointManager>()
                .FromInstance(skillPointManager)
                .AsSingle();
        }
    }
}
