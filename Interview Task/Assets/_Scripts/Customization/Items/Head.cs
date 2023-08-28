using System;
using UnityEngine;

namespace LittleSimWorld.Characters
{
    [Serializable]
    [CreateAssetMenu(fileName = "Head", menuName = "Character Customization Item/Appearance/Head", order = 3)]
    public class Head : CharacterCustomizationItem
    {
        protected override void ApplyViewsTo(CharacterView character) => views.ApplyTo(character.head);
    }
}