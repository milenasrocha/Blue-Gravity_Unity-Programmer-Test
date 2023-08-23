using System;
using UnityEngine;

namespace LittleSimWorld.Characters
{
    [Serializable]
    [CreateAssetMenu(fileName = "Hat", menuName = "Character Customization Item/Clothing/Hat", order = 1)]
    public class Hat : CharacterCustomizationItem
    {
        public override void ApplyTo(CharacterView character) => ApplyTo(character.hat);
    }
}