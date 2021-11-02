using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCircles : MonoBehaviour
{
    private float speed = 100f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Rotate();
    }

    void Rotate()
    {
        transform.Rotate(0, 0, speed * Time.deltaTime);
    }
}
