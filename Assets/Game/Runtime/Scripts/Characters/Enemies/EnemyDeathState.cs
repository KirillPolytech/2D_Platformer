using Game.Runtime.Scripts.Generic_FSM;

namespace Game.Runtime.Scripts.Enemies
{
    public class EnemyDeathState : IState
    {
        private readonly Enemy _enemy;

        public EnemyDeathState(Enemy enemy)
        {
            _enemy = enemy;
        }

        public void Enter()
        {
            _enemy.Die();
        }

        public void Update()
        {
        }

        public void Exit()
        {
        }
    }
}