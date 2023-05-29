using System;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth;
    private int _playerHealth;

    public int maxArmor;
    private int _playerArmor;

    private void Start()
    {
        _playerHealth = maxHealth;
        _playerArmor = maxArmor;
    }

    private void Update()
    {
        Debug.Log(_playerArmor);
        Debug.Log(_playerHealth);
    }

    public void UpdateDamage(int damage)
    {
        if (_playerArmor > 0)
        {
            int effectiveDamage = Math.Max(damage - _playerArmor, 0);
            _playerArmor = Math.Max(_playerArmor - damage, 0);
            _playerHealth = Math.Max(_playerHealth - effectiveDamage, 0);
        }
        else
        {
            _playerHealth = Math.Max(_playerHealth - damage, 0);
        }

        if (_playerHealth <= 0)
        {
            Debug.Log("Game over!");
            // You can add additional code here to end the game
        }
    }
}