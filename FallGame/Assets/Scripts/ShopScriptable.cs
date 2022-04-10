using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    [CreateAssetMenu(fileName = "ShopData",menuName = "Scriptable/Create ShopData")]
    public class ShopScriptable : ScriptableObject
    {
        public ShopItems[] shopItems;

        public int CharacterCount
        {
            get
            {
                return shopItems.Length;
            }
        }

        public ShopItems GetShopItems(int index)
        {
            return shopItems[index]; 
        }
    }

[System.Serializable]
public class ShopItems
{
    public string characterName;
    public Sprite characterSprite;
    public string characterDescription;
    public string characterUnlockcost;
}
