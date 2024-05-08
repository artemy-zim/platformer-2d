using System;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public void TrySpawn(GameObject prefab)
    {
        if(prefab==null) 
            throw new ArgumentNullException(nameof(prefab));

        if(prefab.TryGetComponent(out ICollectible _))
            Instantiate(prefab, transform.position, Quaternion.identity, transform);
    }
}
