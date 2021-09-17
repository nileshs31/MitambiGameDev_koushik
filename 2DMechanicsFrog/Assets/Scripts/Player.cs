using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animPlayer;
    public Gamecontroller gameCon;
    [HideInInspector]
    public bool gameon;
    public float canBeTappedAgainAfter;


    void Start()
    {
        animPlayer = GetComponent<Animator>();
        rb = gameObject.GetComponent<Rigidbody2D>();
        gameon = false;
    }

    private void Update()
    {
        if (gameon)
        {
            if (Input.GetMouseButtonDown(0) && Input.mousePosition.x <= Screen.width / 2)
            {
                gameon = false;
                SingleMovement();
                animPlayer.SetTrigger("jumping");
                StartCoroutine(canbeTappedAgain());
            }
            if (Input.GetMouseButtonDown(0) && Input.mousePosition.x > Screen.width / 2)
            {
                gameon = false;
                DoubleMovement();
                animPlayer.SetTrigger("jumping");
                StartCoroutine(canbeTappedAgain());
            }

        }
       
        if (this.gameObject.transform.localPosition.y < -4.5f)
        {
            this.gameObject.SetActive(false);
        }
    }


    public void SingleMovement()
    {

        transform.DOMoveX(transform.position.x + 1.1f, 0.4f);
        transform.DOMoveY(transform.position.y + 0.5f, 0.2f);
    }
    public void DoubleMovement()
    {
        transform.DOMoveX(transform.position.x + 2.2f, 0.4f);
        transform.DOMoveY(transform.position.y + 0.75f, 0.2f);
    }

    IEnumerator canbeTappedAgain()
    {
        yield return new WaitForSeconds(canBeTappedAgainAfter);
        gameon = true;

    }
    public void onClickAnimation()
    {
        animPlayer.SetTrigger("IsRunning");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Kill")
        {
            StopAllCoroutines();
            GameObject.FindGameObjectWithTag("GameController").GetComponent<Gamecontroller>().GameOver();

        }
        else if (collision.tag == "coins")
        {
            Destroy(collision.gameObject);
            gameCon.CoinIncrement(1);
        }
    }

}