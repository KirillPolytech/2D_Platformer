using UnityEngine;

namespace Game.Runtime.Scripts.Config
{
    [CreateAssetMenu(fileName = "GameSettings", menuName = "Config/Game Settings")]
    public class GameConfig : ScriptableObject
    {
        public float Speed = 1;
        public float MaxSpeed = 5;

        public float JumpForce = 1;
        public float JumpTicks = 10;
        
        public float SpawnDelay = 2;

        public Vector2 GroundCheckBox = new(0.5f, 0.2f);

        public int Lives;

        public float InvincibilityTime = 0.1f;
        public int FlashingInvincibilityLoops = 10;

        public string LivesText = "Lives:";
        public string ScoreText = "Score:";

        public LayerMask GroundLayer;
    }
}