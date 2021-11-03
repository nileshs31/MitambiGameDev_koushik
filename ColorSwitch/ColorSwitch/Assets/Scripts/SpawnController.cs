using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    public GameObject CirclesPrefab;
    public Transform generateCirclePoint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CircleSpawn();
    }

    public void CircleSpawn()
    {
        if(transform.position.y < generateCirclePoint.position.y)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + 8f, transform.position.z);
            Instantiate(CirclesPrefab, transform.position, Quaternion.identity);
        }
    }
}
