using UnityEngine;

public class HealthTransmitter : MonoBehaviour
{
    [SerializeField] private PlayerVampireAttacker _attacker;
    [SerializeField] private Health _health;

    private void Update()
    {
        TryTransfer();
    }

    private void TryTransfer()
    {
        if (_attacker.DamageDealt > 0)
            _health.TryHeal(_attacker.DamageDealt);
    }
}
