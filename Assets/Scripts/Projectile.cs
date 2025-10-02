using System;
using UnityEngine;

namespace Pinball
{
    [RequireComponent(typeof(Rigidbody))]
    public class Projectile : MonoBehaviour
    {
        [SerializeField]
        private Rigidbody rigidBody;
        [SerializeField]
        private ParticleSystem onCollideParticles;

        // we get a collision when the projectile is spawned,
        // so ignore the first for now
        private bool ignoreFirstCollision = true;

        public Rigidbody Rigidbody => rigidBody;

        private void OnValidate()
        {
            rigidBody = GetComponent<Rigidbody>();
        }

        private void OnCollisionEnter(Collision other)
        {
            if (ignoreFirstCollision)
            {
                ignoreFirstCollision = false;
                return;
            }
            
            onCollideParticles.Play();
        }
    }
}