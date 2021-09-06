using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathSpawn : MonoBehaviour
{

    public float waitTime;
    private int i;
    public float ObjectWidth;
    public GameObject[] obstacles;
    public GameObject InfinitePathsPowerup;
    public GameObject coin;
    public GameObject infinitepath;

    public bool powerUpActive = false;

    private void Start()
    {
        InvokeRepeating("PowerSpawn", 10f, 20f); 
        InvokeRepeating("Coin", 4f, 2f);
        StartCoroutine(ground());
    } 
    void FixedUpdate()
    {
       /* if (waitTime > 0.4f)
            waitTime -= 0.000007f;*/
    }


    public IEnumerator ground()
    {
        while (!powerUpActive)
        {
            spawnground();
            yield return new WaitForSeconds(1.5f);
        }
    }

    public void InfinitePath()
    {
        powerUpActive = true;
        StartCoroutine(InfinitepathOff());
        Instantiate(infinitepath, new Vector3(infinitepath.transform.position.x, -1.2f, 0), Quaternion.identity);
    }

    public IEnumerator InfinitepathOff()
    {
        Debug.Log("path");
        yield return new WaitForSeconds(0.6f);
        powerUpActive = false;
    }

    public void spawnground()
    {
        //if (!GameManager.Instance.gameOver)
        {
            i = Random.Range(0,obstacles.Length);
            Instantiate(obstacles[i],new Vector3(transform.position.x + ObjectWidth,transform.position.y,transform.position.z),Quaternion.identity);
        }
/*
        transform.position = new Vector3(transform.position.x + ObjectWidth, transform.position.y, transform.position.z);
        GameObject newGameObject = obstacles[Random.Range(0, obstacles.Length)];
        Instantiate(newGameObject, transform.position, transform.rotation);*/
    }

    void PowerSpawn()
    {
        //if(!GameManager.Instance.gameOver)
            Instantiate(InfinitePathsPowerup, new Vector3( 3.5f,0,0), Quaternion.identity);
    }

    void Coin()
    {
        //if (!GameManager.Instance.gameOver)
            Instantiate(coin, new Vector3(3.5f, -0.4f, 0), Quaternion.identity);
    }

   
}
