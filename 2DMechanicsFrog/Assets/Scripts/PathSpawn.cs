using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathSpawn : MonoBehaviour
{

    public float waitTime;
    public GameObject[]    obstacles;
    public GameObject powerInfinitePath;
    public GameObject coin;
    int i;
    //public Transform spawngenerationPoint;

    /* private bool stopSpawning = false;
private bool isMoving = true;*/ 

    //powerups
    private void Start()
    {
        //InvokeRepeating("Ground", 2f, 2f); 
        InvokeRepeating("PowerSpawn", 10f, 60f);
        InvokeRepeating("Coin",4f,2f);
        StartCoroutine(ground());
    }
    void FixedUpdate()
    {
        if (waitTime > 0.4f)
            waitTime -= 0.000007f;

    }
    /*    void Ground()
        {
            if (!GameManager.Instance.gameOver)
            {

                GameObject newGameObject = obstacles[Random.Range(0, obstacles.Length)];
                Instantiate(newGameObject, new Vector3(transform.position.x, -1.5f, 0), Quaternion.identity);   
                *//*transform.position = new Vector3(transform.position.x,transform.position.y, 0);
                Instantiate(newGameObject, transform.position, Quaternion.identity);*//*
            }
        }*/

    public IEnumerator ground()
    {
        while (true)
        {
            spawnground();
            yield return new WaitForSeconds(waitTime+0.3f);
        }
    }

    public void spawnground()
    {
        i = Random.Range(0,obstacles.Length);
        Instantiate(obstacles[i],new Vector3(transform.position.x,transform.position.y,transform.position.z),Quaternion.identity);
    }
    void PowerSpawn()
    {
        if(!GameManager.Instance.gameOver)
            Instantiate(powerInfinitePath, new Vector3( 3.5f,0,0), Quaternion.identity);
    }

    void Coin()
    {
        if (!GameManager.Instance.gameOver)
            Instantiate(coin, new Vector3(3.5f, -1f, 0), Quaternion.identity);
    }


}
