using System;
using UnityEngine;

namespace LittleSimWorld.Characters
{
    [Serializable]
    [CreateAssetMenu(fileName = "Eyes", menuName = "Character Customization Item/Appearance/Eyes", order = 5)]
    public class Eyes : CharacterCustomizationItem
    {
        protected override void ApplyViewsTo(CharacterView characterView) => views.ApplyTo(characterView.eyes);
    }
}