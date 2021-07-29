using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StayInsideScene : MonoBehaviour
{
    private void Update()
    {
        transform.position = new Vector2(Mathf.Clamp(transform.position.x,-2.3f,1.28f),transform.position.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "kill")
        {
            Debug.Log("Respawn");
            GameManager.Instance.GameOver();
            Destroy(this.gameObject);
        }
    }
}
