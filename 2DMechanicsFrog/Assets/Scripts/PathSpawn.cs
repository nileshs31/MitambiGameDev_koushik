using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathSpawn : MonoBehaviour
{
    public GameObject obstacles;
    private bool stopSpawning = false;

    private bool isMoving = true;
    //powerups
    public GameObject powerInfinitePath;
    private void Start()
    {
        InvokeRepeating("Ground", 1f, 1.2f);
        // StartCoroutine(spawnInfinitePower());
        InvokeRepeating("PowerSpawn", 10f, 10f);
    }
    private void FixedUpdate()
    {
    }
    void Ground()
    {
        if (!GameManager.Instance.gameOver)
            Instantiate(obstacles, new Vector3(obstacles.transform.position.x, -1.5f, 0), Quaternion.identity);   
    }

   /* IEnumerator spawnInfinitePower()
    {   //start
        yield return new WaitForSeconds(5f);
        Instantiate(powerInfinitePath, new Vector3( 3.5f,0,0), Quaternion.identity);
        yield return new WaitForSeconds(10f);
    }*/

    void PowerSpawn()
    {
        Instantiate(powerInfinitePath, new Vector3( 3.5f,0,0), Quaternion.identity);
    }



}
