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
    private Camera mainCamera;
    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

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
        if (Input.GetMouseButtonDown(0))
        {
                jump = new Vector3(1, 1, 0);
                rb.AddForce(jump * force, ForceMode2D.Impulse);
        }
        if (Input.GetKeyDown("down"))
        {
            if (isGrounded)
            {
                jump = new Vector3(2, 2, 0);
                rb.AddForce(jump * force, ForceMode2D.Impulse);
            }
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
