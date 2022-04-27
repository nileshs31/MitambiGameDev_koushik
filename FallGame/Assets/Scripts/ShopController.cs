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

    private int selectedIndex;
    private int selectOption = 0;
    private string characterSelect = "selectChar";
    private string selectBtntext = "selecttext";
    public Button unlockButton,selectBtn;
    public TextMeshProUGUI unlockBtnText, selectBtnText;

   

    private void Start()
    {
        //selectBtnText.text = "Select";

        selectedIndex = PlayerPrefs.GetInt(characterSelect, 0);
        selectOption = selectedIndex;

        unlockButton.onClick.AddListener(() => UnlockSelectButton());

        foreach (ShopItems s in shopScript.shopItems)
        {
            if(s.price == 0)
            {
                s.isUnlocked = true;
                //selectBtnText.text = "Selected";
                Save();
            }
            else
            {
                //s.isUnlocked = PlayerPrefs.GetInt(s.characterName, 0) == 0 ? false : true;
                if ( selectedIndex == 0)
                {
                    s.isUnlocked = false;
                }
                else
                {
                    s.isUnlocked = true;
                }
            }
        }
        UpdateCharacterSprite(selectOption);
        UnlockButtonStatus();
        //UpdateButtonUI();
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
        // UpdateButtonUI();
        UnlockButtonStatus();
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
        //UpdateButtonUI();
        UnlockButtonStatus();
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
        selectOption = PlayerPrefs.GetInt(characterSelect);
    }

    public void Save()
    {
        PlayerPrefs.SetInt(characterSelect,selectOption);
    }

    private void UnlockSelectButton()
    {
        int totalCoins = PlayerPrefs.GetInt("Star");
        bool selected = false;
        if (shopScript.shopItems[selectOption].isUnlocked)
        {
            selected = true;
        }
        else if (!shopScript.shopItems[selectOption].isUnlocked)
        {
            if(totalCoins >= shopScript.shopItems[selectOption].price)
            {
                totalCoins -= shopScript.shopItems[selectOption].price;
                PlayerPrefs.SetInt("Star", totalCoins);
                selected = true;
                shopScript.shopItems[selectOption].isUnlocked = true;
            }
        }

        if (selected)
        {
            unlockBtnText.text = "Selected";
            selectedIndex = selectOption;
            Save();
            unlockButton.interactable = false;
        }
    }

    public void UnlockButtonStatus()
    {
        if (shopScript.shopItems[selectOption].isUnlocked)
        {
            unlockButton.interactable = selectedIndex != selectOption ? true : false;
            unlockBtnText.text = selectedIndex == selectOption ? "Selected" : "Select";
        }
        else if (!shopScript.shopItems[selectOption].isUnlocked)
        {
            unlockButton.interactable = true;
            unlockBtnText.text = shopScript.shopItems[selectOption].price + "";
        }
    }

   /* public void UpdateButtonUI()
    {
        //current select character and check
        if(shopScript.shopItems[selectOption].isUnlocked == true){
            unlockButton.gameObject.SetActive(false);
            selectBtn.gameObject.SetActive(true);
            selectBtnText.text = selectedIndex == selectOption ? "Selected" : "Select";
        }
        else
        {
            selectBtn.gameObject.SetActive(false);
            if (PlayerPrefs.GetInt("Star", 0) < shopScript.shopItems[selectOption].price)  //check if the current player unlockcost price is less than the coins
            {
                unlockButton.gameObject.SetActive(true);
                unlockButton.interactable = false;
               // selectBtn.gameObject.SetActive(false);
            }
            else
            {
                unlockButton.gameObject.SetActive(true);
                unlockButton.interactable = true;
               // selectBtn.gameObject.SetActive(false);
            }
        }
    }

    public void UnlockCharacter()
    {
        int coins = PlayerPrefs.GetInt("Star");
        int price = shopScript.shopItems[selectOption].price;
        PlayerPrefs.SetInt("Star", coins - price);
        PlayerPrefs.SetInt(shopScript.shopItems[selectOption].characterName, 1);
        shopScript.shopItems[selectOption].isUnlocked = true;
        UpdateButtonUI();
    }
*/
    /*public void SelectBtnCharacter()
    {
        if (shopScript.shopItems[selectOption].isUnlocked)
        {
            Save();
        }
    }*/
}

 