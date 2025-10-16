using UnityEngine;

namespace Platformer.Mechanics
{
    public class PatrolPath : MonoBehaviour
    {
        public Transform[] Waypoints { get; private set; }

        public void Initialize(Transform[] path)
        {
            Waypoints = path;
        }
    }
}