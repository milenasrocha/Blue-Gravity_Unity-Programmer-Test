using UnityEngine;

namespace LittleSimWorld.Characters
{
    [RequireComponent(typeof(Character))]
    public class CharacterMovement : MonoBehaviour
    {
        #region Move
        [Header("Move")]
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
        [SerializeField, Range(.1f, 5)] protected float speed = 2;
        [SerializeField] Vector3 newVelocity;
        #endregion Move

        IMove[] IMoves = new IMove[0];

        #region References
        [Header("References")]
        [SerializeField] Rigidbody rb;
        #endregion References


        #region Unity Callbacks
        protected void Awake()
        {
            IMoves = GetComponents<IMove>();
        }

        void Start()
        {
            GetComponent<Character>().mover = this;
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

        public void Move(Vector3 input)
        {
            if (!canMove)
                return;

            //newVelocity = input * Time.deltaTime * characterControllerSpeed;
            newVelocity = input * speed;
        }
        void SetVelocity(Vector3 newVelocity)
        {
            if (!canMove)
                return;

            if (rb.velocity == newVelocity)
                return;

            //rb.AddForce(newVelocity, ForceMode.VelocityChange);
            rb.velocity = newVelocity;

            foreach (IMove IMove in IMoves)
                IMove.OnVelocityChanged(newVelocity);
        }
        //TODO: MoveTo(Vector3 position)
    }

    public interface IMove
    {
        void OnVelocityChanged(Vector3 speed);
    }
}