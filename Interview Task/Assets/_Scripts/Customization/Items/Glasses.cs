using System;
using UnityEngine;

namespace LittleSimWorld.Characters
{
    [Serializable]
    [CreateAssetMenu(fileName = "Glasses", menuName = "Character Customization Item/Clothing/Glasses", order = 2)]
    public class Glasses : CharacterCustomizationItem
    {
        public override void ApplyTo(CharacterView character) => ApplyTo(character.glasses);
    }
}