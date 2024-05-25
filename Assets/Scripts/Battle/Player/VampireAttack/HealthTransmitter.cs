using UnityEngine;

public class HealthTransmitter : MonoBehaviour
{
    [SerializeField] private PlayerVampireAttacker _attacker;
    [SerializeField] private Health _health;

    private void OnEnable()
    {
       _attacker.OnVampireAttackDamageDealing += VampireAttackDamageDealingHandler;
    }

    private void OnDisable()
    {
        _attacker.OnVampireAttackDamageDealing -= VampireAttackDamageDealingHandler;
    }

    private void VampireAttackDamageDealingHandler(float damage)
    {
        _health.TryHeal(damage);
    }
}
