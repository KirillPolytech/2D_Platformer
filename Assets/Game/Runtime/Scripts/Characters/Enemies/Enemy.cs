using Game.Runtime.Scripts.Config;
using Game.Runtime.Scripts.Generic_FSM;
using UnityEngine;

namespace Game.Runtime.Scripts.Enemies
{
    public abstract class Enemy : MonoBehaviour
    {
        public GenericFSM StateMachine { get; protected set; }
        public int Damage { get; protected set; }

        protected EnemiesConfig _enemiesConfig;

        protected void Construct(EnemiesConfig enemiesConfig, GenericFSM stateMachine)
        {
            _enemiesConfig = enemiesConfig;
            StateMachine = stateMachine;
        }

        public abstract void Die();
    }
}