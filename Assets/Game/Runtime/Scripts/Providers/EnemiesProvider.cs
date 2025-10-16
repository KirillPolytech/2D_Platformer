using Game.Runtime.Scripts.Enemies;
using Zenject;

namespace Game.Runtime.Scripts.Providers
{
    public class EnemiesProvider
    {
        public Enemy[] EnemyPrefabs { get; private set; }

        [Inject]
        public EnemiesProvider(Enemy[] enemyPrefabs)
        {
            EnemyPrefabs = enemyPrefabs;
        }
    }
}