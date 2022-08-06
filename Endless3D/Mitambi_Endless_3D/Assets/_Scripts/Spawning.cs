using System.Collections.Generic;
using UnityEngine;

public class Spawning : MonoBehaviour
{
    [SerializeField] private GameObject[] groundPrefabs;

    private Transform playerTransform;
    private float spawnZ;
    private float groundLength = 18f;
    private float safeGround = 15f;
    private int groundSpawn = 5;
    private int groundLastPrefabIndex = 0;

    private List<GameObject> activeGround;

    private void Start()
    {
        activeGround = new List<GameObject>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        
        for(int i = 0; i < groundSpawn; i++)
        {
            //if(i<2) SpawnGround()
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
        //if(randomIndex == -1)
        //GameObject spawn = Instantiate(groundPrefabs[RandomPrefabIndex()]) as GameObject;

        GameObject spawn = Instantiate(groundPrefabs[0]) /*as GameObject*/;
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

    //private int RandomPrefabIndex()
    //{
    //    if (groundPrefabs.Length <= 1)
    //        return 0;

    //    int randomIndex = groundLastPrefabIndex;
    //    while (randomIndex == groundLastPrefabIndex)
    //    {
    //        randomIndex = Random.Range(0, groundPrefabs.Length);
    //    }

    //    groundLastPrefabIndex = randomIndex;
    //    return randomIndex;
    //}
}
