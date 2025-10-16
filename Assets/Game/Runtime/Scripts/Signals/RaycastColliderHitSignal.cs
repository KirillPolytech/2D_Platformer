using UnityEngine;

namespace Game.Runtime.Scripts.EventBusThings
{
    public class RaycastColliderHitSignal
    {
        public Collider2D HitObject { get; }

        public RaycastColliderHitSignal(Collider2D hitObject)
        {
            HitObject = hitObject;
        }
    }
}