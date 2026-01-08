using Game.Runtime.Scripts.Characters.MainCharacter;
using Game.Runtime.Scripts.Generic_FSM;

namespace Game.Runtime.Scripts.PlayerLogic
{
    public class DeathState : IState
    {
        private FsmReferenceStorage _refs;

        public DeathState(
            FsmReferenceStorage refs)
        {
            _refs = refs;
        }

        public void Enter()
        {
            _refs.Animator.SetTrigger(GlobalVariables.Hurt);
            _refs.Animator.SetBool(GlobalVariables.Dead, true);
        }

        public void Update()
        {
        }

        public void Exit()
        {
        }
    }
}