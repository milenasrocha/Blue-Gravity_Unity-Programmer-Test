using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

namespace LittleSimWorld
{
    public class InputActionListener : MonoBehaviour
    {
        public InputActionReference inputAction;

        public UnityEvent<CallbackContext> started;
        public UnityEvent<CallbackContext> canceled;
        public UnityEvent<CallbackContext> performed;

        void OnEnable()
        {
            inputAction.action.started += started.Invoke;
            inputAction.action.canceled += canceled.Invoke;
            inputAction.action.performed += performed.Invoke;
        }

        void OnDisable()
        {
            inputAction.action.started -= started.Invoke;
            inputAction.action.canceled -= canceled.Invoke;
            inputAction.action.performed -= performed.Invoke;
        }
    }
}