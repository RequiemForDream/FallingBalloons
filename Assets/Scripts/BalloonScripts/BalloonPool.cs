using UnityEngine;
using System.Collections;
using BalloonStaff;

namespace Pool
{
    public class BalloonPool : MonoBehaviour
    {
        [Header("Spawn Stats")]
        [SerializeField] private float timeSpawn;
        [SerializeField] private int poolCount = 3;
        [SerializeField] private bool autoExpand = false;
        [SerializeField] private Balloon ballonPrefab;
        [Space(10)]

        [Header("Difficult Stats")]
        [SerializeField] private float timeToComplicate = 10f;       
        [SerializeField] private float maxDifficult;
        private float timeReseter;
        private bool isPlaying = true;

        private PoolMono<Balloon> pool;

        private void Awake()
        {
            pool = new PoolMono<Balloon>(ballonPrefab, poolCount, transform);
            pool.autoExpand = autoExpand;
            timeReseter = timeToComplicate;
        }

        private void Start()
        {
            StartCoroutine(SpawnBallons());
            EventBus.OnLosed += Lose;
        }

        private void Update()
        {
            Complicate();
        }

        private IEnumerator SpawnBallons()
        {
            while (isPlaying)
            {
                CreateBallon();
                yield return new WaitForSeconds(this.timeSpawn);
            }
        }

        private void CreateBallon()
        {
            var randomX = Random.Range(-2.5f, 2.5f);
            var y = 9;

            var spawnPosition = new Vector2(randomX, y);
            var ballon = pool.GetFreeElement();
            ballon.transform.position = spawnPosition;
        }

        private void Complicate()
        {
            timeToComplicate -= Time.deltaTime;
            if (timeToComplicate <= 0)
            {
                this.timeSpawn -= 0.1f;
                if (timeSpawn < maxDifficult)
                {
                    timeSpawn = maxDifficult;
                    return;
                }
                timeToComplicate = timeReseter;
            }
        }

        private void Lose()
        {
            isPlaying = false;          
        }

        private void OnDestroy()
        {
            EventBus.OnLosed -= Lose;
        }
    }
}


