using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Sprite playerAfterDeath;
    [SerializeField] GameController gameController;
    private Rigidbody2D rb;
    [SerializeField] float playerSpeed = 2f;
    // private int coins;
    bool isair = false;
    public Sprite[] playerExpression;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (Input.GetMouseButton(0) && Input.mousePosition.x < Screen.width / 2)
        {
            LeftMovement();
        }
        else if (Input.GetMouseButton(0) && Input.mousePosition.x > Screen.width / 2)
                {
                    RightMovement();
                }
        //inside screen
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -2.5f, 2.5f), transform.position.y, transform.position.z);
    }
    public void LeftMovement()
    {
        rb.velocity = new Vector2(-playerSpeed, rb.velocity.y);
       /* if (isair)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = playerExpression[1];
        }*/

    }
    private void RightMovement()
    {
        rb.velocity = new Vector2(playerSpeed, rb.velocity.y);
       /* if (isair)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = playerExpression[0];
        }*/
    }

    public void PlatformPlayerMove(float x)
    {
        rb.velocity = new Vector2(x, rb.velocity.y);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Kill")
        {
            GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>().ShowAddsPannel();
            //this.gameObject.GetComponent<SpriteRenderer>().sprite = playerAfterDeath;
        }

        if (other.tag == "Star")
        {
            Destroy(other.gameObject);
            gameController.StarsIncrement(1);
            Debug.Log("I point");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if(collision.gameObject.tag == "Platform")
        {
             if (Input.mousePosition.x < Screen.width/2)
             {
                this.gameObject.GetComponent<SpriteRenderer>().sprite = playerExpression[1];
             }
            else
            {
                this.gameObject.GetComponent<SpriteRenderer>().sprite = playerExpression[0];
            }
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform" || !isair)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = playerExpression[2];
        }
    }

}
