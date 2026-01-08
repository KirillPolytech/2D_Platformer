namespace Game.Runtime.Scripts.Characters.MainCharacter.Interfaces
{
    public interface IHumanHealthSystem
    {
        public void Add(int health);
        public void Loss(int health);
    }
}