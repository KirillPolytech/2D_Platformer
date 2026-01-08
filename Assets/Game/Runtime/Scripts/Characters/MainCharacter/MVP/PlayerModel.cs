using Game.Runtime.Scripts.Config;
using Zenject;

namespace Game.Runtime.Scripts.MVP
{
    public class PlayerModel : IInitializable
    {
        private readonly GameConfig _gameConfig;

        public ChangedProperty<int> Lives { get; } = new();
        public ChangedProperty<int> Score { get; } = new(0);

        [Inject]
        public PlayerModel(GameConfig gameConfig)
        {
            _gameConfig = gameConfig;
        }

        public void Initialize()
        {
            Lives.Value = _gameConfig.Lives;
        }
    }
}