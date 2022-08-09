using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private int _health;

    public event UnityAction<int, int> HealthChanged;
    public int Health => _health;
    private int _currentHealth;
   

    private void Start()
    {
        _currentHealth = _health;
        HealthChanged?.Invoke(_health, _currentHealth);
    }

    public void Damage(int damage)
    {
        _health -= damage;
        HealthChanged?.Invoke(_health, _currentHealth);
    }

    public void Heal(int health)
    {
        _health += health;
        HealthChanged?.Invoke(_health, _currentHealth);
    }

}
