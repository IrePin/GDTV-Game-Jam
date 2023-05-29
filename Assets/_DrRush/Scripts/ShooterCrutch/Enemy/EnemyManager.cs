using System;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public List<Enemy> enemiesInTrigger = new List<Enemy>();

    private void Update()
    {
    
    }

    public void AddEnemy(Enemy enemy)
    {
        if (!enemiesInTrigger.Contains(enemy))
        {
            enemiesInTrigger.Add(enemy);
        }
    }

    public void RemoveEnemy(Enemy enemy)
    {
        enemiesInTrigger.Remove(enemy);
    }

    public bool IsEnemyInTrigger(Enemy enemy)
    {
        return enemiesInTrigger.Contains(enemy);
    }
}