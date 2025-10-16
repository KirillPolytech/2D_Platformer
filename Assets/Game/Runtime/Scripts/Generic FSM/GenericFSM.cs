using System.Collections.Generic;
using UnityEngine;

namespace Game.Runtime.Scripts.Generic_FSM
{
    public abstract class GenericFSM
    {
        protected readonly Dictionary<string, IState> _states = new();
        
        public IState Current { get; private set; }

        public void Enter<T>() where T : IState
        {
            Current?.Exit();
            Current = _states[typeof(T).ToString()];
            Current.Enter();
            
            Debug.Log($"Entered state {Current.GetType()} Time:{Time.time}");
        }

        public void UpdateState()
        {
            Current?.Update();
        }
    }
}