using Game.Runtime.Scripts.Config;
using Game.Runtime.Scripts.PlayerLogic;
using UnityEngine;
using Zenject;

namespace Game.Runtime.Scripts.Characters.MainCharacter
{
    public class FsmReferenceStorage
    {
        public GameConfig GameConfig { get; private set; }
        public InputSystem_Actions Inputs { get; private set; }
        public Rigidbody2D Rb { get; private set; }
        public Animator Animator { get; private set; }
        public PlayerLogic.Player Player { get; private set; }
        public SignalBus SignalBus { get; private set; }
        public PlayerFSM PlayerFsm { get; private set; }

        public FsmReferenceStorage(
            GameConfig gameConfig,
            InputSystem_Actions inputs,
            Rigidbody2D rb,
            Animator animator,
            PlayerLogic.Player player,
            SignalBus signalBus,
            PlayerFSM playerFsm)
        {
            GameConfig = gameConfig;
            Inputs = inputs;
            Rb = rb;
            Animator = animator;
            Player = player;
            SignalBus = signalBus;
            PlayerFsm = playerFsm;
        }
    }
}