using UnityEngine;

namespace LittleSimWorld.Characters
{
    [RequireComponent(typeof(Character))]
    public class CharacterView : View, IMove
    {
        [Header("References/Appearance")]
        public Views<SpriteRenderer> hair;
        public Views<SpriteRenderer> facialHair;
        public Views<SpriteRenderer> head;
        public Views<SpriteRenderer> eyes;
        public Views<SpriteRenderer> mouth;
        public Views<SpriteRenderer> blushes;

        [Header("References/Clothing")]
        public Views<SpriteRenderer> hat;
        public Views<SpriteRenderer> glasses;
        public Views<SpriteRenderer> top;


        void IMove.OnVelocityChanged(Vector3 speed)
        {
            if (speed != Vector3.zero)
                Rotate(speed);
        }


        public void EquipHair(string id) => CustomizationEditor.Instance.hairs[id].ApplyTo(this);
        public void EquipFacialHair(string id) => CustomizationEditor.Instance.facialHairs[id].ApplyTo(this);
        public void EquipHead(string id) => CustomizationEditor.Instance.heads[id].ApplyTo(this);
        public void EquipEyes(string id) => CustomizationEditor.Instance.eyes[id].ApplyTo(this);
        public void EquipMouth(string id) => CustomizationEditor.Instance.mouths[id].ApplyTo(this);
        public void EquipBlushes(string id) => CustomizationEditor.Instance.blushes[id].ApplyTo(this);

        public void EquipHat(string id) => CustomizationEditor.Instance.hats[id].ApplyTo(this);
        public void EquipGlasses(string id) => CustomizationEditor.Instance.glasses[id].ApplyTo(this);
        public void EquipTop(string id) => CustomizationEditor.Instance.tops[id].ApplyTo(this);

        //TODO: Add methods to remove items as well
    }
}