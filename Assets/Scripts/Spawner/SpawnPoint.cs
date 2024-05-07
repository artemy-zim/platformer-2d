using System;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public void Spawn(GameObject gameObject)
    {
        if(gameObject==null) 
            throw new ArgumentNullException(nameof(gameObject));

        Instantiate(gameObject, transform.position, Quaternion.identity, transform);
    }
}
