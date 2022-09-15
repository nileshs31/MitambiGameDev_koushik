using System.Collections.Generic;
using UnityEngine;

public class Spawning : MonoBehaviour
{
    [SerializeField] private GameObject[] groundPrefabs;
    //[SerializeField] private GameObject obstaclesPrefabs;

    private List<GameObject> activeGround;
    //private List<GameObject> activeObstacles;

    private Transform playerTransform;
    #region Ground Region
    private float spawnZ;
    private float groundLength = 18f;
    private float safeGround = 15f;
    private int groundSpawn = 5;
    #endregion

    private void Start()
    {
        //ground
        activeGround = new List<GameObject>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        
        for(int i = 0; i < groundSpawn; i++)
        {
            SpawnGround();
        }
    }

    private void Update()
    {
        if (playerTransform.position.z - safeGround > (spawnZ - groundSpawn * groundLength))
        {
            SpawnGround();
            DeleteGround();
        }
    }

    private void SpawnGround()
    {
        GameObject spawn = Instantiate(groundPrefabs[0]) as GameObject;
        spawn.transform.SetParent(transform);
        spawn.transform.position = Vector3.forward * spawnZ;
        spawnZ += groundLength;
        activeGround.Add(spawn);

    }

    private void DeleteGround()
    {
        Destroy(activeGround[0]);
        activeGround.RemoveAt(0);
    }
}
