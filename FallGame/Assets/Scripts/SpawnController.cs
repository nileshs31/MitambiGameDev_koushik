using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    [SerializeField] GameObject platformPrefab, spikePlatformPrefab, crackPlatformPrefab, starPrefab;
    [SerializeField] GameObject[] movingPlatforms;

    [SerializeField] float platformSpawnTime = 1.5f,currentPlatformSpawnTime;
    private int platformSpawnCount;

    private float minX = -2f, maxX = 2f;

    
    // Start is called before the first frame update
    void Awake()
    {
        currentPlatformSpawnTime = platformSpawnTime;
    }

    // Update is called once per frame
    void Update()
    {
        SpawnPlatforms();
    }

    private void SpawnPlatforms()
    {
        currentPlatformSpawnTime += Time.deltaTime;

        if (currentPlatformSpawnTime >= platformSpawnTime) {
            platformSpawnCount++;
            Vector3 temp = transform.position;
            temp.x = Random.Range(minX, maxX);
            GameObject newPlatform = null;
            GameObject star = null;
            if (platformSpawnCount < 2) { 
                newPlatform = Instantiate(platformPrefab,temp,Quaternion.identity); 
            }else if(platformSpawnCount == 2) {
                if (Random.Range(0, 2) > 0) { 
                newPlatform = Instantiate(platformPrefab,temp,Quaternion.identity);
                }
                else { 
                    newPlatform = Instantiate(movingPlatforms[Random.Range(0,movingPlatforms.Length)],temp,Quaternion.identity);
                }
            }else if(platformSpawnCount == 3){
                if(Random.Range(0,2) > 0){
                    newPlatform = Instantiate(platformPrefab,temp,Quaternion.identity);
                }else{
                    newPlatform = Instantiate(spikePlatformPrefab,temp,Quaternion.identity);
                }
            }else if(platformSpawnCount == 4){
                if(Random.Range(0,2) > 0){
                    newPlatform = Instantiate(platformPrefab,temp,Quaternion.identity);
                }else{
                    newPlatform = Instantiate(crackPlatformPrefab,temp,Quaternion.identity);
                }
            }else if(platformSpawnCount == 5){
                star = Instantiate(starPrefab,temp,Quaternion.identity);
                platformSpawnCount = 0;
            }
            if(newPlatform)
                 newPlatform.transform.parent = transform;
            
            currentPlatformSpawnTime = 0f;
        }
    }
}
