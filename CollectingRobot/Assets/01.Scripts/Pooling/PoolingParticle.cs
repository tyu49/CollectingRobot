using System.Collections;
using UnityEngine;

namespace _01.Scripts.Pooling
{
    public class PoolingParticle : PoolableItemAbstract
    {
        [SerializeField] private float disableDelay;
        [SerializeField] private ParticleSystem myParticle;

        private WaitForSeconds DisableDelay => new WaitForSeconds(disableDelay);
        public override void Pop(Vector3 position)
        {
            transform.position = position;
            myParticle.Play();
        }

        public override void Push()
        {
            base.Push();
        }

        private IEnumerator PushDelayCo()
        {
            yield return DisableDelay;
            Push();
        }
    }
}