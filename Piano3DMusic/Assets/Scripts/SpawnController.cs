using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    
    [SerializeField] private GameObject[] tilePrefab;
    [SerializeField] Transform[] spawnPoint;
    private float timer;
    
    private void Start()
    {
        timer = 0;
        StartCoroutine(SpawnTiles());
    }
    private void Update()
    {
        timer += Time.deltaTime;
        Spawntiles();
    }
    IEnumerator SpawnTiles()
    {
        yield return new WaitForSeconds(2f);
        Spawntiles();
    }

    void Spawntiles()
    {
        if(timer >= 1.5f)
        {
            Instantiate(tilePrefab[(int)Random.Range(0f,3f)]);
            timer = 0;
        }
    }
}
