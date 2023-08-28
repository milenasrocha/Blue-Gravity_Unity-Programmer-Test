using System;
using UnityEngine;

namespace LittleSimWorld.Characters
{
    [Serializable]
    [CreateAssetMenu(fileName = "Facial Hair", menuName = "Character Customization Item/Appearance/Facial Hair", order = 2)]
    public class FacialHair : CharacterCustomizationItem
    {
        protected override void ApplyViewsTo(CharacterView characterViews) => views.ApplyTo(characterViews.facialHair);
    }
}