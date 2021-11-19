using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    public GameObject CirclesPrefab;
    public GameObject colorChangePrefab;
    public Transform generateCirclePoint;

    // Update is called once per frame
    void Update()
    {
        CircleSpawn();
        //scolorchange();
    }

    public void CircleSpawn()
    {
        if (transform.position.y < generateCirclePoint.position.y)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + 8f, transform.position.z);

            GameObject newObject = Instantiate(CirclesPrefab, transform.position, Quaternion.identity) as GameObject;
            float scale = Random.Range(0.7f, 1.5f);
            newObject.transform.localScale = new Vector3(scale, scale, 0);
            newObject.SetActive(true);
        }
    }

    void colorchange()
    {
        if (transform.position.y < generateCirclePoint.position.y)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + 5f, transform.position.z);
            GameObject color = Instantiate(colorChangePrefab, transform.position, Quaternion.identity) as GameObject;
            color.SetActive(true);
        }
    }

}
