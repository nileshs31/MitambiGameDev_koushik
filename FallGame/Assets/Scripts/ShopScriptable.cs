using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShopSystem
{
    [CreateAssetMenu(fileName = "ShopData",menuName = "Scriptable/Create ShopData")]
    public class ShopScriptable : ScriptableObject
    {
        public ShopItems[] shopItems;
    }
    [System.Serializable]
    public class ShopItems
    {
        public string characterName;
        public string characterDescription;
        public bool isUnlocked;
        public int unlockCost;
    }
    public class Playerprefabs 
    {
        public List<GameObject> playerPrefabs = new List<GameObject>();
    }

}