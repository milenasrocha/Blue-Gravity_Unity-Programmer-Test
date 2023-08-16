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

                if (!value)
                {
                    rb.velocity = Vector3.zero;
                }
            }
        }
        [SerializeField] Vector3 newVelocity;

        IMove[] IMoves = new IMove[0];

        [SerializeField] Rigidbody rb;
        [SerializeField, Range(.1f, 5)] protected float characterControllerSpeed = 2;

        #region Unity Callbacks
        protected void Awake()
        {
            IMoves = GetComponents<IMove>();
        }

        void OnDisable()
        {
            newVelocity = Vector3.zero;
        }

        void FixedUpdate()
        {
            SetVelocity(newVelocity);
        }
        #endregion

        public void MoveRequest(Vector3 input)
        {
            if (!canMove)
                return;

            //newVelocity = input * Time.deltaTime * characterControllerSpeed;
            newVelocity = input * characterControllerSpeed;
        }
        public void SetVelocity(Vector3 newVelocity)
        {
            if (!canMove)
                return;

            //rb.AddForce(newVelocity, ForceMode.VelocityChange);
            rb.velocity = newVelocity;

            foreach (IMove IMove in IMoves)
                IMove.OnSpeedChanged(newVelocity);
        }
    }

    public interface IMove
    {
        void OnSpeedChanged(Vector3 speed);
    }
}