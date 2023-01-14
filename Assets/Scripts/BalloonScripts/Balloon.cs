using UnityEngine;

namespace BalloonStaff
{
    [RequireComponent(typeof(Collider2D))]
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(SpriteRenderer))]
    public class Balloon : MonoBehaviour
    {
        [SerializeField] private BalloonInfo balloonInfo;

        private BalloonDestruction balloonDestruction;
        private BalloonMotion balloonMotion;              
        private new Rigidbody2D rigidbody2D;
        private SpriteRenderer spriteRenderer;

        private void Awake()
        {
            EventBus.OnLosed += Deactivate;
        }

        private void Start()
        {
            rigidbody2D = GetComponent<Rigidbody2D>();
            balloonDestruction = GetComponent<BalloonDestruction>();
            balloonMotion = GetComponent<BalloonMotion>();           
            spriteRenderer = GetComponent<SpriteRenderer>();
            spriteRenderer.color = balloonInfo.color;            
        }

        private void FixedUpdate()
        {
            balloonMotion.Move(rigidbody2D, balloonInfo.velocity);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.layer == 8)
            {
                balloonDestruction.FallDestruction(balloonInfo.reward, balloonInfo.damage, balloonInfo.type);               
                gameObject.SetActive(false);
            }
        }

        private void OnMouseDown()
        {
            balloonDestruction.PlayerDestruction(balloonInfo.reward, balloonInfo.damage, balloonInfo.type);
            EventBus.CreateParticle(gameObject.transform.position);
            EventBus.SendBalloonPoped();
            gameObject.SetActive(false);
        }

        private void Deactivate()
        {
            gameObject.SetActive(false);
        }

        private void OnDestroy()
        {
            EventBus.OnLosed -= Deactivate;
        }
    }
}

