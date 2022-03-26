using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopUI : MonoBehaviour
{
    
    public GameObject[] playerSkin;
    public void SelectCharacter(int i)
    {
        PlayerPrefs.SetInt("currentcharacter",i);
    }

    private void Awake()
    {/*
        foreach(GameObject player in playerSkin)
        {
            player.SetActive(false);
        }*/ 
    }

    public void ChangeNext()
    {

    }
    
    public void PreviousNext()
    {

    }
}

