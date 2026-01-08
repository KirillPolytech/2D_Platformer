using System;
using Game.Runtime.Scripts.Characters.MainCharacter.Interfaces;
using UnityEngine;

namespace Game.Runtime.Scripts.Enemies
{
    public class EnemyDeathBox : MonoBehaviour, IExtraJump
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