//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform target;
    private Vector3 offset;
    void Start()
    {
        //target = GameObject.FindGameObjectWithTag("Player").transform;
        offset = transform.position - target.position;
    }

    void Update()
    {
        //transform.position = target.position + offset;
        Vector3 newPos = new Vector3(transform.position.x, transform.position.y,offset.z + target.position.z);
        transform.position = newPos;
    }
}
