using System;
using UnityEngine;

namespace LittleSimWorld.Characters
{
    [Serializable]
    [CreateAssetMenu(fileName = "Mouth", menuName = "Character Customization Item/Appearance/Mouth", order = 6)]
    public class Mouth : CharacterCustomizationItem
    {
        protected override void ApplyViewsTo(CharacterView character) => views.ApplyTo(character.mouth);
    }
}