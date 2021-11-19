using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCircles : MonoBehaviour
{
    private float speed = 100f;
    void Update()
    {
        Rotate();
    }

    void Rotate()
    {
        transform.Rotate(0, 0, speed * Time.deltaTime);
    }
}
