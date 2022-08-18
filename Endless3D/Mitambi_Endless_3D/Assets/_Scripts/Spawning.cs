using System.Collections.Generic;
using UnityEngine;

public class Spawning : MonoBehaviour
{
    [SerializeField] private GameObject[] groundPrefabs;
    [SerializeField] private GameObject obstaclesPrefabs;

    private List<GameObject> activeGround;
    private List<GameObject> activeObstacles;

    private Transform playerTransform;
    private float spawnZ;
    private float groundLength = 18f;
    private float safeGround = 15f;
    private int groundSpawn = 5;

    private void Start()
    {
        //ground
        activeGround = new List<GameObject>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        
        for(int i = 0; i < groundSpawn; i++)
        {
            SpawnGround();
        }

        //SpawnObstacles();

        //obstacles
        //int newnumberOfObstacles = (int)Random.Range(numberOfObstacles.x, numberOfObstacles.y);
        //for (int i = 0; i < newnumberOfObstacles; i++)
        //{
        //    obstacles.Add(Instantiate(obstaclesPrefabs[Random.Range(0, obstaclesPrefabs.Length)], transform));
        //    obstacles[i].SetActive(false);
        //}
        //SpawnObstacles();
    }

    private void Update()
    {
        if (playerTransform.position.z - safeGround > (spawnZ - groundSpawn * groundLength))
        {
            SpawnGround();
            DeleteGround();
        }
        //if(playerTransform.position.z > groundSpawn * groundLength)
        //{
        //    //SpawnObstacles();
        //}
    }

    private void SpawnGround()
    {
        //SpawnObstacles();
        GameObject spawn = Instantiate(groundPrefabs[0]) as GameObject;
        spawn.transform.SetParent(transform);
        spawn.transform.position = Vector3.forward * spawnZ;
        spawnZ += groundLength;
        activeGround.Add(spawn);

        //SpawnObstacles();
    }

    private void DeleteGround()
    {
        Destroy(activeGround[0]);
        activeGround.RemoveAt(0);
    }

    private void SpawnObstacles()
    {
        //for (int i = 0; i < obstacles.Count; i++)
        //{
        //    float posZmin = (18f / obstacles.Count) + (18f / obstacles.Count) * i;
        //    float posZmax = (18f / obstacles.Count) + (18f / obstacles.Count) * (i + 1);
        //    obstacles[i].transform.localPosition = new Vector3(0, 0, Random.Range(posZmin, posZmax));
        //    obstacles[i].SetActive(true);
        //}


        //GameObject spawnObj = Instantiate(obstaclesPrefabs[Random.Range(0, obstaclesPrefabs.Length)]) as GameObject;
        ////spawnObj.transform.SetParent(transform);
        //spawnObj.transform.position = Vector3.forward * spawnZ;
        //spawnZ += 9f;
        //obstacles.Add(spawnObj);
            
        //int obstacleIdx = Random.Range(3, 6);
        //Transform spawnPoint = transform.GetChild(obstacleIdx).transform;
        //spawnPoint.transform.position = Vector3.forward * spawnZ;
        //spawnZ += 5f;
        //Instantiate(obstaclesPrefabs, spawnPoint.position, Quaternion.identity, transform);
    }
}
