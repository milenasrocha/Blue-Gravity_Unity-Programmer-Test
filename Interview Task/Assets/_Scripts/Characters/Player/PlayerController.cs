using UnityEngine;

namespace LittleSimWorld.Characters
{
    public class PlayerController : Singleton<PlayerController>
    {
        [SerializeField] Character character;

        #region Movement
        [Header("Movement")]
        [SerializeField] bool _movementInputIsLocked;
        public bool movementInputIsLocked
        {
            get => _movementInputIsLocked;
            set => _movementInputIsLocked = value;
        }
        #endregion Movement

        void Update()
        {
            ReadMovement();
        }

        void ReadMovement()
        {
            if (movementInputIsLocked)
                return;

            //general movement speed
            Vector2 movementInput = InputReader.Movement;

            // if no input
            if (movementInput.magnitude <= 0)
                return;

            character.mover.Move(new Vector3(movementInput.x, 0, movementInput.y));
        }
        public void LockMovementInput() => movementInputIsLocked = true;
        public void UnlockMovementInput() => movementInputIsLocked = false;
    }
}