using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
	public GameObject Destructor;
	void Start()
	{
		//Destructor = GameObject.FindGameObjectWithTag("Destroy");
	}
	void Update()
	{
		if (transform.position.x < Destructor.transform.position.x)
		{
			Destroy(this.gameObject);
		}
	}
}
