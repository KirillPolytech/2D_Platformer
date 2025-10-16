using Game.Runtime.Scripts.Config;
using UnityEngine;
using Zenject;

namespace Game.Runtime.Scripts.Contexts
{
    public class BootContext : MonoInstaller
    {
        [SerializeField]
        private GameConfig gameConfig;

        [SerializeField]
        private EnemiesConfig enemiesConfig;

        public override void InstallBindings()
        {
            Container.BindInstance(gameConfig).AsSingle();
            Container.BindInstance(enemiesConfig).AsSingle();
        }
    }
}