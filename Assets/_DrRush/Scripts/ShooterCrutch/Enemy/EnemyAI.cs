using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private EnemyAwareness enemyAwareness;
    [SerializeField] private Transform playerTransform;
    [SerializeField] private NavMeshAgent navMeshAgent;

    private void Update()
    {
        if (enemyAwareness.isAggressive)
        {
            navMeshAgent.SetDestination(playerTransform.position);
        }
        else
        {
            navMeshAgent.SetDestination(transform.position);  
        }
    }
}
