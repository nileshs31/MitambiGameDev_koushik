using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    [SerializeField] GameController gameController;
    [SerializeField] PlayerController playerController;
    [SerializeField] private float moveSpeed = 1f;
    [SerializeField] private float moveY = 7f;

    public bool moveingPlatformLeft, moveingPlatformRight, isCrack, isSpike, isPlatform, isStar, isEnemy;

    private Animator anim;

    private void Awake()
    {
        if (isCrack) { anim = GetComponent<Animator>(); }
    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        Vector2 temp = transform.position;
        temp.y += moveSpeed * Time.deltaTime;
        transform.position = temp;

        if (temp.y > moveY) { Destroy(gameObject); }
    }
    private void Crack()
    {
        Invoke("DeactivateCrackPlatform", 0.5f);
    }

    private void DeactivateCrackPlatform()
    {
        gameObject.SetActive(false);
    }

    //on trigger spike
    private void OnTriggerEnter2D(Collider2D trigger)
    {
        if (trigger.tag == "Player")
        {
            if (isSpike || isEnemy)
            {
                //gamover
                GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>().ShowAddsPannel();
                //      this.gameObject.GetComponent<SpriteRenderer>().sprite = playerController.playerAfterDeath;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            if (isCrack)
            {
                anim.Play("CrackPlatform");
            }
        }
    }

    void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (moveingPlatformLeft)
            {
                other.gameObject.GetComponent<PlayerController>().PlatformPlayerMove(-1f);
            }
            else if (moveingPlatformRight)
            {
                other.gameObject.GetComponent<PlayerController>().PlatformPlayerMove(1f);
            }
        }
    }
}
