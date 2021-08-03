using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundParallax : MonoBehaviour
{
    
    public Vector2 speed = new Vector2(1, 0);

    public Vector2 direction = new Vector2(-1, 0);

    public bool isLooping = false;

    public List<SpriteRenderer> background;

    private void Start()
    {
        
    }

    void Update()
    {
        Vector3 movement = new Vector3(speed.x * direction.x,speed.y * direction.y,0);

        movement *= Time.deltaTime;
        transform.Translate(movement);
    }
}
