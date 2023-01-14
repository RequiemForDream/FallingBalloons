using Pool;
using UnityEngine;

namespace BalloonStaff
{
    public class ParticlePool : MonoBehaviour
    {
        [SerializeField] private int poolCount = 3;
        [SerializeField] private bool autoExpand = false;
        [SerializeField] private Particles ballonParticlePrefab;

        private PoolMono<Particles> pool;

        private void Awake()
        {
            pool = new PoolMono<Particles>(ballonParticlePrefab, poolCount, transform);
            pool.autoExpand = autoExpand;
            EventBus.OnParticleCreated += CreateEffect;
        }

        private void CreateEffect(Vector3 spawnPosition)
        {
            var position = new Vector3(spawnPosition.x, spawnPosition.y, spawnPosition.z);
            var ballonParticle = pool.GetFreeElement();
            ballonParticle.transform.position = position;
        }

        private void OnDestroy()
        {
            EventBus.OnParticleCreated -= CreateEffect;
        }
    }
}

