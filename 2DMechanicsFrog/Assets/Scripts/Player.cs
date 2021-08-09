using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class Player : MonoBehaviour
{
    private Vector2 positionX;
    private bool movement;

    private Rigidbody2D rb;
    [SerializeField]
    private float increment = 2;

    private Animator animPlayer;
    private bool isIfinitePathActive = false;

    private PathSpawn ps;
    public GameObject infinitepath;
    [Range(1, 10)]
    public float jumpVelocity;
    // Start is called before the first frame update
    void Start()
    {
        animPlayer = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }


    private void Update()
    {
        Vector2 mousePosition = Mouse.current.position.ReadValue();
        Debug.Log(mousePosition);

        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            animPlayer.SetBool("isJumping", true);
            Doublelemovement();
        }
        else
        {
            animPlayer.SetBool("isJumping", false);
        }

        /*
                if (Input.GetButtonDown("SingleBtn"))
                {
                    animPlayer.SetBool("isJumping", true);
                    Doublelemovement();
                }
                else
                {
                    animPlayer.SetBool("isJumping", false);
                }
                //double
                if (Input.GetButtonDown("DoubleBtn"))
                {
                    animPlayer.SetBool("isJumping", true);
                    Doublelemovement();
                }
                else
                {
                    animPlayer.SetBool("isJumping", false);
                }*/
    }

    /*public void Singlemovement()
    {
        positionX = new Vector2(transform.position.x + increment, transform.position.y);
        transform.position = positionX;
    }*/
    public void Doublelemovement()
    {
        positionX = new Vector2(transform.position.x + increment * 6, transform.position.y);
        transform.position = positionX;
       // rb.velocity = Vector2.up * jumpVelocity;
    }

    public void jump()
    {
         
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
