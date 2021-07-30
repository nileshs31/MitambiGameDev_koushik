using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    public float moveSpeed = 0.8f;
    public float killPositionX = -5f;
    Transform selfTransform;

  
    // Start is called before the first frame update
    void Start()
    {
        selfTransform = transform;
    }

    // Update is called once per frame
    void Update()
    {
        selfTransform.position -= new Vector3(moveSpeed/2, 0);
        if (selfTransform.position.x < killPositionX)
        {
            Destroy(gameObject, 2f);
        }
    }

    private bool move;
    private Vector3 velocity;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            move = true;
            collision.collider.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        collision.collider.transform.SetParent(null);
    }

    private void FixedUpdate()
    {
        if (move)
            transform.position += (velocity *2f * Time.deltaTime);
    }


   
}
