using System;
using UnityEngine;

namespace Game.Runtime.Scripts.Enemies
{
    public class EnemyDeathBox : MonoBehaviour
    {
        public event Action OnDeath;
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            PlayerLogic.Player player = other.gameObject.GetComponent<PlayerLogic.Player>();
            
            if (!player)
                return;
            
            OnDeath?.Invoke();
        }
    }
}