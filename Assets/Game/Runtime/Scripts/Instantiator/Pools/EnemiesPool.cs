/*
 using System;

using System.Collections.Generic;
using Game.Runtime.Scripts.Config;
using Game.Runtime.Scripts.Enemies;
using Game.Runtime.Scripts.Factories;
using Game.Runtime.Scripts.Providers;
using Zenject;

namespace Game.Runtime.Scripts.Pools
{
    public class EnemiesPool : IInitializable
    {
        private readonly EnemyFactory _factory;
        private readonly GameConfig _gameConfig;
        private readonly Dictionary<Type, Queue<Enemy>> _pool = new();
        private readonly EnemiesProvider _provider;

        public readonly List<Type> _enemyTypes = new();


        [Inject]
        public EnemiesPool(EnemyFactory factory, GameConfig gameConfig, EnemiesProvider provider)
        {
            _factory = factory;
            _gameConfig = gameConfig;
            _provider = provider;
        }

        public void Initialize()
        {
            foreach (var enemy in _provider.EnemyPrefabs)
            {
                _enemyTypes.Add(enemy.GetType());
            }

            foreach (Type type in _enemyTypes)
            {
                Return(_factory.Create(type));
            }
        }

        public Enemy Get(Type type)
        {
            if (_pool.TryGetValue(type, out var queue) && queue.Count > 0)
            {
                var instance = queue.Dequeue();
                return instance;
            }

            return _factory.Create(type);
        }

        public T Get<T>(Type type) where T : Enemy
        {
            if (_pool.TryGetValue(type, out var queue) && queue.Count > 0)
            {
                var instance = queue.Dequeue();
                return instance as T;
            }

            return _factory.Create<T>();
        }

        public void Return(Enemy enemy)
        {
            Type type = enemy.GetType();

            if (!_pool.ContainsKey(type))
            {
                _pool.Add(type, new Queue<Enemy>());
            }

            enemy.gameObject.SetActive(false);
            _pool[type].Enqueue(enemy);
        }
    }
}
*/