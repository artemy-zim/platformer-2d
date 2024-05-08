using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private List<SpawnPoint> _spawnPoints;
    [SerializeField] private GameObject _prefab;
    [SerializeField] private int _amount;

    private void OnValidate()
    {
        _amount = Mathf.Clamp(_amount, 0, _spawnPoints.Count);
    }

    private void Start()
    {
        ShuffleSpawnPoints();
        SpawnGameObjects();
    }

    private void ShuffleSpawnPoints()
    {
        SpawnPoint temporarySpawnPoint;
        int secondIndex;

        for(int i = 0; i < _spawnPoints.Count; i++)
        {
            secondIndex = Random.Range(0, i + 1);

            temporarySpawnPoint = _spawnPoints[i];
            _spawnPoints[i] = _spawnPoints[secondIndex];
            _spawnPoints[secondIndex] = temporarySpawnPoint;
        }
    }

    private void SpawnGameObjects()
    {
        for (int i = 0; i < _amount; i++)
            _spawnPoints[i].TrySpawn(_prefab);
    }
}
