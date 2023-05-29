using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private EnemyManager enemyManager;
    [SerializeField] private float enemyHealth;
    [SerializeField] private GameObject damageTakeEffectPrefab;
    [SerializeField] private Animator spriteAnim;
    private AngleToPlayer _angleToPlayer;
    private static readonly int SpriteRotation = Animator.StringToHash("SpriteRotation");

    public float attackRange;
    private bool attacking;

    void Start()
    {
        _angleToPlayer = GetComponent<AngleToPlayer>();
    }

    private void Update()
    {
        spriteAnim.SetFloat(SpriteRotation, _angleToPlayer.lastIndex);
        if (enemyHealth <= 0)
        {
            Instantiate(damageTakeEffectPrefab, transform.position, transform.rotation);
            enemyManager.RemoveEnemy(this);
            Destroy(gameObject);
        }
    }

    public void TakeDamage(float damage)
    {
        enemyHealth -= damage;
    }
}