using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Player : MonoBehaviour
{
    Vector3 jump;
    public float force;
    Rigidbody2D rb;

    private Animator animPlayer;

    public GameObject infinitepath;
    [SerializeField] private Camera mainCamera;
    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;
    Vector2 pos;
    bool moving;
    private float currePos;
    // Start is called before the first frame update
    void Start()
    {
        animPlayer = GetComponent<Animator>();
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        
    }

    private void Update()
    {
        Debug.Log( mainCamera.ScreenToWorldPoint(Input.mousePosition));
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetButton("SingleBtn"))
        {
            SingleMovement();
            animPlayer.SetBool("isJumping", true);
        }
        else
        {
            animPlayer.SetBool("isJumping", false);
        }


        if (Input.GetButton("DoubleBtn"))
        {
            DoubleMovement();
            animPlayer.SetBool("isJumping", true);
        }
        else
        {
            animPlayer.SetBool("isJumping", false);
        }
       
    }


    public void SingleMovement()
    {
       // if (Input.GetKeyDown("down"))
            jump = new Vector3(1, 1, 0);
            rb.AddForce(jump * force, ForceMode2D.Impulse);
    }

    public void DoubleMovement()
    {
        //  if (Input.GetKeyDown("up"))
        if (isGrounded)
        {
            jump = new Vector3(2, 2, 0);
            rb.AddForce(jump * force, ForceMode2D.Impulse);
        }
    }
    public void onClickAnimation()
    {
        animPlayer.SetTrigger("IsRunning");
    }


    //booster
    //Infinite Path
    public void InfinitePathActive()
    {
        StartCoroutine(InfinitePath());
    }

    IEnumerator InfinitePath()
    {
        yield return new WaitForSeconds(1f);
        Instantiate(infinitepath, new Vector3(infinitepath.transform.position.x, -0.98f, 0), Quaternion.identity);
        yield return new WaitForSeconds(15f);
    }

}
