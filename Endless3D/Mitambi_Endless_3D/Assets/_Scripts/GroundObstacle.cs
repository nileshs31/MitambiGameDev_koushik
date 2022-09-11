using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundObstacle : MonoBehaviour
{
    [SerializeField] private GameObject obstaclesPrefabs;
    
    void Start()
    {
        SpawnObstacles();
    }

    
    void Update()
    {
        
    }
    private void SpawnObstacles()
    {
        int obstacleSpawnIdx = Random.Range(2, 5);
        Transform spawnPoint = transform.GetChild(obstacleSpawnIdx).transform;
        Instantiate(obstaclesPrefabs, spawnPoint.position, Quaternion.identity, transform);

    }
}
