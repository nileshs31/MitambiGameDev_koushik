using DG.Tweening;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;

    private Animator animPlayer;
    public bool gameon;

    void Start()
    {
        animPlayer = GetComponent<Animator>();
        rb = gameObject.GetComponent<Rigidbody2D>();
        Input.simulateMouseWithTouches = true;
        gameon = false;
    }


    private void Update()
    {
#if UNITY_ANDROID
        if (gameon)
        {
            if (Input.GetMouseButtonDown(0) && Input.mousePosition.x <= Screen.width / 2)
            {
                //animPlayer.SetBool("isJumping", true);
                SingleMovement();
            }
            else if (Input.GetMouseButtonDown(0) && Input.mousePosition.x > Screen.width / 2)
            {
                //animPlayer.SetBool("isJumping", true);
                DoubleMovement();
            }
#endif
        }
        Vector2 screenposition = Camera.main.WorldToScreenPoint(transform.position);
        if (screenposition.x > Screen.width || screenposition.x < 0)
        {
            gameon = false;
            GameObject.FindGameObjectWithTag("GameController").GetComponent<Gamecontroller>().GameOver();
            Destroy(this.gameObject);  //player
        }
    }


    public void SingleMovement()
    {
        transform.DOMoveX(transform.position.x + 1.1f, 0.1f);
        transform.DOMoveY(transform.position.y + 0.2f, 0.05f);
    }

    public void DoubleMovement()
    {
        transform.DOMoveX(transform.position.x + 2.2f, 0.1f);
        transform.DOMoveY(transform.position.y + 0.2f, 0.05f);
    }
    public void onClickAnimation()
    {
        animPlayer.SetTrigger("IsRunning");
    }
}
