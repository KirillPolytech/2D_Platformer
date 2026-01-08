using Game.Runtime.Scripts.Characters.MainCharacter;
using Game.Runtime.Scripts.Generic_FSM;

namespace Game.Runtime.Scripts.Player.PlayerFSM
{
    public class JumpState : IState
    {
        private readonly FsmReferenceStorage _fsmReferenceStorage;

        private float _currentTicks;

        public JumpState(FsmReferenceStorage fsmReferenceStorage)
        {
            _fsmReferenceStorage = fsmReferenceStorage;
        }

        public void Enter()
        {
            _fsmReferenceStorage.Player.Jump();

            _fsmReferenceStorage.Animator.SetBool(GlobalVariables.Grounded, false);

            _currentTicks = 0;
        }

        public void Update()
        {
            _fsmReferenceStorage.Player.Move();

            if (_currentTicks < _fsmReferenceStorage.GameConfig.JumpTicks && !_fsmReferenceStorage.Player.IsGrounded)
            {
                _currentTicks++;
                return;
            }

            if (_fsmReferenceStorage.Player.IsGrounded)
            {
                _fsmReferenceStorage.PlayerFsm.Enter<IdleState>();
            }
        }

        public void Exit()
        {
        }
    }
}