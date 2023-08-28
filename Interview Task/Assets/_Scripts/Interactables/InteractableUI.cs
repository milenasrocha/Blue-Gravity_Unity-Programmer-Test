using System;
using UnityEngine;

namespace LittleSimWorld
{
    public class InteractableUI<T> : MonoBehaviour where T : Interactable
    {
        [SerializeField] GameObject canvas;

        [SerializeField] public event Action onStopInteraction;

        protected virtual void StopInteraction()
        {
            if (onStopInteraction != null)
                onStopInteraction.Invoke();
        }

        public void ShowCanvas() => canvas.SetActive(true);
        public void HideCanvas() => canvas.SetActive(false);
    }
}