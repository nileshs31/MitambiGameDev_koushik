using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    SpriteRenderer sr;

    float jumpforce = 10f;
    string currentColor;

    public Color Blue;
    public Color Yellow;
    public Color Purple;
    public Color Pink;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        RandomColor();
    }

    // Update is called once per frame
    void Update()
    {
        playerMovement();
    }

    void playerMovement()
    {
        if (Input.GetMouseButtonDown(0))
        {
            rb.velocity = Vector2.up * jumpforce;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != currentColor)
        {
            Debug.Log("GAME OVER!");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    void RandomColor()
    {

        int index = Random.Range(0, 4);

        switch (index)
        {
            case 0:
                currentColor = "Blue";
                sr.color = Blue;
                break;
            case 1:
                currentColor = "Yellow";
                sr.color = Yellow;
                break;
            case 2:
                currentColor = "Purple";
                sr.color = Purple;
                break;
            case 3:
                currentColor = "Pink";
                sr.color = Pink;
                break;
        }
    }
}
