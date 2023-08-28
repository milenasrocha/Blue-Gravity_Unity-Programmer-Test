using System;
using UnityEngine;

namespace LittleSimWorld.Characters
{
    [Serializable]
    [CreateAssetMenu(fileName = "Glasses", menuName = "Character Customization Item/Clothing/Glasses", order = 2)]
    public class Glasses : CharacterCustomizationItem
    {
        protected override void ApplyViewsTo(CharacterView characterViews) => views.ApplyTo(characterViews.glasses);
    }
}