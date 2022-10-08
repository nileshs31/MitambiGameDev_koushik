//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class GroundObstacle : MonoBehaviour
{
    [SerializeField] private GameObject[] obstaclesPrefabs; 
    //powerup 
    void Start()
    {
        SpawnObstacles();
    }

    private void SpawnObstacles()
    {
        int obstacleSpawnIdx = Random.Range(2, 5);
        Transform spawnPoint = transform.GetChild(obstacleSpawnIdx).transform;
        Instantiate(obstaclesPrefabs[Random.Range(0,obstaclesPrefabs.Length)], spawnPoint.position, Quaternion.identity, transform);
    }

    private void SpawnPowerUps()
    {
        //create a time which will start automatically at start of the game
        //start spawning after a player progress with score
    }
}
