using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathSpawn : MonoBehaviour
{
    public GameObject[] obstacles;
    public GameObject powerInfinitePath;
    public GameObject coin;
    public Transform spawngenerationPoint;

    /* private bool stopSpawning = false;
private bool isMoving = true;*/

    //powerups
    private void Start()
    {
        InvokeRepeating("Ground", 0.5f, 2f); 
        InvokeRepeating("PowerSpawn", 50f, 60f);
        InvokeRepeating("Coin",4f,2f);
    }

    void Ground()
    {
        if (!GameManager.Instance.gameOver)
        {
            //Instantiate(obstacles, new Vector3(obstacles.transform.position.x, -1.5f, 0), Quaternion.identity);   
            transform.position = new Vector3(transform.position.x  , 0.14f, 0);
            GameObject newGameObject = obstacles[Random.Range(0, obstacles.Length)];
            Instantiate(newGameObject, transform.position, Quaternion.identity);
        }
    }

    void PowerSpawn()
    {
        if(!GameManager.Instance.gameOver)
            Instantiate(powerInfinitePath, new Vector3( 3.5f,0,0), Quaternion.identity);
    }

    void Coin()
    {
        if (!GameManager.Instance.gameOver)
            Instantiate(coin, new Vector3(3.5f, 0, 0), Quaternion.identity);
    }


}
