using Game.Runtime.Scripts.Config;
using Game.Runtime.Scripts.Enemies;
using Game.Runtime.Scripts.Generic_FSM;
using Game.Runtime.Scripts.MVP;
using Game.Runtime.Scripts.PlayerLogic;
using Game.Runtime.Scripts.Providers;
using Game.Runtime.Scripts.Windows;
using UnityEngine;

namespace Game.Runtime.Scripts.FSM
{
    public class PlayState : IState
    {
        private readonly WindowsController _windowsController;
        private readonly PlayerModel _playerModel;
        private readonly GameConfig _gameConfig;
        private readonly InputSystem_Actions _inputs;
        private readonly PlayerLogic.Player _player;
        private readonly Transform _startPosition;
        private readonly EnemiesProvider _enemiesProvider;

        public PlayState(
            WindowsController windowsController,
            PlayerModel playerModel,
            GameConfig gameConfig,
            InputSystem_Actions inputs,
            PlayerLogic.Player player,
            Transform startPosition,
            EnemiesProvider enemiesProvider)
        {
            _windowsController = windowsController;
            _playerModel = playerModel;
            _gameConfig = gameConfig;
            _inputs = inputs;
            _player = player;
            _startPosition = startPosition;
            _enemiesProvider = enemiesProvider;
        }

        public void Enter()
        {
            _playerModel.Lives.Value = _gameConfig.Lives;
            _playerModel.Score.Value = 0;
            _windowsController.OpenWindow<MainWindow>();
            _player.SetPosition(_startPosition);
            _player.Reset();

            _player.StateMachine.Enter<SpawnState>();

            foreach (var enemy in _enemiesProvider.EnemyPrefabs)
            {
                enemy.StateMachine.Enter<EnemyActiveState>();
            }
        }

        public void Update()
        {
        }

        public void Exit()
        {
            _inputs.Disable();
        }
    }
}