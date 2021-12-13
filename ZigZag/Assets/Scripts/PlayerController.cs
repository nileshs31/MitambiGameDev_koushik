using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    Vector3 dir;
    void Start()
    {
        dir = Vector3.zero;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if(dir == Vector3.forward)
            {
                dir = Vector3.left;
            }
            else
            {
                dir = Vector3.forward;
            }
        }
        float move = speed * Time.deltaTime;
        transform.Translate(dir * move);
    }
}
