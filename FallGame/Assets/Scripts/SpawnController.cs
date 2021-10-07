using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    [SerializeField] GameObject platformPrefab, spikePlatformPrefab, crackPlatformPrefab;
    [SerializeField] GameObject[] movingPlatforms;

    [SerializeField] float platformSpawnTime = 2f,currentPlatformSpawnTime;
    private int platformSpawnCount;

    private float minX = -2f, maxX = 2f;

    
    // Start is called before the first frame update
    void Start()
    {
        currentPlatformSpawnTime = platformSpawnTime;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnPlatforms()
    {
        currentPlatformSpawnTime += Time.deltaTime;

        if (currentPlatformSpawnTime >= platformSpawnTime) {
            platformSpawnCount++;
            Vector3 temp = transform.position;
            temp.x = Random.Range(minX, maxX);
            GameObject newPlatform = null;
            if (platformSpawnCount < 1) { 
                newPlatform = Instantiate(platformPrefab,temp,Quaternion.identity); 
            }else if(platformSpawnCount == 1) {
                if (Random.Range(0, 1) > 0) { 
                newPlatform = Instantiate(platformPrefab,temp,Quaternion.identity);
                }
                else { 

                }
            }
        }
    }
}
