using UnityEngine;

public abstract class HealthView : MonoBehaviour
{
    [SerializeField] protected Health Health;

    protected float MaxHealth;

    private void OnEnable()
    {
        Health.OnHealthChanged += UpdateView;
    }

    private void Start()
    {
        MaxHealth = Health.MaxHealth;
        UpdateView();
    }

    private void OnDisable()
    {
        Health.OnHealthChanged -= UpdateView;
    }

    protected abstract void UpdateView();
}
