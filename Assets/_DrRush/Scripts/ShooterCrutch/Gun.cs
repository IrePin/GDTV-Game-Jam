using _DrRush.Input;
using _DrRush.Scripts.FMOD;
using FMODUnity;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private EnemyManager enemyManager;
    [SerializeField] private BoxCollider gunTrigger;
    [SerializeField] private GameObject muzzleFlash;
    [SerializeField] private Transform flashTransform;

    private float _distance;
    private const float Range = 50F;
    [SerializeField] private float verticalRange;
    [SerializeField] private float fireRate;
    [SerializeField] private float gunShotRadius;

    [SerializeField] private float damage;
    [SerializeField] private float smallDamage;
    private float _nextTimeToFire;

    [SerializeField] private LayerMask raycastLayerMask;
    [SerializeField] private LayerMask enemyLayerMask;


    [SerializeField] private EventReference pistolFire;

    private void Start()
    {
        gunTrigger.size = new Vector3(1, verticalRange, Range);
        gunTrigger.center = new Vector3(0, 4, Range * 0.5f);
        InputReader.ShootEvent += OnShoot;
    }

    private void OnDisable()
    {
        InputReader.ShootEvent -= OnShoot;
    }

    private void OnShoot()
    {
        if (_nextTimeToFire > Time.time)
        {
            return;
        }

        if (enemyManager == null || enemyManager.enemiesInTrigger == null)
        {
            return;
        }

        foreach (var enemy in enemyManager.enemiesInTrigger)
        {
            if (enemy == null)
            {
                continue;
            }

            Debug.Log("enemies");
            var dir = enemy.transform.position - transform.position;
            RaycastHit hitInfo;

            if (Physics.Raycast(this.transform.position, dir, out hitInfo, Range * 0.5f, raycastLayerMask) &&
                hitInfo.transform == enemy.transform)
            {
                _distance = Vector3.Distance(enemy.transform.position, transform.position);
                enemy.TakeDamage(_distance > Range * 0.5f ? smallDamage : damage);
            }
        }

        Instantiate(muzzleFlash, flashTransform.position, flashTransform.rotation);
        FmodAudioManager.Instance.PlayOneShot(pistolFire, transform.position);
        _nextTimeToFire = Time.time + 1 / fireRate;
    }

    private void OnTriggerEnter(Collider other)
    {
        HandleEnemyTrigger(other, enemyManager.AddEnemy);
    }

    private void OnTriggerExit(Collider other)
    {
        HandleEnemyTrigger(other, enemyManager.RemoveEnemy);
    }

    private void HandleEnemyTrigger(Collider other, System.Action<Enemy> action)
    {
        if (other.CompareTag("Enemy"))
        {
            Enemy enemy = other.GetComponent<Enemy>();
            if (enemy != null)
            {
                action?.Invoke(enemy);
            }
        }
    }
}