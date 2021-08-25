using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathSpawn : MonoBehaviour
{

    public float waitTime;
    public GameObject[]    obstacles;
    public GameObject powerInfinitePath;
    //public GameObject infinitepath;

    public GameObject coin;
    int i;

    //powerups
    private void Start()
    {
        InvokeRepeating("PowerSpawn", 10f, 60f);
        InvokeRepeating("Coin",4f,2f);
        StartCoroutine(ground());
    }
    void FixedUpdate()
    {
        if (waitTime > 0.4f)
            waitTime -= 0.000007f;
    }

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

/*    public void InfinitePathActive()
    {
        StartCoroutine(InfinitePath());
    }

    IEnumerator InfinitePath()
    {
        yield return new WaitForSeconds(1f);
        Instantiate(infinitepath, new Vector3(infinitepath.transform.position.x, -1.85f, 0), Quaternion.identity);
        yield return new WaitForSeconds(15f);
    }
*/

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
