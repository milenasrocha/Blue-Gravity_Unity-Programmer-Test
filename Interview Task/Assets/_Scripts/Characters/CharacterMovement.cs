using UnityEngine;

namespace LittleSimWorld.Characters
{
    public class CharacterMovement : MonoBehaviour
    {
        [SerializeField] bool _canMove = true;
        public bool canMove
        {
            get => _canMove;
            set
            {
                _canMove = value;

                if (!_canMove)
                {
                    characterController.attachedRigidbody.velocity = Vector3.zero;
                }
            }
        }

        IMove[] IMoves = new IMove[0];


        [SerializeField] CharacterController characterController;
        [SerializeField, Range(.5f, 5)] protected float characterControllerSpeed = 2;

        #region Unity Callbacks
        protected void Awake()
        {
            IMoves = GetComponents<IMove>();
        }
        #endregion


        public virtual void Move(Vector3 input)
        {
            if (!canMove)
                return;

            Vector3 value = input * Time.deltaTime * characterControllerSpeed;

            characterController.Move(value);

            foreach (IMove IMove in IMoves)
                IMove.OnSpeedChanged(value);
        }
    }

    public interface IMove
    {
        void OnSpeedChanged(Vector3 speed);
    }
}