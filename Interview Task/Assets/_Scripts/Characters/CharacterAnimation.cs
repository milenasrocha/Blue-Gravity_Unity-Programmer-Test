using UnityEngine;

namespace LittleSimWorld.Characters
{
    [RequireComponent(typeof(Character))]
    public class CharacterAnimation : MonoBehaviour, IMove
    {
        [SerializeField] Animator animator;
        [Space]
        [SerializeField] float velocitySensitivity = 1;

        void IMove.OnVelocityChanged(Vector3 speed)
        {
            animator.SetFloat("Velocity", speed.magnitude* velocitySensitivity);
        }
    }
}
