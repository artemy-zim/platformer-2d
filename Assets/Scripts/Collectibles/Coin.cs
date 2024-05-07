using UnityEngine;

public class Coin : MonoBehaviour, ICollectible
{
    public void Collect(Player _)
    {
        Destroy(gameObject);
    }
}
