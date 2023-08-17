using System;

namespace LittleSimWorld.Characters
{
    [Serializable]
    public class Hair : CharacterCustomizationItem
    {
        public override void ApplyTo(CharacterView character) => ApplyTo(character.hair);
    }
}