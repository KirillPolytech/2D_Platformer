using Game.Runtime.Scripts.Characters.MainCharacter;
using Game.Runtime.Scripts.Generic_FSM;
using UnityEngine;

namespace Game.Runtime.Scripts.Player.PlayerFSM
{
    public class IdleState : IState
    {
        private FsmReferenceStorage _refs;

        public IdleState(FsmReferenceStorage refs)
        {
            _refs = refs;
        }

        public void Enter()
        {
            _refs.Animator.SetBool(GlobalVariables.Dead, false);
            _refs.Animator.SetBool(GlobalVariables.Grounded, true);
        }

        public void Update()
        {
            if (_refs.Inputs.Player.Jump.IsPressed() && _refs.Player.IsGrounded)
            {
                _refs.PlayerFsm.Enter<JumpState>();
            }

            if (Mathf.Abs(_refs.Inputs.Player.Move.ReadValue<Vector2>().x) > GlobalVariables.Threshold)
            {
                _refs.PlayerFsm.Enter<WalkState>();
            }
        }

        public void Exit()
        {
        }
    }
}