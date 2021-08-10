using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plTry : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rb;
    Vector3 jump;
    float force;
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("up"))
        {
            jump = new Vector3(1, 1, 0);
            force = 2;
            rb.AddForce(jump * force, ForceMode2D.Impulse);
        }
        if (Input.GetKeyDown("down"))
        {
            jump = new Vector3(2, 2, 0);
            force = 2;
            rb.AddForce(jump * force, ForceMode2D.Impulse);
        }
    }
}
