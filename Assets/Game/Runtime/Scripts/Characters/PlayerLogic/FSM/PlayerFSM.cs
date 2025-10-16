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
            _states.Add(typeof(JumpState).ToString(),
                new JumpState(inputs, gameConfig, animator, this, player, signalBus));
            _states.Add(typeof(WalkState).ToString(),
                new WalkState(rb, inputs, gameConfig, animator, this, player));
            _states.Add(typeof(IdleState).ToString(),
                new IdleState(rb, inputs, gameConfig, animator, this, player));
            _states.Add(typeof(DeathState).ToString(),
                new DeathState(rb, inputs, gameConfig, animator, this, player));
            _states.Add(typeof(SpawnState).ToString(),
                new SpawnState(rb, inputs, gameConfig, animator, this, player));
        }
    }
}