using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilesController : MonoBehaviour
{
    [SerializeField] Material tileMaterial;
    bool mouseover;

    [SerializeField] Color startColor;
    [SerializeField] Color mouseOverColor;

    private void Start()
    {
       
    }

    void Update()
    {
        transform.Translate(Vector3.back * 5f * Time.deltaTime);
    }

    void OnMouseEnter()
    {
        mouseover = true;
        GetComponent<Renderer>().material.SetColor("_Color", mouseOverColor);
    }

    void OnMouseExit()
    {
        mouseover = false;
        GetComponent<Renderer>().material.SetColor("_Color", startColor);
    }
}
