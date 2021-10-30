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
    GameObject star = null;

    private void Start()
    {
        InvokeRepeating("Stars",10f,15f);
    }
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
        currentPlatformSpawnTime += (Time.deltaTime);

        if (currentPlatformSpawnTime >= platformSpawnTime) {
            platformSpawnCount++;
            Vector3 temp = transform.position;
            temp.x = Random.Range(minX, maxX);
            GameObject newPlatform = null;
            if (platformSpawnCount < 1) { 
                newPlatform = Instantiate(platformPrefab,temp,Quaternion.identity); 
            }else if(platformSpawnCount == 1) {
                if (Random.Range(0, 2) > 0) { 
                newPlatform = Instantiate(platformPrefab,temp,Quaternion.identity);
                }
                else { 
                    newPlatform = Instantiate(movingPlatforms[Random.Range(0,movingPlatforms.Length)],temp,Quaternion.identity);
                }
            }else if(platformSpawnCount == 2){
                if(Random.Range(0,2) > 0){
                    newPlatform = Instantiate(platformPrefab,temp,Quaternion.identity);
                }else{
                    newPlatform = Instantiate(spikePlatformPrefab,temp,Quaternion.identity);
                }
            }else if(platformSpawnCount == 3){
                if(Random.Range(0,2) > 0){
                    newPlatform = Instantiate(platformPrefab,temp,Quaternion.identity);
                }else{
                    newPlatform = Instantiate(crackPlatformPrefab,temp,Quaternion.identity);
                }
                platformSpawnCount = 0;
            }
            /*else if(platformSpawnCount == 4){

            }*/
            if (newPlatform)
                 newPlatform.transform.parent = transform;
            
            currentPlatformSpawnTime = 0f;
        }
    }

    public void Stars()
    {
        Vector3 temp = transform.position;
        temp.x = Random.Range(minX, maxX);
        star = Instantiate(starPrefab, temp, Quaternion.identity);
    }
}
