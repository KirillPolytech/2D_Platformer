using UnityEngine;

namespace Game.Runtime.Scripts.Providers
{
    public class PathsProvider
    {
        public Transform[] Paths { get; private set; }

        public PathsProvider(Transform[] paths)
        {
            Paths = paths;
        }
    }
}