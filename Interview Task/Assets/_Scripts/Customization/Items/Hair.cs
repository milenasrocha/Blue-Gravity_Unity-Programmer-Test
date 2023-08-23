using System;
using UnityEngine;

namespace LittleSimWorld.Characters
{
    [Serializable]
    [CreateAssetMenu(fileName = "Hair", menuName = "Character Customization Item/Appearance/Hair", order = 1)]
    public class Hair : CharacterCustomizationItem
    {
        public override void ApplyTo(CharacterView character) => ApplyTo(character.hair);
    }
}