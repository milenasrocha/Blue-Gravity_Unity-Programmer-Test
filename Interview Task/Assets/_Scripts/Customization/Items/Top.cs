using System;

namespace LittleSimWorld.Characters
{
    [Serializable]
    public class Top : CharacterCustomizationItem
    {
        public override void ApplyTo(CharacterView character) => ApplyTo(character.top);
    }
}