using System;
using Game.Runtime.Scripts.Characters.MainCharacter.Interfaces;
using Game.Runtime.Scripts.Config;
using UnityEngine;

namespace Game.Runtime.Scripts.Characters.MainCharacter
{
    public class HumanMovement : IHumanMovement
    {
        private readonly Rigidbody2D _rb;
        private readonly GameConfig _gameConfig;
        private readonly InputSystem_Actions _inputs;

        public HumanMovement(
            Rigidbody2D rb,
            GameConfig gameConfig,
            InputSystem_Actions inputs)
        {
            _rb = rb;
            _gameConfig = gameConfig;
            _inputs = inputs;
        }

        public void Move()
        {
            float value = _inputs.Player.Move.ReadValue<Vector2>().x * _gameConfig.Speed;

            _rb.velocity = new Vector3(value, _rb.velocity.y);
        }

        public void FixedMove()
        {
            throw new NotImplementedException();
        }
    }
}