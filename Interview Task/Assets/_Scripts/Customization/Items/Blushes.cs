using System;
using UnityEngine;

namespace LittleSimWorld.Characters
{
    [Serializable]
    [CreateAssetMenu(fileName = "Blushes", menuName = "Character Customization Item/Appearance/Blushes", order = 7)]
    public class Blushes : CharacterCustomizationItem
    {
        public override void ApplyTo(CharacterView character) => ApplyTo(character.blushes);
    }
}