using Game.Runtime.Scripts.Config;
using Zenject;

namespace Game.Runtime.Scripts.Enemies
{
    public class KillBox : Enemy
    {
        [Inject]
        public void Construct(EnemiesConfig enemiesConfig)
        {
            base.Construct(enemiesConfig, null);
            Damage = _enemiesConfig.KillBoxDamage;
        }

        public override void Die()
        {
        }
    }
}