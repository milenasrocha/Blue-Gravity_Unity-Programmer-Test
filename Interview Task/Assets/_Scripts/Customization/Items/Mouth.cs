using System;

namespace LittleSimWorld.Characters
{
    [Serializable]
    public class Mouth : CharacterCustomizationItem
    {
        public override void ApplyTo(CharacterView character) => ApplyTo(character.mouth);
    }
}