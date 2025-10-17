using Game.Runtime.Scripts.Generic_FSM;
using Game.Runtime.Scripts.Player.PlayerFSM;
using UnityEngine;

namespace Game.Runtime.Scripts.Enemies.FSM
{
    public class SlimeInitializeState : IState
    {
        private readonly Slime _slime;
        private readonly Vector3 _initialPosition;

        public SlimeInitializeState(Slime slime, Vector3 initialPosition)
        {
            _slime = slime;
            _initialPosition = initialPosition;
        }

        public void Enter()
        {
            _slime.Reset();
            _slime.SetPosition(_initialPosition);
            _slime.StateMachine.Enter<SlimeWalkState>();
        }

        public void Update()
        {
        }

        public void Exit()
        {
        }
    }
}