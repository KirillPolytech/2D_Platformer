using Game.Runtime.Scripts.Characters.MainCharacter;
using Game.Runtime.Scripts.Generic_FSM;
using UnityEngine;

namespace Game.Runtime.Scripts.Player.PlayerFSM
{
    public class WalkState : IState
    {
        private FsmReferenceStorage _refs;

        public WalkState(FsmReferenceStorage refs)
        {
            _refs = refs;
        }

        public void Enter()
        {
            _refs.Animator.SetBool(GlobalVariables.Grounded, true);
        }

        public void Update()
        {
            _refs.Player.Move();

            _refs.Animator.SetFloat(GlobalVariables.VelocityX, Mathf.Abs(_refs.Rb.velocity.x));

            if (_refs.Inputs.Player.Jump.IsPressed() && _refs.Player.IsGrounded)
                _refs.PlayerFsm.Enter<JumpState>();
        }

        public void Exit()
        {
            _refs.Animator.SetFloat(GlobalVariables.VelocityX, 0);
            _refs.Animator.SetFloat(GlobalVariables.VelocityY, 0);
        }
    }
}