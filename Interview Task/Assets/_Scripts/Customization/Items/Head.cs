using System;
using UnityEngine;

namespace LittleSimWorld.Characters
{
    [Serializable]
    [CreateAssetMenu(fileName = "Head", menuName = "Character Customization Item/Appearance/Head", order = 3)]
    public class Head : CharacterCustomizationItem
    {
        public override void ApplyTo(CharacterView character) => ApplyTo(character.head);
    }
}