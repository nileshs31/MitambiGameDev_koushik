using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopUI : MonoBehaviour
{
    
    public GameObject[] characterList;
    public void SelectCharacter(int i)
    {
        PlayerPrefs.SetInt("currentcharacter",i); 
    }
}
