using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ShopController : MonoBehaviour
{
    public ShopScriptable shopScript;

    public TextMeshProUGUI nameText;
    public TextMeshProUGUI charDescriptionText;
    public TextMeshProUGUI charUnlockcostText;
    public Tweener textPopup;
    public TextMeshProUGUI popUpText;
    public Image charSprite;

    private int selectedIndex;
    private int selectOption = 0;
    private string characterSelect = "selectChar";
    private string selectBtntext = "selecttext";
    public Button unlockButton,selectBtn;
    public TextMeshProUGUI unlockBtnText, selectBtnText;

    private void Start()
    {
        Load();
        selectedIndex = PlayerPrefs.GetInt(characterSelect, 0);
        selectOption = selectedIndex;

        unlockButton.onClick.AddListener(() => UnlockSelectButton());

        UpdateCharacterSprite(selectOption);
        UnlockButtonStatus();
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
        UnlockButtonStatus();
    }

    private void UpdateCharacterSprite(int selectOption)
    {
        //shop items class
        ShopItems shopitems = shopScript.GetShopItems(selectOption);
        charSprite.sprite = shopitems.characterSprite;
        nameText.text = shopitems.characterName;
        charDescriptionText.text = shopitems.characterDescription;
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
        int totalCoins = PlayerPrefs.GetInt("Star",0);
        bool selected = false;
        if (shopScript.shopItems[selectOption].isUnlocked)
        {
            selected = true;
        }
        else if (!shopScript.shopItems[selectOption].isUnlocked)
        {
            if(totalCoins >= shopScript.shopItems[selectOption].characterUnlockCost)
            {
                totalCoins -= shopScript.shopItems[selectOption].characterUnlockCost;
                PlayerPrefs.SetInt("Star", totalCoins);
                selected = true;
                shopScript.shopItems[selectOption].isUnlocked = true;
            }
            else
            {
                textPopup.Show(textPopup.CloseAfter);
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
            unlockBtnText.text = shopScript.shopItems[selectOption].characterUnlockCost + "";
        }
    }

}

 