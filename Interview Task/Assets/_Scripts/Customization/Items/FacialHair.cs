using System;

namespace LittleSimWorld.Characters
{
    [Serializable]
    public class FacialHair : CharacterCustomizationItem
    {
        public override void ApplyTo(CharacterView character) => ApplyTo(character.facialHair);
    }
}