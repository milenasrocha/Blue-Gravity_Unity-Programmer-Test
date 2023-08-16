using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace LittleSimWorld
{
    public class InputReader : Singleton<InputReader>
    {
        [SerializeField] PlayerInput playerInput;
        Dictionary<string, InputAction> inputActions;

        public static Vector2 Movement { get; private set; }
        public void OnMovement(InputAction.CallbackContext context) => Movement = context.ReadValue<Vector2>();

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