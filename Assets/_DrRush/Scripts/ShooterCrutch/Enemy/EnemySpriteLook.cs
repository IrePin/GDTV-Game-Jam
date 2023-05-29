using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpriteLook : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    private Transform _targetTransform;
    public bool canLookVertical;

    private void Start()
    {
        _targetTransform = playerTransform;
    }

    private void Update()
    {
        if (canLookVertical)
        {
           transform.LookAt(_targetTransform); 
        }
        else
        {
            Vector3 modifiedTarget = _targetTransform.position;
            modifiedTarget.y = transform.position.y;
            transform.LookAt(modifiedTarget); 
        }
        
    }
}
