using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
//Main Player(Select Character) Object in Hierarchy(Home Screen)
public class ShopController : MonoBehaviour
{
    public ShopScriptable shopScript;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI charDescriptionText;
    public TextMeshProUGUI charUnlockcostText;
    public Image charSprite;

    private int selectOption = 0;

    private void Start()
    {
        UpdateCharacterSprite(selectOption); 
    }

    public void NextOption()
    {
        selectOption++;
        if(selectOption >= shopScript.CharacterCount)
        {
            selectOption = 0;
        }
        UpdateCharacterSprite(selectOption);
        Debug.Log("ChangeCharacter right");
        Save();
    }

    public void BackOption()
    {
        selectOption--;
        if (selectOption < 0)
        {
            selectOption = shopScript.CharacterCount - 1;
        }
        UpdateCharacterSprite(selectOption);
        Debug.Log("ChangeCharacter left");
        Save();
    }

    private void UpdateCharacterSprite(int selectOption)
    {
        //shop items class
        ShopItems shopitems = shopScript.GetShopItems(selectOption);
        charSprite.sprite = shopitems.characterSprite;
        nameText.text = shopitems.characterName;
        charDescriptionText.text = shopitems.characterDescription;
        charUnlockcostText.text = shopitems.characterUnlockcost;
    }

    private void Load()
    {
        selectOption = PlayerPrefs.GetInt("selectChar");
    }

    private void Save()
    {
        PlayerPrefs.SetInt("selectChar",selectOption);
    }
}

 