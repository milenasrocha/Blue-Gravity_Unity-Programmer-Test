using System;

namespace LittleSimWorld.Characters
{
    [Serializable]
    public class Head : CharacterCustomizationItem
    {
        public override void ApplyTo(CharacterView character) => ApplyTo(character.head);
    }
}