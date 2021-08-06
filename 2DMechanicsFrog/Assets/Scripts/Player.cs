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


        if(mousePosition.x < 0)
        {
            Singlemovement();
        }
        else
        {
            Doublelemovement();
        }

    /*    if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Singlemovement();
        }
        else if(Mouse.current.rightButton.wasPressedThisFrame)
        {
            Doublelemovement();
        }*/

       /* if (Input.GetMouseButtonDown(0))
        {
             animPlayer.SetBool("isJumping",true);
            Singlemovement();
        }
        else
        {
            animPlayer.SetBool("isJumping", false);
        }*/

       /* if (Input.GetMouseButtonDown(0))
        {
            animPlayer.SetBool("isJumping", true);
            Doublelemovement();
        }
        else
        {
            animPlayer.SetBool("isJumping", false);
        }*/
    }

    public void Singlemovement()
    {
        positionX = new Vector2(transform.position.x + increment, transform.position.y);
        transform.position = positionX;
    }
    public void Doublelemovement()
    {
        positionX = new Vector2(transform.position.x + increment * 2, transform.position.y);
        transform.position = positionX;
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
