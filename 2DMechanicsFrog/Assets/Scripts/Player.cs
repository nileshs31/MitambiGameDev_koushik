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
            animPlayer.SetBool("isJumping", true);
            SingleMovement();
        }
        else if (Input.GetMouseButtonDown(0) && Input.mousePosition.x > Screen.width / 2)
        {
            animPlayer.SetBool("isJumping", true);
            DoubleMovement();
        }
#endif

    }


    public void SingleMovement()
    {
            jump = new Vector3(1, 1, 0);
            rb.AddForce(jump * force * 1.2f, ForceMode2D.Impulse);
    }

    public void DoubleMovement()
    {
            jump = new Vector3(2, 2, 0);
            rb.AddForce(jump * force, ForceMode2D.Impulse);
    }
    public void onClickAnimation()
    {
        animPlayer.SetTrigger("IsRunning");
    }
}
