

/*namespace Game.Runtime.Scripts.Factories
{
    public class EnemyFactory
    {
        private readonly Dictionary<Type, Enemy> _figurePrefabMap;
        private readonly IInstantiator _instantiator;
        private readonly Transform _parent;

        [Inject]
        public EnemyFactory(EnemiesProvider enemiesProvider, IInstantiator instantiator)
        {
            _figurePrefabMap = enemiesProvider
                .EnemyPrefabs
                .ToDictionary(x => x.GetType(), x => x);
            _instantiator = instantiator;
            _parent = new GameObject("FiguresParent").transform;
        }

        public T Create<T>() where T : Enemy
        {
            if (_figurePrefabMap.TryGetValue(typeof(T), out Enemy enemy))
            {
                T t = _instantiator.InstantiatePrefabForComponent<T>(enemy);
                t.transform.SetParent(_parent);
                return t;
            }

            throw new InvalidOperationException(
                $"[Create] Prefab for type {typeof(T)} not found in factory. [Time:{Time.time}]");
        }

        public Enemy Create(Type type)
        {
            if (_figurePrefabMap.TryGetValue(type, out Enemy figure))
            {
                Enemy temp = _instantiator.InstantiatePrefab(figure.gameObject).GetComponent<Enemy>();
                temp.transform.SetParent(_parent);
                return temp;
            }

            throw new InvalidOperationException(
                $"[Create] Prefab for type {type} not found in factory. [Time:{Time.time}]");
        }
    }
}*/