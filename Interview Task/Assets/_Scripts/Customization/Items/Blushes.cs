using System;

namespace LittleSimWorld.Characters
{
    [Serializable]
    public class Blushes : CharacterCustomizationItem
    {
        public override void ApplyTo(CharacterView character) => ApplyTo(character.blushes);
    }
}