using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

  [SerializeField] GameController gameController;
  private Rigidbody2D rb;
  [SerializeField] float playerSpeed = 2f;
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
    if (Input.GetMouseButton(0) && Input.mousePosition.x > Screen.width / 2)
    {
      RightMovement();
    }

    //inside screen
    transform.position = new Vector3(Mathf.Clamp(transform.position.x, -2.5f, 2.5f), transform.position.y, transform.position.z);
  }
  private void LeftMovement()
  {
    rb.velocity = new Vector2(-playerSpeed, rb.velocity.y);
  }
  private void RightMovement()
  {
    rb.velocity = new Vector2(playerSpeed, rb.velocity.y);
  }

  public void PlatformPlayerMove(float x)
  {
    rb.velocity = new Vector2(x, rb.velocity.y);
  }


  void OnTriggerEnter2D(Collider2D other)
  {
    if (other.tag == "Kill")
    {
      Destroy(this.gameObject);
      GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>().GameOverPannel();
    }

    if(other.tag == "Star"){
      Destroy(other.gameObject);
      //coins increment
      Debug.Log("I point");
    }
  }
}
