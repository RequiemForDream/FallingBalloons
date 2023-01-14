using UnityEngine;

namespace BalloonStaff
{
    [CreateAssetMenu(fileName = "BalloonInfo", menuName = "GamePlay/New balloon info")]
  
    public class BalloonInfo : ScriptableObject
    {
        [Header("Physical Stats")]
        [SerializeField] private float _velocity;
        public float velocity => this._velocity;


        [Header("Damagical Stats")]
        [SerializeField] private float _minDamage;
        [SerializeField] private float _maxDamage;      
        private float _damage => Random.Range(_minDamage, _maxDamage);
        public float damage => this._damage;


        [Header("Rewarding Stats")]
        [SerializeField] private int _minReward;
        [SerializeField] private int _maxReward;
        private int _reward => Random.Range(_minReward, _maxReward);
        public int reward => this._reward;


        [Header("Visual Stats")]
        [SerializeField] private Color[] colors;
        public Color color => colors[Random.Range(0, colors.Length)];       


        [Header("Balloon Types")]
        [SerializeField] private BalloonType _type;
        public BalloonType type => this._type;
    }
}


