using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGen : MonoBehaviour
{
	public GameObject[] GroundPrefabs;
	public GameObject coinsPrefabs;
	public Transform GenerationPoint;
	public Transform CoinGenerationPoint;
	public float ObjectWidth;
	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void FixedUpdate()
	{
		//When GenerationPoint exceeds the gameobject, a new game object is instantiated. 
		if (transform.position.x < GenerationPoint.position.x)
		{
			transform.position = new Vector3(transform.position.x + ObjectWidth, transform.position.y, transform.position.z);
			GameObject newGameObject = GroundPrefabs[Random.Range(0, GroundPrefabs.Length)];
			//var go = 
				Instantiate(newGameObject, transform.position, Quaternion.identity);
			//Destroy(go, 5f);
		}
		Instantiate(coinsPrefabs, new Vector3( transform.position.x,transform.position.y,transform.position.z), Quaternion.identity);
	}

}
