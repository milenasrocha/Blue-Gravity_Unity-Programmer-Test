using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace LittleSimWorld
{
    public class InputReader : Singleton<InputReader>
    {
        [SerializeField] PlayerInput playerInput;
        Dictionary<string, InputAction> inputActions;

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