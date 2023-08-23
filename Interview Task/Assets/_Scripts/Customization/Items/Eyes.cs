using System;
using UnityEngine;

namespace LittleSimWorld.Characters
{
    [Serializable]
    [CreateAssetMenu(fileName = "Eyes", menuName = "Character Customization Item/Appearance/Eyes", order = 5)]
    public class Eyes : CharacterCustomizationItem
    {
        public override void ApplyTo(CharacterView character) => ApplyTo(character.eyes);
    }
}