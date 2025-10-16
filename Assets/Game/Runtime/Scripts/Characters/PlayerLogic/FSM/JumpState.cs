using Game.Runtime.Scripts.Config;
using Game.Runtime.Scripts.Generic_FSM;
using UnityEngine;
using Zenject;

namespace Game.Runtime.Scripts.Player.PlayerFSM
{
    public class JumpState : IState
    {
        private readonly InputSystem_Actions _inputs;
        private readonly GameConfig _gameConfig;
        private readonly Animator _animator;
        private readonly PlayerLogic.PlayerFSM _playerFSM;
        private readonly PlayerLogic.Player _player;
        private readonly SignalBus _signalBus;

        private float _currentTicks;

        public JumpState(
            InputSystem_Actions inputs,
            GameConfig gameConfig,
            Animator animator,
            PlayerLogic.PlayerFSM playerFSM,
            PlayerLogic.Player player,
            SignalBus signalBus)
        {
            _inputs = inputs;
            _gameConfig = gameConfig;
            _animator = animator;
            _playerFSM = playerFSM;
            _player = player;
            _signalBus = signalBus;
        }

        public void Enter()
        {
            _player.Jump();

            _animator.SetBool(GlobalVariables.Grounded, false);

            _currentTicks = 0;
        }

        public void Update()
        {
            _player.Move();

            if (_currentTicks < _gameConfig.JumpTicks && !_player.IsGrounded)
            {
                _currentTicks++;
                return;
            }

            if (_player.IsGrounded)
            {
                _playerFSM.Enter<IdleState>();
            }
        }

        public void Exit()
        {
        }
    }
}