using Game.Runtime.Scripts.Generic_FSM;

namespace Game.Runtime.Scripts.Enemies
{
    public class EnemyActiveState : IState
    {
        private readonly Enemy _enemy;

        public EnemyActiveState(Slime enemy)
        {
            _enemy = enemy;
        }

        public void Enter()
        {
        }

        public void Update()
        {
        }

        public void Exit()
        {
        }
    }
}