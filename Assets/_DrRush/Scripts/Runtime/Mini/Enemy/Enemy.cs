using UnityEngine;

namespace _DrRush.Scripts.Runtime.Mini.Enemy
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private EnemyManager enemyManager;
        [SerializeField] private float enemyHealth;
        void Start()
        {
        
        }

        // Update is called once per frame
        private void Update()
        {
            if (enemyHealth <= 0)
            {
                enemyManager.RemoveEnemy(this);
                Destroy(gameObject);
            }
        }

        public void TakeDamage(float damage)
        {
            enemyHealth -= damage;
        }
    }
}
