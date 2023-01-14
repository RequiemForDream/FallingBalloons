using UnityEngine;

namespace BalloonStaff
{
    public class Particles : MonoBehaviour
    {
        [SerializeField] private ParticleSystem particle;
        private Color[] colors = {Color.red, Color.green, Color.blue, Color.white, Color.yellow, Color.cyan};
        private Color color => colors[Random.Range(0, colors.Length)];

        private void Start()
        {
            Initialize(this.color);
        }

        private void Initialize(Color color)
        {
            var main = particle.main;
            main.startColor = color;
        }

        private void Update()
        {
            Deactivate(1);
        }

        private void Deactivate(float lifeTime)
        {            
            lifeTime -= Time.deltaTime;
            if (lifeTime < 0)
            {
                gameObject.SetActive(false);
            }
        }
    }   
}