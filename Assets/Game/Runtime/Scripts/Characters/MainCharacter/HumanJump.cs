using Game.Runtime.Scripts.Characters.MainCharacter.Interfaces;
using Game.Runtime.Scripts.Config;
using UnityEngine;

namespace Game.Runtime.Scripts.Characters.MainCharacter
{
    public class HumanJump : IHumanJump
    {
        private readonly Rigidbody2D _rb;
        private readonly GameConfig _gameConfig;

        public HumanJump(
            Rigidbody2D rb,
            GameConfig gameConfig)
        {
            _rb = rb;
            _gameConfig = gameConfig;
        }

        public void Jump()
        {
            _rb.velocity = new Vector2(_rb.velocity.x, _gameConfig.JumpForce);
        }
    }
}