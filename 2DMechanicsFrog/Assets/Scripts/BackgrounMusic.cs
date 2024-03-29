﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgrounMusic : MonoBehaviour
{
    public static BackgrounMusic backgroundMusic;
    private void Awake()
    {
        if(backgroundMusic == null)
        {
            backgroundMusic = this;
            DontDestroyOnLoad(backgroundMusic);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
