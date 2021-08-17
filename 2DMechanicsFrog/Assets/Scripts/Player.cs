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
    public Transform groundCheck;
    public float checkRadius;
    private float currePos;
    public LayerMask whatIsGround;
    Vector2 pos;
    bool moving;
    private bool isGrounded;
    // Start is called before the first frame update
    void Start()
    {
        animPlayer = GetComponent<Animator>();
        rb = gameObject.GetComponent<Rigidbody2D>();
    }


    private void Update()
    {
        if(Input.GetKeyDown("up"))
        {
            SingleMovement();
            animPlayer.SetBool("isJumping", true);
        }
        else
        {
            animPlayer.SetBool("isJumping", false);
        }

           //if (Input.GetButton("DoubleBtn"))
        if (Input.GetKeyDown("down"))
        {
            DoubleMovement();
            animPlayer.SetBool("isJumping", true);
        }
        else
        {
            animPlayer.SetBool("isJumping", false);
        }
      
        #if UNITY_ANDROID
        if (Input.GetMouseButtonDown(0) && Input.mousePosition.x <= Screen.width / 2)
        {
            SingleMovement();
        }
        else if (Input.GetMouseButtonDown(0) && Input.mousePosition.x > Screen.width / 2)
        {
            DoubleMovement();
        }
        #endif

    }


    public void SingleMovement()
    {
            jump = new Vector3(1, 1, 0);
            rb.AddForce(jump * force, ForceMode2D.Impulse);
    }

    public void DoubleMovement()
    {
        //  if (Input.GetKeyDown("up"))
        //if (isGrounded)
        //{
            jump = new Vector3(2, 2, 0);
            rb.AddForce(jump * force, ForceMode2D.Impulse);
        //}
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
