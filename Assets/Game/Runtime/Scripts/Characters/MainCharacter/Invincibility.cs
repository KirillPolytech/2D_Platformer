using UnityEngine;
using DG.Tweening;
using Game.Runtime.Scripts.Config;
using Zenject;

namespace Game.Runtime.Scripts
{
    public class Invincibility : IFixedTickable
    {
        private readonly GameConfig _gameConfig;

        public bool IsInvincible { get; private set; }

        private float _currentTime;
        private SpriteRenderer _spriteRenderer;
        private Color _initialColor;

        [Inject]
        public Invincibility(
            GameConfig gameConfig)
        {
            _gameConfig = gameConfig;
            
            Debug.Log("Hash" + GetHashCode());
        }

        public void FixedTick()
        {
            if (!IsInvincible)
                return;

            _currentTime += Time.fixedDeltaTime;

            if (_currentTime < _gameConfig.InvincibilityTime)
                return;

            _currentTime = 0;
            IsInvincible = false;
            _spriteRenderer.color = _initialColor;
        }

        public void Start(SpriteRenderer spriteRenderer)
        {
            _spriteRenderer = spriteRenderer;
            _initialColor = _spriteRenderer.color;
            IsInvincible = true;

            _spriteRenderer.DOColor(Color.white, _gameConfig.InvincibilityTime / _gameConfig.FlashingInvincibilityLoops)
                .SetLoops(_gameConfig.FlashingInvincibilityLoops, LoopType.Yoyo)
                .SetEase(Ease.Flash);
        }
    }
}