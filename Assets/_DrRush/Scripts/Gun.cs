using _DrRush.Input;
using _DrRush.Scripts.Runtime.Mini.Enemy;
using UnityEngine;

namespace _DrRush.Scripts
{
    public class Gun : MonoBehaviour
    {
        [SerializeField] private EnemyManager enemyManager;
        [SerializeField] private InputReader inputReader;
        [SerializeField] private BoxCollider gunTrigger;
    
        [SerializeField] private float range;
        [SerializeField] private float verticalRange;
        [SerializeField] private float damage;
        [SerializeField] private float fireRate;
        private float _nextTimeToFire;

        [SerializeField] private LayerMask raycastLayerMask;
    
        private void Start()
        {
            gunTrigger.size = new Vector3(1, verticalRange , range);
            gunTrigger.center = new Vector3(0, 0 , range * 0.5f );
            InputReader.ShootEvent += OnShoot;
        }

        private void OnDisable()
        {
            InputReader.ShootEvent -= OnShoot;
        }

        private void OnShoot()
        {
            Debug.Log("shoot input +");
        
            foreach (var enemy in enemyManager.enemiesInTrigger)
            {
                enemy.TakeDamage(damage);
                var dir = enemy.transform.position - transform.position;
                RaycastHit hit;
            if (Physics.Raycast(transform.position, dir, out hit, range * 1.5f, raycastLayerMask))
            {
                if (hit.transform == enemy.transform)
                {
                    Debug.Log("shoot +");
                    Debug.DrawRay(transform.position, dir);
                    Debug.Break();
                }
            }
            
                _nextTimeToFire = Time.time * fireRate;
            }
        }

        private void Update()
        {

        }

        private void OnTriggerEnter(Collider other)
        {
            Enemy enemy = other.transform.GetComponent<Enemy>();
            if (other.CompareTag("Enemy"))
            {
            
                enemyManager.AddEnemy(enemy);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            Enemy enemy = other.transform.GetComponent<Enemy>();
            if (other.CompareTag("Enemy"))
            {
                enemyManager.RemoveEnemy(enemy);
            }
        }
    }
}
