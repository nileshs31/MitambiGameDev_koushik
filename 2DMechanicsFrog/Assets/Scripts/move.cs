using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
	public float speed;
	void FixedUpdate()
	{
		//Controls the movement of main camera.
		GetComponent<Rigidbody2D>().velocity = new Vector2(speed, 0f);
		speed += 0.0002f;
	}
}
