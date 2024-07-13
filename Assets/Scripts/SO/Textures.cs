using System;
using System.Collections.Generic;
using UnityEngine;

namespace SO {
    [Serializable]
    public struct TextureItem {
        public NormalItem.eNormalType type;
        public Sprite sprite;
    }
    
    [CreateAssetMenu(fileName = "Textures", menuName = "ScriptableObjects/Textures", order = 1)]
    public class Textures : ScriptableObject {
        public List<TextureItem> items = new List<TextureItem>();
    }
}