using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Vector2 positionX;
    private bool movement;

    private Rigidbody2D rb;

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
        if (Input.GetMouseButtonDown(0))
        {
            Singlemovement();
        }

        else if (Input.GetMouseButtonDown(1))
        {
            Doublelemovement();
        }
    }

    public void move()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector3 direction = new Vector3(horizontalInput, 0, 0);
        transform.Translate(direction * increment * Time.deltaTime);
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
