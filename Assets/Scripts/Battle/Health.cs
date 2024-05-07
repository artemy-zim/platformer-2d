using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField, Range(0, float.MaxValue)] private float _maxHealth;

    private float _currentHealth;

    private void OnEnable()
    {
        _currentHealth = _maxHealth;
    }

    public void TryDealDamage(float damage)
    {
        if (damage < 0)
            throw new ArgumentOutOfRangeException(nameof(damage));

        _currentHealth -= damage;

        Validate();
    }

    public void TryHeal(float heal)
    {
        if(heal < 0)
            throw new ArgumentOutOfRangeException(nameof(heal));

        _currentHealth += heal;

        Validate();
    }

    private void Validate()
    {
        if(_currentHealth <= 0)
        {
            _currentHealth = 0;
            Destroy(gameObject);
        }

        if(_currentHealth > _maxHealth)
            _currentHealth = _maxHealth;

        Debug.Log($"{gameObject.name}: Health {_currentHealth}");
    }
}
