using System;
using Game.Runtime.Scripts.Collectables;
using Game.Runtime.Scripts.Config;
using Game.Runtime.Scripts.EventBusThings;
using Game.Runtime.Scripts.FSM;
using Game.Runtime.Scripts.MVP;
using Game.Runtime.Scripts.Providers;
using Platformer.Mechanics;
using UnityEngine;
using Zenject;
using Input = UnityEngine.Input;

namespace Game.Runtime.Scripts
{
    public class GameController : ITickable, IInitializable, IDisposable
    {
        private SignalBus _eventBus;
        private PlayerModel _playerModel;
        private GameStateMachine _gameStateMachine;
        private GameConfig _gameConfig;
        private PathData[] _paths;
        private EnemiesProvider _enemiesProvider;

        [Inject]
        public void Construct(
            SignalBus eventBus,
            PlayerModel playerModel,
            GameStateMachine gameStateMachine,
            GameConfig gameConfig,
            PathData[] paths)
        {
            _eventBus = eventBus;
            _playerModel = playerModel;
            _gameStateMachine = gameStateMachine;
            _gameConfig = gameConfig;
            _paths = paths;
        }

        public void Initialize()
        {
            _eventBus.Subscribe<PlayerOnTriggerEnterHitSignal>(CheckTrigger);
            _eventBus.Subscribe<VictorySignal>(SetVictory);

            _playerModel.Lives.OnChanged += CheckDeath;

            foreach (var pathData in _paths)
            {
                pathData.PatrolPath.Initialize(pathData.Paths);
            }

            _gameStateMachine.Enter<PlayState>();
        }

        public void Dispose()
        {
            _eventBus.Unsubscribe<PlayerOnTriggerEnterHitSignal>(CheckTrigger);
            _eventBus.Unsubscribe<VictorySignal>(SetVictory);

            _playerModel.Lives.OnChanged -= CheckDeath;
        }
        
        public void Tick()
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                //_gameStateMachine.Enter<PauseState>();
            }
        }

        private void CheckTrigger(PlayerOnTriggerEnterHitSignal playerOnTriggerEnterHitSignal)
        {
            Collectable collectable = playerOnTriggerEnterHitSignal.HitObject?.gameObject?.GetComponent<Collectable>();

            if (!collectable)
                return;

            collectable.Collect();
            _playerModel.Score.Value += collectable.Score;
        }

        private void CheckDeath()
        {
            if (_playerModel.Lives.Value <= 0)
            {
                _gameStateMachine.Enter<LoseState>();
            }
        }

        private void SetVictory()
        {
            _gameStateMachine.Enter<WinState>();
        }
    }
}