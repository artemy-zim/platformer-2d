using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField, Range(0, float.MaxValue)] private float _maxHealth;

    private float _currentHealth;

    public float CurrentHealth => _currentHealth;
    public float MaxHealth => _maxHealth;

    public event Action OnHealthChanged;

    private void OnEnable()
    {
        _currentHealth = _maxHealth;
    }

    public void TryDealDamage(float damage)
    {
        if (damage < 0)
            throw new ArgumentOutOfRangeException(nameof(damage));

        ApplyHealthChange(-damage);
    }

    public void TryHeal(float heal)
    {
        if (heal < 0)
            throw new ArgumentOutOfRangeException(nameof(heal));

        ApplyHealthChange(heal);
    }

    private void ApplyHealthChange(float amount)
    {
        _currentHealth += amount;
        Validate();
        OnHealthChanged?.Invoke();
    }

    private void Validate()
    {
        if (_currentHealth <= 0)
        {
            _currentHealth = 0;
            Destroy(gameObject);
        }

        if (_currentHealth > _maxHealth)
            _currentHealth = _maxHealth;
    }
}
