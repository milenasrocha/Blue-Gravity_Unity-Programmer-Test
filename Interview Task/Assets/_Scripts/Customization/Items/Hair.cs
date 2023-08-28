using System;
using UnityEngine;

namespace LittleSimWorld.Characters
{
    [Serializable]
    [CreateAssetMenu(fileName = "Hair", menuName = "Character Customization Item/Appearance/Hair", order = 1)]
    public class Hair : CharacterCustomizationItem
    {
        protected override void ApplyViewsTo(CharacterView characterViews) => views.ApplyTo(characterViews.hair);
    }
}