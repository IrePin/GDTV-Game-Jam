using Unity.Mathematics;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private EnemyManager enemyManager;
    [SerializeField] private float enemyHealth;

    [SerializeField] private GameObject damageTakeEffectPrefab;

    void Start()
    {

    }

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
        Instantiate(damageTakeEffectPrefab, transform.position, transform.rotation);
        enemyHealth -= damage;
    }
}