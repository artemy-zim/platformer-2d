using System;
using UnityEngine;

public class CooldownCounter : MonoBehaviour
{
    [SerializeField] private PlayerVampireAttacker _attacker;
    [SerializeField] private float _cooldown;

    private float _lastAttackTime;

    public float CooldownLeft => _cooldown - (Time.time - _lastAttackTime);

    public event Action OnCooldownCounterStarted;

    private void Awake()
    {
        _lastAttackTime -= _cooldown;
    }

    private void OnEnable()
    {
        _attacker.OnVampireAttackStopped += VampireAttackStopHandler;
    }

    private void OnDisable()
    {
        _attacker.OnVampireAttackStopped -= VampireAttackStopHandler;
    }

    private void VampireAttackStopHandler()
    {
        _lastAttackTime = Time.time;

        OnCooldownCounterStarted?.Invoke();
    }
}
