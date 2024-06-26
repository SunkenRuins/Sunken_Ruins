using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SunkenRuins {
    
    [CreateAssetMenu(menuName = "ScriptableObjects/ItemScriptableObject")]
    public class ItemSO : ScriptableObject
    {

        public Transform prefab;
        public ItemType itemType;
        public Sprite sprite;
        public string itemName;

    }
}
