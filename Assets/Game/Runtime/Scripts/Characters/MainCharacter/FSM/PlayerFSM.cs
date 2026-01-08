using Game.Runtime.Scripts.Characters.MainCharacter;
using Game.Runtime.Scripts.Config;
using Game.Runtime.Scripts.Generic_FSM;
using Game.Runtime.Scripts.Player.PlayerFSM;
using UnityEngine;
using Zenject;

namespace Game.Runtime.Scripts.PlayerLogic
{
    public class PlayerFSM : GenericFSM
    {
        public PlayerFSM(
            GameConfig gameConfig,
            InputSystem_Actions inputs,
            Rigidbody2D rb,
            Animator animator,
            Player player,
            SignalBus signalBus)
        {
            FsmReferenceStorage refs = new(gameConfig, inputs, rb, animator, player, signalBus, this);

            _states.Add(typeof(JumpState).ToString(),
                new JumpState(refs));
            _states.Add(typeof(WalkState).ToString(),
                new WalkState(refs));
            _states.Add(typeof(IdleState).ToString(),
                new IdleState(refs));
            _states.Add(typeof(DeathState).ToString(),
                new DeathState(refs));
            _states.Add(typeof(SpawnState).ToString(),
                new SpawnState(refs));
        }
    }
}