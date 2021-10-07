using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{

    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private float moveY = 7f;

    public bool moveingPlatformLeft, moveingPlatformRight, isCrack, isSpike, isPlatform;

    private Animator anim;

    private void Start()
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

        if (temp.y > moveY) { gameObject.SetActive(false); }
    }
}
