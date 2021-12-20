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

    public Stack<GameObject> LeftPlatform { get => leftPlatform; set => leftPlatform = value; }
    public Stack<GameObject> TopPlatform { get => topPlatform; set => topPlatform = value; }

    void Start()
    {
        CreatePlatform(20);
        for(int i = 0; i < 30; i++)
        {
            SpawnPlatform();
        }
    }
    public void CreatePlatform(int amount)
    {
        for(int i = 0; i < amount; i++)
        {
            leftPlatform.Push(Instantiate(platformPrefab[0]));
            topPlatform.Push(Instantiate(platformPrefab[1]));
            leftPlatform.Peek().SetActive (false);
            leftPlatform.Peek().name = "LeftPlatform";
            topPlatform.Peek().SetActive(false);
            topPlatform.Peek().name = "TopPlatform";
        }
    }

    public void SpawnPlatform()
    {
        if(leftPlatform.Count == 0 || topPlatform.Count == 0)
        {
            CreatePlatform(10);
        }

        int randomPlatformidx = Random.Range(0, 2);
        
        if(randomPlatformidx == 0)
        {
            GameObject temp = leftPlatform.Pop();
            temp.SetActive(true);
            temp.transform.position = currentPlatform.transform.GetChild(0).transform.GetChild(randomPlatformidx).position;
            currentPlatform = temp;
        }
        else if(randomPlatformidx == 1)
        {
            GameObject temp = topPlatform.Pop();
            temp.SetActive(true);
            temp.transform.position = currentPlatform.transform.GetChild(0).transform.GetChild(randomPlatformidx).position;
            currentPlatform = temp;

        }

        int spawnPickup = Random.Range(0, 10);
        if (spawnPickup == 0)
        {
            currentPlatform.transform.GetChild(1).gameObject.SetActive(true);
        }
    }
}
