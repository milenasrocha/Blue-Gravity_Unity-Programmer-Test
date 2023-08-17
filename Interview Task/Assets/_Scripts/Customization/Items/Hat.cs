using System;

namespace LittleSimWorld.Characters
{
    [Serializable]
    public class Hat : CharacterCustomizationItem
    {
        public override void ApplyTo(CharacterView character) => ApplyTo(character.hat);
    }
}