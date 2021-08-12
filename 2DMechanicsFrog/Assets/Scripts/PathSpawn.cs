using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathSpawn : MonoBehaviour
{
    public GameObject obstacles;
    public GameObject powerInfinitePath;
   /* private bool stopSpawning = false;
    private bool isMoving = true;*/

    //powerups
    private void Start()
    {
        InvokeRepeating("Ground", 1f, 1.2f);
        
        InvokeRepeating("PowerSpawn", 50f, 60f);


    }
    private void FixedUpdate()
    {
    }
    void Ground()
    {
        if (!GameManager.Instance.gameOver)
            Instantiate(obstacles, new Vector3(obstacles.transform.position.x, -1.5f, 0), Quaternion.identity);   
    }

    void PowerSpawn()
    {
        if(!GameManager.Instance.gameOver)
            Instantiate(powerInfinitePath, new Vector3( 3.5f,0,0), Quaternion.identity);
    }

    void Coin()
    {

    }


}
