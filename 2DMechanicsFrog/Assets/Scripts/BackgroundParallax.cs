using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundParallax : MonoBehaviour
{
public Vector2 speed = new Vector2(1, 0), direction = new Vector2(-1, 0), whereToSpawn;

     public float pos;

     private void Start()
     {

     }

     void Update()
     {
         Vector3 movement = new Vector3(speed.x * direction.x,speed.y * direction.y,0);

         movement *= Time.deltaTime;
         transform.Translate(movement);

         if(transform.position.x <= pos)
         {
             transform.position = new Vector3(whereToSpawn.x, whereToSpawn.y, 0);
         }
     }


}
