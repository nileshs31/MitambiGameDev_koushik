﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class respawnManager : MonoBehaviour
{
    public static respawnManager instance;

    public Transform platformGenerate;
    private Vector3 platformstartpoint;

    public Camera cam;
    private Vector3 cameraposition;

    public Player player;
    private Vector3 playerStartPoint;

    private void Start()
    {
        platformstartpoint = platformGenerate.position;
        playerStartPoint = player.transform.position;
    }

    public void RestartGame()
    {
        
    }

    public IEnumerator RestartGameOn()
    {
        player.gameObject.SetActive(false);
        yield return new WaitForSeconds(3f);
        player.transform.position = playerStartPoint;
        platformGenerate.position = platformstartpoint;
        player.gameObject.SetActive(true);

        cam.transform.position = cameraposition;
    }
}
