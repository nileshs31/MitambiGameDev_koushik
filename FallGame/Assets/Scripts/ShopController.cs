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

    public Button unlockButton;

    private void Start()
    {
        UpdateCharacterSprite(selectOption);
        foreach (ShopItems s in shopScript.shopItems)
        {
            if(s.price == 0)
            {
                s.isUnlocked = true;
            }
            else
            {
                //s.isUnlocked = PlayerPrefs.GetInt(s.characterName, 0) == 0 ? false : true;
                if (PlayerPrefs.GetInt(s.characterName, 0) == 0)
                {
                    s.isUnlocked = false;
                }
                else
                {
                    s.isUnlocked = true;
                }
            }
        }
        UpdateButtonUI();
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
        if (shopScript.shopItems[selectOption].isUnlocked)
        {
            Save();
        }
        UpdateButtonUI();
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
        if (shopScript.shopItems[selectOption].isUnlocked)
        {
            Save();
        }
        UpdateButtonUI();
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

    public void Save()
    {
        PlayerPrefs.SetInt("selectChar",selectOption);
    }

    public void UpdateButtonUI()
    {
        //current select character and check
        if(shopScript.shopItems[selectOption].isUnlocked == true){
            unlockButton.gameObject.SetActive(false);
            charUnlockcostText.text = "Selected";
        }
        else
        {
            if (PlayerPrefs.GetInt("Star", 0) < shopScript.shopItems[selectOption].price)  //check if the current player unlockcost price is less than the coins
            {
                unlockButton.gameObject.SetActive(true);
                unlockButton.interactable = false;
            }
            else
            {
                unlockButton.gameObject.SetActive(true);
                unlockButton.interactable = true;
            }
        }
    }

    public void UnlockCharacter()
    {
        int coins = PlayerPrefs.GetInt("Star");
        int price = shopScript.shopItems[selectOption].price;
        PlayerPrefs.SetInt("Star", coins - price);
        PlayerPrefs.SetInt(shopScript.shopItems[selectOption].characterName, 1);
        PlayerPrefs.SetInt("selectChar", selectOption);
        shopScript.shopItems[selectOption].isUnlocked = true;
        UpdateButtonUI();
    }
}

 