using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coin : MonoBehaviour
{
    public float CoinSpeed = 2f;

    void Update()
    {
        transform.Translate(Vector3.left * CoinSpeed * Time.deltaTime);
        if (transform.position.x < -2.5)
        {
            Destroy(this.gameObject);
        }
    }
}
