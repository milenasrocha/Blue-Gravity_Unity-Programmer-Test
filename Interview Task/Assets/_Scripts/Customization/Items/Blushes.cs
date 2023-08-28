using System;
using UnityEngine;

namespace LittleSimWorld.Characters
{
    [Serializable]
    [CreateAssetMenu(fileName = "Blushes", menuName = "Character Customization Item/Appearance/Blushes", order = 7)]
    public class Blushes : CharacterCustomizationItem
    {
        protected override void ApplyViewsTo(CharacterView characterView) => views.ApplyTo(characterView.blushes);
    }
}