using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace LittleSimWorld
{
    public class InputReader : Singleton<InputReader>
    {
        [SerializeField] PlayerInput playerInput;
        Dictionary<string, InputAction> inputActions;

        #region Gameplay
        public static Vector2 Movement { get; private set; }
        public void OnMovement(InputAction.CallbackContext context) => Movement = context.ReadValue<Vector2>();

        public static InputAction Interact => GetInputAction("Interact");
        #endregion Gameplay


        #region Unity Callbacks
        protected override void Awake()
        {
            base.Awake();
            inputActions = new Dictionary<string, InputAction>();
        }
        #endregion Unity Callbacks

        public static InputAction GetInputAction(string s)
        {
            if (Instance.inputActions.TryGetValue(s, out InputAction cachedInputAction))
                return cachedInputAction;

            InputAction inputAction = Instance.playerInput.actions[s];
            Instance.inputActions.Add(s, inputAction);
            return inputAction;
        }
    }
}