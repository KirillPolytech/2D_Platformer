using Game.Runtime.Scripts.Config;
using Game.Runtime.Scripts.Generic_FSM;
using UnityEngine;

namespace Game.Runtime.Scripts.Player.PlayerFSM
{
    public class IdleState : IState
    {
        private readonly Rigidbody2D _rb;
        private readonly InputSystem_Actions _inputs;
        private readonly GameConfig _gameConfig;
        private readonly Animator _animator;
        private readonly PlayerLogic.PlayerFSM _playerFSM;
        private readonly PlayerLogic.Player _player;

        public IdleState(
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
            _animator.SetBool(GlobalVariables.Dead, false);
            _animator.SetBool(GlobalVariables.Grounded, true);
        }

        public void Update()
        {
            if (_inputs.Player.Jump.IsPressed() && _player.IsGrounded)
            {
                _playerFSM.Enter<JumpState>();
            }

            if (Mathf.Abs(_inputs.Player.Move.ReadValue<Vector2>().x) > GlobalVariables.Threshold)
            {
                _playerFSM.Enter<WalkState>();
            }
        }

        public void Exit()
        {
        }
    }
}