using UnityEngine;

public class EnemyAwareness : MonoBehaviour
{
    [SerializeField] private Material aggression;
    [SerializeField] private Transform playerTransform;
    public bool isAggressive = false;
    [SerializeField] private float detectionRadius; // distance within which to detect player

    [SerializeField] private MeshRenderer meshRenderer;

    private void Awake()
    {
        
    }

    private void Update()
    {
        var distance = Vector3.Distance(transform.position, playerTransform.position);

        if (distance < detectionRadius)
        {
            isAggressive = true;
        }
        else
        {
            isAggressive = false;
        }

        if (isAggressive)
        {
            meshRenderer.material = aggression;
        }
    }
}
