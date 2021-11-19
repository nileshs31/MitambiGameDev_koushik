using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    SpriteRenderer sr;
    //GameController gc;
    public float jumpforce = 9f;
    string currentColor;

    public Color Blue;
    public Color Green;
    public Color Purple;
    public Color Pink;

    bool playerReady = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        rb.simulated = false;
        
        RandomColor();
    }

    void Update()
    {
        if (playerReady)
        {
            playerMovement();
        }
        
    }

    void playerMovement()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector2(0, 1 * jumpforce);
            rb.simulated = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "ColorChange")
        {
            RandomColor();
            Destroy(collision.gameObject);
            return;
        }
        else if (collision.tag == "Diamond")
        {
            //gc.DiamondIncrement(1); 
            Destroy(collision.gameObject);
            GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>().DiamondIncrement(1);
        }
        else if (collision.tag != currentColor || collision.tag == "KillPlane")
        {
            Debug.Log("GAME OVER!");
            GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>().ShowAddsPannel();
        }
    }

    void RandomColor()
    {

        int index = Random.Range(0, 4);

        switch (index)
        {
            case 0:
                currentColor = "Blue";
                sr.color = Blue;
                break;
            case 1:
                currentColor = "Green";
                sr.color = Green;
                break;
            case 2:
                currentColor = "Purple";
                sr.color = Purple;
                break;
            case 3:
                currentColor = "Pink";
                sr.color = Pink;
                break;
        }
    }
}
