using Game.Runtime.Scripts.Config;
using Game.Runtime.Scripts.Enemies;
using Game.Runtime.Scripts.EventBusThings;
using Game.Runtime.Scripts.MVP;
using Game.Runtime.Scripts.Player.PlayerFSM;
using UnityEngine;
using Zenject;

namespace Game.Runtime.Scripts.PlayerLogic
{
    public class Player : MonoBehaviour
    {
        [SerializeField]
        private Transform groundCheckPoint;

        public bool IsGrounded { get; private set; }
        public PlayerFSM StateMachine { get; private set; }

        private Animator _animator;
        private Rigidbody2D _rb;
        private SpriteRenderer _sprite;

        private InputSystem_Actions _inputs;
        private GameConfig _gameConfig;
        private SignalBus _signalBus;
        private Invincibility _invincibility;
        private PlayerModel _playerModel;

        [Inject]
        public void Construct(
            InputSystem_Actions inputs,
            GameConfig gameConfig,
            SignalBus signalBus,
            Invincibility invincibility,
            PlayerModel playerModel)
        {
            _inputs = inputs;
            _gameConfig = gameConfig;
            _signalBus = signalBus;
            _invincibility = invincibility;
            _playerModel = playerModel;
        }

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
            _animator = GetComponent<Animator>();
            _sprite = GetComponent<SpriteRenderer>();

            StateMachine = new PlayerFSM(_gameConfig, _inputs, _rb, _animator, this, _signalBus);
        }

        private void OnEnable()
        {
            _signalBus.Subscribe<PlayerOnColliderEnterHitSignal>(CheckHealthLoss);
            _signalBus.Subscribe<PlayerOnTriggerEnterHitSignal>(CheckJump);
        }

        private void OnDisable()
        {
            _signalBus.Unsubscribe<PlayerOnColliderEnterHitSignal>(CheckHealthLoss);
            _signalBus.Unsubscribe<PlayerOnTriggerEnterHitSignal>(CheckJump);
        }

        private void FixedUpdate()
        {
            StateMachine.UpdateState();

            IsGrounded = Physics2D.OverlapBox(
                groundCheckPoint.position,
                _gameConfig.GroundCheckBox,
                0f,
                _gameConfig.GroundLayer);
        }

        public void Move()
        {
            float value = _inputs.Player.Move.ReadValue<Vector2>().x * _gameConfig.Speed;

            _rb.velocity = new Vector3(value, _rb.velocity.y);
        }

        public void Jump()
        {
            _rb.velocity = new Vector2(_rb.velocity.x, _gameConfig.JumpForce);
        }

        public void SetPosition(Transform position)
        {
            _rb.isKinematic = true;

            transform.position = position.position;

            _rb.isKinematic = false;
        }

        private void CheckHealthLoss(PlayerOnColliderEnterHitSignal playerOnColliderEnterHitSignal)
        {
            GameObject enemy = playerOnColliderEnterHitSignal.HitObject?.gameObject;

            HandleHealthLoss(enemy);
        }

        private void CheckJump(PlayerOnTriggerEnterHitSignal playerOnColliderEnterHitSignal)
        {
            GameObject enemy = playerOnColliderEnterHitSignal.HitObject?.gameObject;

            HandleHealthLoss(enemy);
            HandleExtraJump(enemy);
        }

        private void HandleExtraJump(GameObject gameObj)
        {
            EnemyDeathBox _deathBox = gameObj?.GetComponent<EnemyDeathBox>();

            if (!_deathBox)
                return;

            StateMachine.Enter<JumpState>();
        }

        private void HandleHealthLoss(GameObject gameObj)
        {
            Enemy enemy = gameObj?.GetComponent<Enemy>();
            
            if (!enemy || _invincibility.IsInvincible)
                return;

            _invincibility.Start(_sprite);

            _playerModel.Lives.Value -= enemy.Damage;
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            _signalBus.Fire(new PlayerOnColliderEnterHitSignal(other));
        }

        private void OnCollisionStay2D(Collision2D other)
        {
            _signalBus.Fire(new PlayerOnColliderEnterHitSignal(other));
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            _signalBus.Fire(new PlayerOnTriggerEnterHitSignal(other));
        }

        public void Reset()
        {
            _rb.velocity = Vector3.zero;
        }

        private void OnDrawGizmos()
        {
            if (groundCheckPoint == null || _gameConfig == null)
                return;

            Gizmos.color = Color.green;
            Gizmos.DrawWireCube(groundCheckPoint.position,
                new Vector3(_gameConfig.GroundCheckBox.x, _gameConfig.GroundCheckBox.y, 0f));
        }
    }
}