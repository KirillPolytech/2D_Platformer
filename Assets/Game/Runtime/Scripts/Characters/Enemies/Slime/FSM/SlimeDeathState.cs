using Game.Runtime.Scripts.Generic_FSM;
using UnityEngine;

namespace Game.Runtime.Scripts.Enemies.FSM
{
    public class SlimeDeathState : IState
    {
        private readonly Animator _animator;
        private readonly Slime _slime;

        public SlimeDeathState(
            Animator animator, 
            Slime slime)
        {
            _animator = animator;
            _slime = slime;
        }

        public void Enter()
        {
            _animator.SetTrigger(GlobalVariables.Hurt);
            _slime.Die();
        }

        public void Update()
        {
        }

        public void Exit()
        {
        }
    }
}