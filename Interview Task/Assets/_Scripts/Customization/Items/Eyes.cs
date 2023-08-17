using System;

namespace LittleSimWorld.Characters
{
    [Serializable]
    public class Eyes : CharacterCustomizationItem
    {
        public override void ApplyTo(CharacterView character) => ApplyTo(character.eyes);
    }
}