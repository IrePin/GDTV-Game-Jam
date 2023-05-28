using UnityEngine;

namespace _DrRush.Scripts.ShooterCrutch.Enemy
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private EnemyManager enemyManager;
        [SerializeField] private float enemyHealth;
        [SerializeField] private GameObject damageTakeEffectPrefab;
        [SerializeField] private Animator spriteAnim;
        private AngleToPlayer _angleToPlayer;
        private static readonly int SpriteRotation = Animator.StringToHash("SpriteRotation");

        void Start()
        {
            _angleToPlayer = GetComponent<AngleToPlayer>();
        }

        private void Update()
        {
            spriteAnim.SetFloat(SpriteRotation, _angleToPlayer.lastIndex);
            if (enemyHealth <= 0)
            {
                enemyManager.RemoveEnemy(this);
                Destroy(gameObject);
            }
        }

        public void TakeDamage(float damage)
        {
            Instantiate(damageTakeEffectPrefab, transform.position, transform.rotation);
            enemyHealth -= damage;
        }
    }
}