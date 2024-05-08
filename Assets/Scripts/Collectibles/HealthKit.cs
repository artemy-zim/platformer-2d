using UnityEngine;

public class HealthKit : MonoBehaviour, ICollectible
{
    [SerializeField] private float _healAmount;

    public void Collect(Player player)
    {
        if(player.TryGetComponent(out Health health))
        {
            health.TryHeal(_healAmount);
            Destroy(gameObject);
        }
    }
}
