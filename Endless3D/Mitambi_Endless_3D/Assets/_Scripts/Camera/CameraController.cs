//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform target;
    private Vector3 offset;
    void Start()
    {
        offset = transform.position - target.position;
    }

    void Update()
    {
        Vector3 newPos = new Vector3(transform.position.x, transform.position.y,offset.z + target.position.z);
        transform.position = newPos;
    }
}
