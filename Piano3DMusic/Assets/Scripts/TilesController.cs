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
    }

    void Update()
    {
        transform.Translate(5f * Time.deltaTime * Vector3.back);
    }

    private void OnMouseDown()
    { 
        if (gameObject.transform.position.z < -8.3f && gameObject.transform.position.z >= -18.8f)
        {
            if (transform.position.z < -8.3f && transform.position.z > -12.3f)
            {
                TooEarly();
            }
            else if(transform.position.z < -14.6f )
            {
                TooLate();
            }
            else
            {
                Perfect();
            }
        }
    }

    private void TooEarly()
    {
        //GetComponent<Renderer>().material.SetColor("_Color", elColor[0]);
    }

    private void TooLate()
    { 
        //GetComponent<Renderer>().material.SetColor("_Color", elColor[1]);
    }

    private void Perfect()
    {
        GetComponent<Renderer>().material.SetColor("_Color", clickColor);
        onClick = false;
    }
}
