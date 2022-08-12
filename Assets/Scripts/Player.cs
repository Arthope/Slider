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
    private int _maxHealth = 100;
    private int _minHealth = 0;
   

    private void Start()
    {
        _currentHealth = _health;
        HealthChanged?.Invoke(_health, _currentHealth);
    }

    public void Damage(int damage)
    {
        _health -= damage;
       _health = Mathf.Clamp(_health , _minHealth, _maxHealth );
        HealthChanged?.Invoke(_health, _currentHealth);
    }

    public void Heal(int health)
    {
        _health += health;
       _health = Mathf.Clamp(_health, _minHealth, _maxHealth);
        HealthChanged?.Invoke(_health, _currentHealth);
    }

}
