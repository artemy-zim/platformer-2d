using UnityEngine;

public class HealthKit : MonoBehaviour, ICollectible
{
    [SerializeField] private float _healAmount;

    public void Collect(Player player)
    {
        player.GetComponent<Health>().TryHeal(_healAmount);

        Destroy(gameObject);
    }
}
