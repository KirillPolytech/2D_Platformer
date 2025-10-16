using UnityEngine;
using Zenject;

namespace Game.Runtime.Scripts.Providers
{
    public class VFXProvider
    {
        public ParticleSystem Explosion;

        [Inject]
        public VFXProvider(ParticleSystem explosion)
        {
            Explosion = explosion;
        }
    }
}