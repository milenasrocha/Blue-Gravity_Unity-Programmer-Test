using UnityEngine;

namespace LittleSimWorld.Characters
{
    [RequireComponent(typeof(Character))]
    public class CharacterView : MonoBehaviour, IMove
    {
        [Header("Rotate")]
        [SerializeField] bool _canRotate = true;
        public bool canRotate
        {
            get => _canRotate;
            set => _canRotate = value;
        }

        [SerializeField] Views<GameObject> views;
        [SerializeField] Directions facingDirection = Directions.Down;

        [Header("References")]
        public Views<GameObject> fullCharacter;

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

        public void Rotate(Vector3 velocity)
        {
            if (velocity.x != 0)
                Rotate(velocity.x > 0 ? Directions.Right : Directions.Left);
            else
                Rotate(velocity.z > 0 ? Directions.Up : Directions.Down);
        }
        public void Rotate(Directions newDirection)
        {
            if (!canRotate)
                return;

            if (facingDirection == newDirection)
                return;

            //disable previous facing direction
            views.Get(facingDirection).SetActive(false);

            //enable current facing direction
            GameObject newSide = views.Get(newDirection, out bool isOpposite);
            SideViewFlip(newDirection);

            newSide.SetActive(true);

            facingDirection = newDirection;
        }
        void SideViewFlip(Directions direction)
        {
            //default scale is 1 (turned to right)
            GameObject sideView = views.Get(direction);
            Vector3 currentScale = sideView.transform.localScale;

            if (direction == Directions.Left)
                sideView.transform.localScale = new Vector3(-1, currentScale.y, currentScale.z);
            else
                sideView.transform.localScale = new Vector3(1, currentScale.y, currentScale.z);
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