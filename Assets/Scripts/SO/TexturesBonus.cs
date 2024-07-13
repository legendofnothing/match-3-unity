using System;
using System.Collections.Generic;
using UnityEngine;

namespace SO {
    [Serializable]
    public struct TextureItemBonus {
        public BonusItem.eBonusType type;
        public Sprite sprite;
    }
    
    [CreateAssetMenu(fileName = "TexturesBonus", menuName = "ScriptableObjects/TexturesBonus", order = 1)]
    public class TexturesBonus : ScriptableObject {
        public List<TextureItemBonus> items = new List<TextureItemBonus>();
    }
}