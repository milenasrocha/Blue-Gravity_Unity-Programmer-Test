using UnityEngine;

namespace LittleSimWorld.Characters
{
    public class CharacterAnimation : MonoBehaviour, IMove
    {
        [SerializeField] Animator animator;
        [Space]
        [SerializeField] float velocitySensitivity = 1;

        void IMove.OnSpeedChanged(Vector3 speed)
        {
            animator.SetFloat("Velocity", speed.magnitude* velocitySensitivity);
        }
    }
}
