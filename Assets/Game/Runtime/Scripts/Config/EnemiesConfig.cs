using UnityEngine;

namespace Game.Runtime.Scripts.Config
{
    [CreateAssetMenu(fileName = "GameSettings", menuName = "Config/Enemies Config")]
    public class EnemiesConfig : ScriptableObject
    {
        public int SlimeDamage = 1;
        public float SlimeSpeed = 0.01f;
        public Vector2 OverlapBox;
        
        public int KillBoxDamage = int.MaxValue;
    }
}