using Game.Runtime.Scripts.Config;
using Game.Runtime.Scripts.Generic_FSM;
using UnityEngine;

namespace Game.Runtime.Scripts.PlayerLogic
{
    public class DeathState : IState
    {
        private readonly Rigidbody2D _rb;
        private readonly InputSystem_Actions _inputs;
        private readonly GameConfig _gameConfig;
        private readonly Animator _animator;
        private readonly PlayerFSM _playerFSM;
        private readonly Player _player;

        public DeathState(
            Rigidbody2D rb,
            InputSystem_Actions inputs,
            GameConfig gameConfig,
            Animator animator,
            PlayerFSM playerFSM,
            Player player)
        {
            _rb = rb;
            _inputs = inputs;
            _gameConfig = gameConfig;
            _animator = animator;
            _playerFSM = playerFSM;
            _player = player;
        }

        public void Enter()
        {
            _animator.SetTrigger(GlobalVariables.Hurt);
            _animator.SetBool(GlobalVariables.Dead, true);
        }

        public void Update()
        {
        }

        public void Exit()
        {
        }
    }
}