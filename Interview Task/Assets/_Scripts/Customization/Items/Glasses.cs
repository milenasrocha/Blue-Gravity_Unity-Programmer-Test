using System;

namespace LittleSimWorld.Characters
{
    [Serializable]
    public class Glasses : CharacterCustomizationItem
    {
        public override void ApplyTo(CharacterView character) => ApplyTo(character.glasses);
    }
}