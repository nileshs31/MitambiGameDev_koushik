using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Count : MonoBehaviour
{
    public int count = 0;
    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            count++;
        }
        Debug.Log(count);
    }
}
