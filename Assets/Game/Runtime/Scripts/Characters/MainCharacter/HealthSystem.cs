using Game.Runtime.Scripts.Characters.MainCharacter.Interfaces;
using Game.Runtime.Scripts.MVP;

namespace Game.Runtime.Scripts.Characters.MainCharacter
{
    public class HealthSystem : IHumanHealthSystem
    {
        private readonly PlayerModel _playerModel;

        public HealthSystem(PlayerModel playerModel)
        {
            _playerModel = playerModel;
        }

        public void Add(int health)
        {
            _playerModel.Lives.Value += health;
        }

        public void Loss(int health)
        {
            _playerModel.Lives.Value -= health;
        }
    }
}