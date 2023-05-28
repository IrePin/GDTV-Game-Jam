using System.Collections.Generic;
using _DrRush.Scripts.ShooterCrutch.Enemy;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public List<Enemy> enemiesInTrigger = new List<Enemy>();

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