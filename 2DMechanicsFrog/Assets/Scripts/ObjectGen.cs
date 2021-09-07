using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGen : MonoBehaviour
{
	public GameObject[] GroundPrefabs;
	public GameObject coinsPrefab;
	public GameObject powerPrefab;
	public GameObject InfinitePath;
	public Transform GenerationPoint;
	public float ObjectWidth;

	public bool powerup;
	// Use this for initialization
	void Start()
	{
		InvokeRepeating("InfiniteGroundPower",10f,60f);
		InvokeRepeating("CoinSpawn", 1f, 3f);
	}

	// Update is called once per frame
	void FixedUpdate()
	{
		GroundSpawn();
		//CoinSpawn();
	}

	public IEnumerator Ground()
    {
        while (!powerup)
        {
			GroundSpawn();
			yield return new WaitForSeconds(0.5f);
        }
    }

	public void InfiniteGround()
    {
		powerup = true;
		StartCoroutine(InfiniteGroundOff());
		Instantiate(InfinitePath, new Vector3(transform.position.x,transform.position.y,transform.position.z),Quaternion.identity);
	}

	public IEnumerator InfiniteGroundOff()
    {
		Debug.Log("Start");
		yield return new WaitForSeconds(0.6f);
		powerup = false;
    }


	private void GroundSpawn()
	{ 		
		if (transform.position.x < GenerationPoint.position.x)
		{
			transform.position = new Vector3(transform.position.x + ObjectWidth, transform.position.y, transform.position.z);
			GameObject newGameObject = GroundPrefabs[Random.Range(0, GroundPrefabs.Length)];
			Instantiate(newGameObject, transform.position, Quaternion.identity);
		}
	}

	private void CoinSpawn()
    {
		Instantiate(coinsPrefab, new Vector3(transform.position.x, transform.position.y + 0.2f, transform.position.z), Quaternion.identity);
	}

	public void InfiniteGroundPower()
    {
		Instantiate(powerPrefab, new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z), Quaternion.identity);
    }

}
