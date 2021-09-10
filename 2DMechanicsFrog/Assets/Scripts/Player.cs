using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animPlayer;
    private Gamecontroller gc;
    public bool gameon;
    public bool animationPlayer = false;
 
    void Start()
    {
        animPlayer = GetComponent<Animator>();
        rb = gameObject.GetComponent<Rigidbody2D>();
        gameon = false;
    }

    private void Update()
    {
#if UNITY_ANDROID
        if (gameon)
        {
            if (Input.GetMouseButtonDown(0) && Input.mousePosition.x <= Screen.width / 2)
            {
                SingleMovement();
                animPlayer.SetTrigger("jumping");

            }
            if (Input.GetMouseButtonDown(0) && Input.mousePosition.x > Screen.width / 2)
            {
                DoubleMovement();
                animPlayer.SetTrigger("jumping");
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Kill")
        {
            Debug.Log("Touch");
            GameObject.FindGameObjectWithTag("GameController").GetComponent<Gamecontroller>().GameOver();
            Destroy(this.gameObject);
        }
    }
}