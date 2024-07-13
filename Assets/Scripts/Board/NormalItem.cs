using System;
using System.Collections;
using System.Collections.Generic;
using SO;
using UnityEngine;

public class NormalItem : Item
{
    public enum eNormalType
    {
        TYPE_ONE,
        TYPE_TWO,
        TYPE_THREE,
        TYPE_FOUR,
        TYPE_FIVE,
        TYPE_SIX,
        TYPE_SEVEN
    }

    public eNormalType ItemType;
    private List<TextureItem> _normalTextureItems = new List<TextureItem>();

    public void SetType(eNormalType type)
    {
        ItemType = type;
    }

    protected override Sprite GetPrefabSprite()
    {
        try {
            if (_normalTextureItems.Count <= 0) {
                _normalTextureItems = Resources.Load<Textures>(Constants.TEXTURE_PATH).items;
            }
            var item = _normalTextureItems.Find(x => x.type == ItemType);

            if (item.sprite != null) return item.sprite;
            Debug.LogError($"Failed to load item at ItemType: {ItemType}");
            return null;

        }
        catch (Exception e) {
            Debug.LogError($"Failed to load texture: {e.Message}");
            return null;
        }
    }

    protected override string GetItemName => $"normalType_{Enum.GetName(typeof(eNormalType), ItemType)}";

    internal override bool IsSameType(Item other)
    {
        NormalItem it = other as NormalItem;

        return it != null && it.ItemType == this.ItemType;
    }
}
