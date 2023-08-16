using UnityEngine;

namespace LittleSimWorld.Characters
{
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

        #region Rotate
        [Header("Rotate")]
        [SerializeField] bool _canRotate = true;
        public bool canRotate
        {
            get => _canRotate;
            set => _canRotate = value;
        }

        [SerializeField] Views<GameObject> views;
        [SerializeField] Directions facingDirection = Directions.Down;
        #endregion Rotate

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

            if (rb.velocity != Vector3.zero)
                Rotate(rb.velocity);

            foreach (IMove IMove in IMoves)
                IMove.OnSpeedChanged(newVelocity);
        }
        //TODO: MoveTo(Vector3)

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
            GameObject newSide = views.Get(newDirection);
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
    }

    public interface IMove
    {
        void OnSpeedChanged(Vector3 speed);
    }
}