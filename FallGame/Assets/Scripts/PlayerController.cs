using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    [SerializeField] GameController gameController;
    [SerializeField] float playerSpeed = 2f;
    
    AudioSource playerAS;
    bool isair = false;
    public Sprite[] playerExpression;


    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerAS = GetComponent<AudioSource>();
    }

    
    void FixedUpdate()
    {
        gameController.midgame = true;
        

        if (!EventSystem.current.IsPointerOverGameObject(0) && !EventSystem.current.IsPointerOverGameObject() && Input.GetMouseButton(0) && Input.mousePosition.x < Screen.width / 2)
        {
            LeftMovement();
        }
        else if (!EventSystem.current.IsPointerOverGameObject(0) && !EventSystem.current.IsPointerOverGameObject() && Input.GetMouseButton(0) && Input.mousePosition.x > Screen.width / 2)
        {
            RightMovement();
        }
        //inside screen
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -2.5f, 2.5f), transform.position.y, transform.position.z);
    }
    public void LeftMovement()
    {
        rb.velocity = new Vector2(-playerSpeed, rb.velocity.y);
        if (!isair)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = playerExpression[1];
        }

    }
    private void RightMovement()
    {
        rb.velocity = new Vector2(playerSpeed, rb.velocity.y);
        if (!isair)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = playerExpression[0];
        }
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
            playerAS.Play();
            Destroy(other.gameObject);
            gameController.StarsIncrement(1);
//            Debug.Log("I point");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if(collision.gameObject.tag == "Platform")
        {
            isair = false;
            this.gameObject.GetComponent<SpriteRenderer>().sprite = playerExpression[0];
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform" || !isair)
        {
            isair = true;
            this.gameObject.GetComponent<SpriteRenderer>().sprite = playerExpression[2];
        }
    }

}
