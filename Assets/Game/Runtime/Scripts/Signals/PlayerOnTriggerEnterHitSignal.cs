using UnityEngine;

namespace Game.Runtime.Scripts.EventBusThings
{
    public class PlayerOnTriggerEnterHitSignal
    {
        public Collider2D HitObject { get; }

        public PlayerOnTriggerEnterHitSignal(Collider2D hitObject)
        {
            HitObject = hitObject;
        }
    }
}