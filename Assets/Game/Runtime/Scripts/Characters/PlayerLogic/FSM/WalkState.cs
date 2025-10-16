using Game.Runtime.Scripts.Config;
using Game.Runtime.Scripts.Generic_FSM;
using UnityEngine;

namespace Game.Runtime.Scripts.Player.PlayerFSM
{
    public class WalkState : IState
    {
        private readonly Rigidbody2D _rb;
        private readonly InputSystem_Actions _inputs;
        private readonly GameConfig _gameConfig;
        private readonly Animator _animator;
        private readonly PlayerLogic.PlayerFSM _playerFSM;
        private readonly PlayerLogic.Player _player;

        public WalkState(
            Rigidbody2D rb,
            InputSystem_Actions inputs,
            GameConfig gameConfig,
            Animator animator,
            PlayerLogic.PlayerFSM playerFSM,
            PlayerLogic.Player player)
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
            _animator.SetBool(GlobalVariables.Grounded, true);
        }

        public void Update()
        {
            _player.Move();

            _animator.SetFloat(GlobalVariables.VelocityX, Mathf.Abs(_rb.velocity.x));

            if (_inputs.Player.Jump.IsPressed() && _player.IsGrounded)
                _playerFSM.Enter<JumpState>();
        }

        public void Exit()
        {
            _animator.SetFloat(GlobalVariables.VelocityX, 0);
            _animator.SetFloat(GlobalVariables.VelocityY, 0);
        }
    }
}