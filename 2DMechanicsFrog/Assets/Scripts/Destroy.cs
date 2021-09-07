using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
	GameObject Destructor;
	// Use this for initialization
	void Start()
	{
		Destructor = GameObject.FindGameObjectWithTag("Kill");
	}

	// Update is called once per frame
	void Update()
	{
		if (transform.position.x < Destructor.transform.position.x)
		{
			Destroy(this.gameObject);
		}
	}
}
