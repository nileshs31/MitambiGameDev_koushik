using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    //private List<GameObject> circle;
    public GameObject CirclesPrefab;
    public GameObject colorChangePrefab;
    public Transform generateCirclePoint;
    public Transform generateColorChange;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        CircleSpawn();
        //colorChange();
    }

    public void CircleSpawn()
    {
        if(transform.position.y < generateCirclePoint.position.y)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + 8f, transform.position.z);

            GameObject newObject = Instantiate(CirclesPrefab,transform.position ,Quaternion.identity) as GameObject;
            float scale = Random.Range(0.7f, 1.5f);
            newObject.transform.localScale = new Vector3(scale,scale,0);
            newObject.SetActive(true);
        }
    }
    void colorChange()
    {
        if (transform.position.y < generateColorChange.position.y)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + 10f, transform.position.z);
            GameObject cobject =  Instantiate(colorChangePrefab, transform.position, Quaternion.identity);
            cobject.SetActive(true);
        }
    }

    

}
