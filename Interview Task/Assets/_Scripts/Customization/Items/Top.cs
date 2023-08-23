using System;
using UnityEngine;

namespace LittleSimWorld.Characters
{
    [Serializable]
    [CreateAssetMenu(fileName = "Top", menuName = "Character Customization Item/Clothing/Top", order = 4)]
    public class Top : CharacterCustomizationItem
    {
        public override void ApplyTo(CharacterView character) => ApplyTo(character.top);
    }
}