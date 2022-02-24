using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TilesController : MonoBehaviour
{
    [SerializeField] Material tileMaterial;
    [SerializeField] Color clickColor;
    //early late color
    [SerializeField] Color[] elColor;

    bool onClick = false;
    private void Start()
    {
        onClick = true;
    }

    void Update()
    {
        transform.Translate(5f * Time.deltaTime * Vector3.back);
    }

    private void OnMouseDown()
    {
        if (onClick)
        {
            if (gameObject.transform.position.z < -13.3f && gameObject.transform.position.z > -14.6f)
            {
                Perfect();
            }
            else if (gameObject.transform.position.z > -13f)
            {
                TooEarly();
            }
            else if (gameObject.transform.position.z < -14.6f)
            {
                TooLate();
            }
        }
        onClick = false;
    }
/*
    private void OnMouseDrag()
    {
        if (onClick)
        {
            TapandHold();
        }
        onClick = false;
    }*/

    private void TooEarly()
    {
        GetComponent<Renderer>().material.SetColor("_Color", elColor[0]);
        Debug.Log("Too Early");
    }

    private void TooLate()
    {
        Debug.Log("Too Late");
        GetComponent<Renderer>().material.SetColor("_Color", elColor[1]);
    }

    private void Perfect()
    {
        Debug.Log("Too Perfect");
        GetComponent<Renderer>().material.SetColor("_Color", clickColor);
        // sound
    }

    private void TapandHold()
    {
        GetComponent<Renderer>().material.SetColor("_Color", Color.cyan);
    }
}
