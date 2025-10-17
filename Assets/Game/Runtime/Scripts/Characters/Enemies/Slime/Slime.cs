using Game.Runtime.Scripts.Config;
using Platformer.Mechanics;
using UnityEngine;
using Zenject;

namespace Game.Runtime.Scripts.Enemies
{
    public class Slime : Enemy, IWalkable
    {
        [SerializeField]
        private Transform overlapBoxPosition;

        private SlimeStateMachine _slimeStateMachine;
        private PatrolPath _patrolPath;

        private float _progress;
        private Transform _target;
        private Collider2D[] _colliders;
        private Rigidbody2D _rb;

        [Inject]
        public void Construct(EnemiesConfig enemiesConfig)
        {
            _patrolPath = GetComponent<PatrolPath>();
            Animator animator = GetComponent<Animator>();
            _colliders = GetComponentsInChildren<Collider2D>();
            EnemyDeathBox enemyDeathBox = GetComponentInChildren<EnemyDeathBox>();
            _rb = GetComponent<Rigidbody2D>();

            _slimeStateMachine = new SlimeStateMachine(this, animator, enemiesConfig, enemyDeathBox);

            base.Construct(enemiesConfig, _slimeStateMachine);
        }

        private void Start()
        {
            Damage = _enemiesConfig.SlimeDamage;
            _target = _patrolPath.Waypoints[0];
        }

        private void FixedUpdate()
        {
            _slimeStateMachine.UpdateState();
        }

        public void Walk()
        {
            transform.position =
                Vector3.MoveTowards(transform.position, _target.position, _enemiesConfig.SlimeSpeed);

            if (Vector3.Distance(transform.position, _target.position) < GlobalVariables.Threshold)
            {
                _target = _target == _patrolPath.Waypoints[0] ? _patrolPath.Waypoints[1] : _patrolPath.Waypoints[0];
            }
        }

        public void SetPosition(Transform position)
        {
            _rb.isKinematic = true;
            transform.position = position.position;
            _rb.isKinematic = false;
        }
        
        public void SetPosition(Vector3 position)
        {
            _rb.isKinematic = true;
            transform.position = position;
            _rb.isKinematic = false;
        }

        public override void Die()
        {
            foreach (var col in _colliders)
            {
                col.enabled = false;
            }
        }

        public void Reset()
        {
            foreach (Collider2D _collider in _colliders)
            {
                _collider.enabled = true;
            }
        }
    }
}