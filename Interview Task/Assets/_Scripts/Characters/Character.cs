using UnityEngine;

namespace LittleSimWorld.Characters
{
    public class Character : MonoBehaviour
    {
        [SerializeField] CharacterMovement _mover;
        public CharacterMovement mover
        {
            get => _mover; private set { _mover = value;}
        }
    }
}