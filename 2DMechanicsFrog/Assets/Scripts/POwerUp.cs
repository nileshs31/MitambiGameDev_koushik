using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class POwerUp : MonoBehaviour
{
    public float speed = 2f;
    public ObjectGen spawnManager;

    private void Start()
    {
        spawnManager = FindObjectOfType<ObjectGen>();
    }

    private void Update()
    {
        //transform.Translate(Vector3.left * speed * Time.deltaTime);
        if(transform.position.x < -2.5)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log("Booster Activated");
            spawnManager.InfiniteGround();
        }
        Destroy(this.gameObject);
    }
}
