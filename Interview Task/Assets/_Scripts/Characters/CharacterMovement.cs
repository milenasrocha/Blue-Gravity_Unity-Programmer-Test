using UnityEngine;
using UnityEngine.Windows;

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
        [SerializeField] GameObject frontView;
        [SerializeField] GameObject backView;
        [SerializeField] GameObject rightView;

        [SerializeField] Directions facingDirection = Directions.Down;
        #endregion Rotate

        IMove[] IMoves = new IMove[0];

        #region References
        [Header("References")]
        [SerializeField] Rigidbody rb;
        [SerializeField, Range(.1f, 5)] protected float characterControllerSpeed = 2;
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
            newVelocity = input * characterControllerSpeed;
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
        public void Rotate(Directions direction)
        {
            if (!canRotate)
                return;

            if (facingDirection == direction)
                return;

            //disable previous facing direction
            GetViewGO(facingDirection).SetActive(false);


            //enable current facing direction
            if (direction == Directions.Left || direction == Directions.Right)
                SideViewFlip(direction);

            GetViewGO(direction).SetActive(true);

            facingDirection = direction;
        }
        GameObject GetViewGO(Directions direction)
        {
            //maybe could switch to 'GameObject[] views' and use the values of Directions as index for the [];
            switch (direction)
            {
                case Directions.Right:
                case Directions.Left:
                    return rightView;

                case Directions.Up:
                    return backView;

                case Directions.Down:
                    return frontView;
            }

            return frontView;
        }
        void SideViewFlip(Directions direction)
        {
            Vector3 currentScale = rightView.transform.localScale;

            if (direction == Directions.Left)
                rightView.transform.localScale = new Vector3(-1, currentScale.y, currentScale.z);
            else
                rightView.transform.localScale = new Vector3(1, currentScale.y, currentScale.z);
        }

    }

    public interface IMove
    {
        void OnSpeedChanged(Vector3 speed);
    }
}