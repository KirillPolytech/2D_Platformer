using DG.Tweening;
using Game.Runtime.Scripts.Characters.MainCharacter;
using Game.Runtime.Scripts.Config;
using Game.Runtime.Scripts.Generic_FSM;
using Game.Runtime.Scripts.Player.PlayerFSM;
using UnityEngine;

namespace Game.Runtime.Scripts.PlayerLogic
{
    public class SpawnState : IState
    {
        private readonly FsmReferenceStorage _refs;

        public SpawnState(FsmReferenceStorage refs)
        {
            _refs = refs;
        }

        public void Enter()
        {
            _refs.Animator.SetTrigger(GlobalVariables.Spawn);

            DOVirtual.DelayedCall(_refs.GameConfig.SpawnDelay, () =>
            {
                _refs.PlayerFsm.Enter<IdleState>();
                _refs.Inputs.Enable();
            });
        }

        public void Update()
        {
        }

        public void Exit()
        {
        }
    }
}