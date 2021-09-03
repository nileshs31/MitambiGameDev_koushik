using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

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
        /* if (Input.GetMouseButtonDown(0) && Input.mousePosition.x <= Screen.width / 2)
         {
             animPlayer.SetBool("isJumping", true);
             SingleMovement();
         }
         else if (Input.GetMouseButtonDown(0) && Input.mousePosition.x > Screen.width / 2)
         {
             animPlayer.SetBool("isJumping", true);
             DoubleMovement();
         }*/
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
        /*     jump = new Vector3(1, 1, 0);
             rb.AddForce(jump * force * 1.2f, ForceMode2D.Impulse);
 */
        transform.DOMoveX(transform.position.x + 1.2f, 0.1f);
        transform.DOMoveY(transform.position.y + 0.5f, 0.05f);

        //transform.DOJump((transform.position.x,transform.position.y),2f,1,0.1f,true);
    }

    public void DoubleMovement()
    {
        /*  jump = new Vector3(2, 2, 0);
          rb.AddForce(jump * force, ForceMode2D.Impulse);*/
        transform.DOMoveX(transform.position.x + 2.5f, 0.1f);
        transform.DOMoveY(transform.position.y + 0.8f, 0.05f);
    }
    public void onClickAnimation()
    {
        animPlayer.SetTrigger("IsRunning");
    }
}
