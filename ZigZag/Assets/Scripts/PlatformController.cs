using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    public GameObject[] platformPrefab;
    public GameObject currentPlatform;

    private static PlatformController instance;

    private Stack<GameObject> leftPlatform = new Stack<GameObject>();
    private Stack<GameObject> topPlatform = new Stack<GameObject>();

    public static PlatformController Instance 
    { 
       get
        {
            if(instance == null)
            {
                instance = GameObject.FindObjectOfType<PlatformController>();
            }
            return PlatformController.instance;
        }
    }

    void Start()
    {
        for(int i = 0; i < 10; i++)
        {
            SpawnPlatform();
        }
    }

    void Update()
    {
        
    }

    public void CreatePlatform(int amount)
    {

    }

    public void SpawnPlatform()
    {
        int randomPlatform = Random.Range(0, 2);
        currentPlatform = (GameObject)Instantiate(platformPrefab[randomPlatform],currentPlatform.transform.GetChild(0).transform.GetChild(randomPlatform ).position,Quaternion.identity);
        
    }
}
