using UnityEngine;

namespace Game.Runtime.Scripts.EventBusThings
{
    public class PlayerOnColliderEnterHitSignal
    {
        public Collision2D HitObject { get; }

        public PlayerOnColliderEnterHitSignal(Collision2D hitObject)
        {
            HitObject = hitObject;
        }
    }
}